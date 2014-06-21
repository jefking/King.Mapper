namespace King.Mapper.Data.Sql
{
    using System.Data;
    using System.Threading.Tasks;

    #region IStoredProcedure
    public interface IExecutor
    {
        #region Methods
        Task<DataSet> Execute();
        Task<int> NonQuery();
        #endregion
    }
    #endregion

    #region IStoredProcedure
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