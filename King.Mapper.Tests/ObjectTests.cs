﻿namespace King.Mapper.Tests
{
    using King.Mapper.Tests.Models;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Linq;
    using System.Text;

    [TestClass]
    public class ObjectTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void FillObjectNull()
        {
            object obj = null;
            obj.Fill(new string[0], new object[0]);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ValueMappingObjectNull()
        {
            object obj = null;
            obj.ValueMapping(new string[0]);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ValueMappingParametersNull()
        {
            var obj = new object();
            obj.ValueMapping(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetPropertiesObjectNull()
        {
            object obj = null;
            obj.GetProperties();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ParametersObjectNull()
        {
            object obj = null;
            obj.Parameters();
        }

        [TestMethod]
        public void GetPropertiesCount()
        {
            var obj = new FillObject();
            var objProperties = obj.GetProperties();

            var properties = typeof(FillObject).GetProperties();
            Assert.AreEqual<int>(properties.Count(), objProperties.Count());
        }

        [TestMethod]
        public void ObjectParameter()
        {
            var obj = new object();
            Assert.AreEqual<int>(0, obj.Parameters().Length);
        }

        [TestMethod]
        public void ObjectParameters()
        {
            var obj = new TestActionNames();
            Assert.AreEqual<int>(3, obj.Parameters().Length);
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

        [TestMethod]
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
            Assert.AreEqual<string>(getValues.Band, (string)mappings["Band"]);
            Assert.AreEqual<int>(getValues.Id, (int)mappings["Id"]);
            Assert.AreEqual<Guid>(getValues.Song, (Guid)mappings["Song"]);
        }

        [TestMethod]
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
            Assert.AreEqual<int>(5, mappings.Count);
            Assert.AreEqual<string>(getValues.Band, (string)mappings["Band"]);
            Assert.AreEqual<string>(getValues.Band, (string)mappings["CheckBandDude"]);
            Assert.AreEqual<int>(getValues.Id, (int)mappings["Id"]);
            Assert.AreEqual<Guid>(getValues.Song, (Guid)mappings["Song"]);
            Assert.AreEqual<Guid>(getValues.Song, (Guid)mappings["GuidGuid"]);
        }

        [TestMethod]
        public void GetProperties()
        {
            var obj = new TestAttribute();
            var prop = obj.GetProperties();

            Assert.AreEqual<int>(1, prop.Length);
            Assert.AreEqual<string>("TestMethod", prop[0].Name);
        }

        [TestMethod]
        public void Parameters()
        {
            var proc = new TestAttribute();
            var prop = proc.Parameters();

            Assert.AreEqual<int>(1, prop.Length);
            Assert.AreEqual<string>("TestMethod", prop[0]);
        }

        [TestMethod]
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

            Assert.AreEqual<string>(band, fillobject.Band);
            Assert.AreEqual<int>(id, fillobject.Id);
            Assert.AreEqual<Guid>(song, fillobject.Song);
            Assert.AreEqual<byte?>(nullableByte, fillobject.NullableByte);
            Assert.AreEqual<HappyLand>(superEnum, fillobject.SuperEnum);
            Assert.AreEqual<SadLand?>(relType, fillobject.NullableEnum);
            Assert.AreEqual<Guid?>(theGuid, fillobject.TheGuid);
            Assert.AreEqual<Encoding>(e, fillobject.Ecode);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void MapFromToFromNull()
        {
            object obj = null;
            obj.Map<object>(new Object());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void MapFromToToNull()
        {
            var obj = new object();
            obj.Map<object>(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void MapFromFromNull()
        {
            object obj = null;
            obj.Map<object>();
        }

        [TestMethod]
        public void MapFromTo()
        {
            var item = new MappingTester()
            {
                Temp = Guid.NewGuid(),
            };

            var data = item.Map<MappingTester>(new MappingTester());
            Assert.IsNotNull(data);
            Assert.AreEqual<Guid>(item.Temp, data.Temp);
        }

        [TestMethod]
        public void MapFrom()
        {
            var item = new MappingTester()
            {
                Temp = Guid.NewGuid(),
            };

            var data = item.Map<MappingTester>();
            Assert.IsNotNull(data);
            Assert.AreEqual<Guid>(item.Temp, data.Temp);
        }

        [TestMethod]
        public void GetAttributeNull()
        {
            var test = new TestAttribute();
            var attribute = test.GetAttribute<ActionNameAttribute>();
            Assert.IsNull(attribute);
        }
    }
}
