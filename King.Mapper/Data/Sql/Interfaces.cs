namespace King.Mapper.Data.Sql
{
    #region IStoredProc
    /// <summary>
    /// Stored Procedure
    /// </summary>
    public interface IStoredProcedure
    {
        #region Properties
        /// <summary>
        /// Stored Procedure Name
        /// </summary>
        string Name
        {
            get;
        }
        #endregion
    }
    #endregion
}
