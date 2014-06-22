namespace King.Mapper.Data
{
    using System.Collections.Generic;
    using System.Data;

    /// <summary>
    /// Loader interface to enable mocking frameworks for unit testing
    /// </summary>
    /// <typeparam name="T">Type</typeparam>
    public interface ILoader<T>
    {
        #region IDbCommand
        IList<T> Models(IDbCommand cmd, ActionFlags action = ActionFlags.Load);
        T Model(IDbCommand cmd, ActionFlags action = ActionFlags.Load);
        #endregion

        #region IDataReader
        IList<T> Models(IDataReader reader, ActionFlags action = ActionFlags.Load);
        T Model(IDataReader reader, ActionFlags action = ActionFlags.Load);
        #endregion

        #region DataTable
        IList<T> Models(DataTable data, ActionFlags action = ActionFlags.Load);
        T Model(DataTable data, ActionFlags action = ActionFlags.Load);
        #endregion

        #region DataSet
        IList<T> Models(DataSet data, ActionFlags action = ActionFlags.Load);
        T Model(DataSet data, ActionFlags action = ActionFlags.Load);
        #endregion
    }
}