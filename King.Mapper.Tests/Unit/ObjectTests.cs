namespace King.Mapper.Tests
{
    using King.Mapper.Tests.Models;
    using NUnit.Framework;
    using System;
    using System.Linq;
    using System.Text;

    [TestFixture]
    public class ObjectTests
    {
        [Test]
        public void FillObjectNull()
        {
            object obj = null;
            Assert.That(() => obj.Fill(new string[0], new object[0]), Throws.TypeOf<ArgumentNullException>());
        }

        [Test]
        public void FillColumnsNull()
        {
            var obj = new object();
            Assert.That(() => obj.Fill(null, new object[0]), Throws.TypeOf<ArgumentNullException>());
        }

        [Test]
        public void FillValuesNull()
        {
            var obj = new object();
            Assert.That(() => obj.Fill(new string[0], null), Throws.TypeOf<ArgumentNullException>());
        }

        [Test]
        public void FillDifferentSizes()
        {
            var obj = new object();
            Assert.That(() => obj.Fill(new string[0], new object[10]), Throws.TypeOf<ArgumentException>());
        }

        [Test]
        public void Fill()
        {
            var random = new Random();
            var obj = new TestActionNames();
            var columns = new string[] { "MyIdentifier", "Insert" };
            var values = new object[] { random.Next(), Guid.NewGuid() };
            obj.Fill(columns, values, ActionFlags.Execute);

            Assert.AreEqual((int)values[0], obj.Id);
            Assert.AreEqual((Guid)values[1], obj.Song);
        }

        [Test]
        public void ToDictionaryObjectNull()
        {
            object obj = null;
            Assert.AreEqual(null, obj.ToDictionary());
        }

        [Test]
        public void ToDictionaryObject()
        {
            var random = new Random();

            var obj = new FillObject()
            {
                Band = Guid.NewGuid().ToString(),
                Id = random.Next(),
                Song = Guid.NewGuid(),
                TheGuid = Guid.NewGuid(),
                NullableByte = null,
                Ecode = Encoding.Unicode,
                SuperEnum = HappyLand.MarioLand,
            };

            var dic = obj.ToDictionary();
            Assert.AreEqual(obj.Band, dic["Band"]);
            Assert.AreEqual(obj.Id, dic["Id"]);
            Assert.AreEqual(obj.Song, dic["Song"]);
            Assert.AreEqual(obj.TheGuid, dic["TheGuid"]);
            Assert.AreEqual(obj.NullableByte, dic["NullableByte"]);
            Assert.AreEqual(obj.Ecode, dic["Ecode"]);
            Assert.AreEqual(obj.SuperEnum, dic["SuperEnum"]);
        }

        [Test]
        public void ValueMappingObjectNull()
        {
            object obj = null;
            Assert.AreEqual(null, obj.ValueMapping(new string[0]));
        }

        [Test]
        public void ValueMappingParametersNull()
        {
            var obj = new object();
            Assert.AreEqual(null, obj.ValueMapping(null));
        }

        [Test]
        public void GetPropertiesObjectNull()
        {
            object obj = null;
            Assert.AreEqual(null, obj.GetProperties());
        }

        [Test]
        public void ParametersObjectNull()
        {
            object obj = null;
            Assert.AreEqual(null, obj.Parameters());
        }

        [Test]
        public void GetPropertiesCount()
        {
            var obj = new FillObject();
            var objProperties = obj.GetProperties();

            var properties = typeof(FillObject).GetProperties();
            Assert.AreEqual(properties.Count(), objProperties.Count());
        }

        [Test]
        public void ObjectParameter()
        {
            var obj = new object();
            Assert.AreEqual(0, obj.Parameters().Count());
        }

        [Test]
        public void ObjectParameters()
        {
            var obj = new TestActionNames();
            Assert.AreEqual(3, obj.Parameters().Count());
            foreach (var property in obj.Parameters())
            {
                switch (property)
                {
                    case "Id":
                    case "Band":
                    case "Song":
                        continue;
                    default:
                        Assert.Fail();
                        break;
                }
            }
        }

        [Test]
        public void ValueMapping()
        {
            var random = new Random();
            var getValues = new FillObject()
            {
                Band = Guid.NewGuid().ToString(),
                Id = random.Next(),
                Song = Guid.NewGuid(),
            };

            var mappings = getValues.ValueMapping(new string[] { "Id", "Band", "Song" });
            Assert.AreEqual(getValues.Band, (string)mappings["Band"]);
            Assert.AreEqual(getValues.Id, (int)mappings["Id"]);
            Assert.AreEqual(getValues.Song, (Guid)mappings["Song"]);
        }

        [Test]
        public void ValueMappingTestActionNames()
        {
            var random = new Random();
            var getValues = new TestActionNames()
            {
                Band = Guid.NewGuid().ToString(),
                Id = random.Next(),
                Song = Guid.NewGuid(),
            };

            var mappings = getValues.ValueMapping(new string[] { "Id", "Band", "Song" }, ActionFlags.Load);
            Assert.AreEqual(5, mappings.Count);
            Assert.AreEqual(getValues.Band, (string)mappings["Band"]);
            Assert.AreEqual(getValues.Band, (string)mappings["CheckBandDude"]);
            Assert.AreEqual(getValues.Id, (int)mappings["Id"]);
            Assert.AreEqual(getValues.Song, (Guid)mappings["Song"]);
            Assert.AreEqual(getValues.Song, (Guid)mappings["GuidGuid"]);
        }

        [Test]
        public void GetProperties()
        {
            var obj = new TestingAttribute();
            var prop = obj.GetProperties();

            Assert.AreEqual(1, prop.Count());
            Assert.AreEqual("TestMethod", prop.ElementAt(0).Name);
        }

        [Test]
        public void Parameters()
        {
            var proc = new TestingAttribute();
            var prop = proc.Parameters();

            Assert.AreEqual(1, prop.Count());
            Assert.AreEqual("TestMethod", prop.ElementAt(0));
        }

        [Test]
        public void SetPropertyInfo()
        {
            var random = new Random();
            var band = Guid.NewGuid().ToString();
            var id = random.Next();
            var song = Guid.NewGuid();
            var theGuid = Guid.NewGuid();
            byte? nullableByte = null;
            var e = Encoding.Unicode;
            var superEnum = HappyLand.MarioLand;
            SadLand? relType = null;

            var fillobject = new FillObject();

            foreach (var property in fillobject.GetProperties())
            {
                switch (property.Name)
                {
                    case "Band":
                        property.Set(fillobject, band);
                        break;
                    case "Id":
                        property.Set(fillobject, id);
                        break;
                    case "Song":
                        property.Set(fillobject, song);
                        break;
                    case "NullableByte":
                        property.Set(fillobject, nullableByte);
                        break;
                    case "SuperEnum":
                        property.Set(fillobject, (byte)12);
                        break;
                    case "NullableEnum":
                        property.Set(fillobject, null);
                        break;
                    case "TheGuid":
                        property.Set(fillobject, theGuid);
                        break;
                    case "Ecode":
                        property.Set(fillobject, e);
                        break;
                    default:
                        break;
                }
            }

            Assert.AreEqual(band, fillobject.Band);
            Assert.AreEqual(id, fillobject.Id);
            Assert.AreEqual(song, fillobject.Song);
            Assert.AreEqual(nullableByte, fillobject.NullableByte);
            Assert.AreEqual(superEnum, fillobject.SuperEnum);
            Assert.AreEqual(relType, fillobject.NullableEnum);
            Assert.AreEqual(theGuid, fillobject.TheGuid);
            Assert.AreEqual(e, fillobject.Ecode);
        }

        [Test]
        public void MapFromToFromNull()
        {
            object obj = null;
            Assert.That(() => obj.Map<object>(new Object()), Throws.TypeOf<ArgumentNullException>());
        }

        [Test]
        public void MapFromToToNull()
        {
            var obj = new object();
            Assert.That(() => obj.Map<object>(null), Throws.TypeOf<ArgumentNullException>());
        }

        [Test]
        public void MapFromFromNull()
        {
            object obj = null;
            Assert.That(() => obj.Map<object>(), Throws.TypeOf<ArgumentNullException>());
        }

        [Test]
        public void MapFromTo()
        {
            var item = new MappingTester()
            {
                Temp = Guid.NewGuid(),
            };

            var data = item.Map<MappingTester>(new MappingTester());
            Assert.IsNotNull(data);
            Assert.AreEqual(item.Temp, data.Temp);
        }

        [Test]
        public void MapFrom()
        {
            var item = new MappingTester()
            {
                Temp = Guid.NewGuid(),
            };

            var data = item.Map<MappingTester>();
            Assert.IsNotNull(data);
            Assert.AreEqual(item.Temp, data.Temp);
        }

        [Test]
        public void GetAttributeNull()
        {
            var test = new TestAttribute();
            var attribute = test.GetAttribute<ActionNameAttribute>();
            Assert.IsNull(attribute);
        }

        [Test]
        public void GetAttributeObjectNull()
        {
            object test = null;
            Assert.That(() => test.GetAttribute<ActionNameAttribute>(), Throws.TypeOf<ArgumentNullException>());
        }
    }
}