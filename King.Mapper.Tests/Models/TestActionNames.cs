namespace King.Mapper.Tests.Models
{
    using System;

    public class TestActionNames
    {
        [ActionName(ActionFlags.Execute, "MyIdentifier")]
        public int Id
        {
            get;
            set;
        }

        [ActionName(ActionFlags.Load, "CheckBandDude")]
        public string Band
        {
            get;
            set;
        }

        [ActionName(ActionFlags.Load, "GraceGuid")]
        public Guid Song
        {
            get;
            set;
        }
    }
}
