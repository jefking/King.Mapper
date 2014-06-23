namespace King.Mapper.Integration.Model
{
    using King.Mapper.Data;

    public class SelectMultipleStatement : IStoredProcedure
    {
        public string FullyQualifiedName()
        {
            return "[dbo].[SelectMultipleStatement]";
        }
    }
}