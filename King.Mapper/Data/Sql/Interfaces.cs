namespace King.Mapper.Data.Sql
{
    using System.Data;
    using System.Threading.Tasks;

    #region IExecutor
    /// <summary>
    /// Execution Interface
    /// </summary>
    public interface IExecutor
    {
        #region Methods
        /// <summary>
        /// Execute Sproc for mocking
        /// </summary>
        /// <param name="sproc"></param>
        /// <returns></returns>
        Task<DataSet> Execute(IStoredProcedure sproc);

        /// <summary>
        /// Non Query sproc for mocking
        /// </summary>
        /// <param name="sproc"></param>
        /// <returns></returns>
        Task<int> NonQuery(IStoredProcedure sproc);
        #endregion
    }
    #endregion

    #region IStoredProcedure
    /// <summary>
    /// Stored Procedure
    /// </summary>
    public interface IStoredProcedure
    {
        #region Methods
        /// <summary>
        /// Fully Qualified Stored Procedure Name
        /// </summary>
        string FullyQualifiedName();
        #endregion
    }
    #endregion
}