namespace King.Mapper.Integration.Model
{
    using King.Mapper.Data;
    using System.Data;

    public class SimulatedInsertStatement : IStoredProcedure
    {
        public string FullyQualifiedName()
        {
            return "[dbo].[SimulatedInsertStatement]";
        }

        [DataMapper("@TestInt", DbType.Int32)]
        public int? TestInt
        {
            get;
            set;
        }
    }
}