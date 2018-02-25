namespace King.Mapper.Tests.Models
{
    using System;
    using System.Text;

    public class FillObject
    {
        public int Id
        {
            get;
            set;
        }

        public string Band
        {
            get;
            set;
        }

        public Guid Song
        {
            get;
            set;
        }

        public Encoding Ecode
        {
            get;
            set;
        }

        public byte? NullableByte
        {
            get;
            set;
        }

        public HappyLand SuperEnum
        {
            get;
            set;
        }

        public SadLand? NullableEnum
        {
            get;
            set;
        }

        public Guid? TheGuid
        {
            get;
            set;
        }
    }
}
