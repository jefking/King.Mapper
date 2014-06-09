namespace King.Mapper.Tests.Models
{
    using System;

    public class TestActionNames
    {
        [ActionName("MyIdentifier", ActionFlags.Execute)]
        public int Id
        {
            get;
            set;
        }

        [ActionName("CheckBandDude")]
        public string Band
        {
            get;
            set;
        }

        [ActionName("GuidGuid", ActionFlags.Load)]
        public Guid Song
        {
            get;
            set;
        }
    }
}
