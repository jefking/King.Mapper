namespace King.Mapper.Integration.Model
{
    using King.Mapper.Data.Sql;

    public class SimulatedInsertStatement : IStoredProcedure
    {
        public string Name
        {
            get
            {
                return "[dbo].[SimulatedInsertStatement]";
            }
        }
        public int? TestInt
        {
            get;
            set;
        }
    }
}
