namespace King.Mapper.Integration.Model
{
    using King.Mapper.Data.Sql;

    class SelectMultipleStatement : IStoredProcedure
    {
        public string Name
        {
            get
            {
                return "[dbo].[SelectMultipleStatement]";
            }
        }
    }
}