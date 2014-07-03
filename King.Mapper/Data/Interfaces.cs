namespace King.Mapper.Data
{
    using System.Collections.Generic;
    using System.Data;
    using System.Threading.Tasks;

    #region ILoader
    /// <summary>
    /// Loader interface to enable mocking frameworks for unit testing
    /// </summary>
    /// <typeparam name="T">Type</typeparam>
    public interface ILoader<T>
    {
        #region IDbCommand
        IEnumerable<T> Models(IDbCommand cmd, ActionFlags action = ActionFlags.Load);
        T Model(IDbCommand cmd, ActionFlags action = ActionFlags.Load);
        #endregion

        #region IDataReader
        IEnumerable<T> Models(IDataReader reader, ActionFlags action = ActionFlags.Load);
        T Model(IDataReader reader, ActionFlags action = ActionFlags.Load);
        #endregion

        #region DataTable
        IEnumerable<T> Models(DataTable data, ActionFlags action = ActionFlags.Load);
        T Model(DataTable data, ActionFlags action = ActionFlags.Load);
        #endregion

        #region DataSet
        IEnumerable<T> Models(DataSet data, ActionFlags action = ActionFlags.Load);
        T Model(DataSet data, ActionFlags action = ActionFlags.Load);
        #endregion
    }
    #endregion

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
        Task<DataSet> Query(IStoredProcedure sproc);

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