namespace King.Mapper.Integration.Model
{
    using King.Mapper.Data.Sql;

    public class SelectMultipleStatement : IStoredProcedure
    {
        public string FullyQualifiedName()
        {
            return "[dbo].[SelectMultipleStatement]";
        }
    }
}