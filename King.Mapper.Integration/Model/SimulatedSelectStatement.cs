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
    }
}