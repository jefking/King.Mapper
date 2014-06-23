namespace King.Mapper.Integration.Model
{
    using King.Mapper.Data;
    using King.Mapper.Data.Sql;
    using System;
    using System.Data;

    public class SimulatedSelectStatement : IStoredProcedure
    {
        public string FullyQualifiedName()
        {
            return "[dbo].[SimulatedSelectStatement]";
        }

        [DataMapper("@TestInt", DbType.Int32)]
        public int TestInt
        {
            get;
            set;
        }

        [DataMapper("@TestBigInt", DbType.Int64)]
        public long TestBigInt
        {
            get;
            set;
        }

        [DataMapper("@TestBit", DbType.Boolean)]
        public bool TestBit
        {
            get;
            set;
        }

        [DataMapper("@TestDecimal", DbType.Decimal)]
        public decimal TestDecimal
        {
            get;
            set;
        }

        [DataMapper("@TestMoney", DbType.Decimal)]
        public decimal TestMoney
        {
            get;
            set;
        }

        [DataMapper("@TestFloat", DbType.Single)]
        public float TestFloat
        {
            get;
            set;
        }

        [DataMapper("@TestDate", DbType.Date)]
        public DateTime TestDate
        {
            get;
            set;
        }

        [DataMapper("@TestDateTime2", DbType.DateTime2)]
        public DateTime TestDateTime2
        {
            get;
            set;
        }

        [DataMapper("@TestDateTime", DbType.DateTime)]
        public DateTime TestDateTime
        {
            get;
            set;
        }

        [DataMapper("@TestChar", DbType.Int16)]
        public char TestChar
        {
            get;
            set;
        }

        [DataMapper("@TestText", DbType.String)]
        public string TestText
        {
            get;
            set;
        }

        [DataMapper("@TestNChar", DbType.String)]
        public char TestNChar
        {
            get;
            set;
        }

        [DataMapper("@TestNText", DbType.String)]
        public string TestNText
        {
            get;
            set;
        }

        [DataMapper("@TestBinary", DbType.Binary)]
        public byte[] TestBinary
        {
            get;
            set;
        }

        [DataMapper("@TestImage", DbType.Binary)]
        public byte[] TestImage
        {
            get;
            set;
        }

        [DataMapper("@TestGuid", DbType.Guid)]
        public Guid TestGuid
        {
            get;
            set;
        }

        public static SimulatedSelectStatement Create()
        {
            var random = new Random();
            var data = new SimulatedSelectStatement()
            {
                TestInt = random.Next(),
                TestBigInt = random.Next(),
                TestBit = true,
                TestChar = 'x',
                TestDate = DateTime.UtcNow,
                TestDateTime = DateTime.UtcNow,
                TestDateTime2 = DateTime.UtcNow,
                TestDecimal = Convert.ToDecimal(random.NextDouble()),
                TestFloat = Convert.ToSingle(random.NextDouble()),
                TestMoney = Convert.ToDecimal(random.NextDouble()),
                TestNChar = 'y',
                TestNText = Guid.NewGuid().ToString(),
                TestText = Guid.NewGuid().ToString(),
                TestGuid = Guid.NewGuid(),
            };

            data.TestBinary = new byte[64];
            random.NextBytes(data.TestBinary);

            data.TestImage = new byte[64];
            random.NextBytes(data.TestImage);

            return data;
        }
    }
}