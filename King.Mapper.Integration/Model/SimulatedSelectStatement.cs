namespace King.Mapper.Integration.Model
{
    using King.Mapper.Data.Sql;
using System;

    public class SimulatedSelectStatement : IStoredProcedure
    {
        public string Name
        {
            get
            {
                return "[dbo].[SimulatedSelectStatement]";
            }
        }
        public int TestInt
        {
            get;
            set;
        }
        public long TestBigInt
        {
            get;
            set;
        }
        public bool TestBit
        {
            get;
            set;
        }
        public decimal TestDecimal
        {
            get;
            set;
        }
        public decimal TestMoney
        {
            get;
            set;
        }
        public float TestFloat
        {
            get;
            set;
        }
        public DateTime TestDate
        {
            get;
            set;
        }
        public DateTime TestDateTime2
        {
            get;
            set;
        }
        public DateTime TestDateTime
        {
            get;
            set;
        }
        public char TestChar
        {
            get;
            set;
        }
        public string TestText
        {
            get;
            set;
        }
        public char TestNChar
        {
            get;
            set;
        }
        public string TestNText
        {
            get;
            set;
        }
        public byte[] TestBinary
        {
            get;
            set;
        }
        public byte[] TestImage
        {
            get;
            set;
        }
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