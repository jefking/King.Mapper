namespace King.Mapper.Integration.Model
{
    using King.Mapper.Data.Sql;

    public class SimulatedSelectStatement : IStoredProcedure
    {
        public string Name
        {
            get
            {
                return "[dbo].[SimulatedSelectStatement]";
            }
        }
        public int? TestInt
        {
            get;
            set;
        }
    }
}