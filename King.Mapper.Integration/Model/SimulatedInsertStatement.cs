namespace King.Mapper.Integration.Model
{
    using King.Mapper.Data;
    using King.Mapper.Data.Sql;
    using System.Data;

    public class SimulatedInsertStatement : IStoredProcedure
    {
        public string Name
        {
            get
            {
                return "[dbo].[SimulatedInsertStatement]";
            }
        }

        [DataMapper("@TestInt", DbType.Int32)]
        public int? TestInt
        {
            get;
            set;
        }
    }
}