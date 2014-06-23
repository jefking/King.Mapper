namespace King.Mapper.Data
{
    using System;
    using System.Collections.Generic;
    using System.Data;

    /// <summary>
    /// Loader
    /// </summary>
    public class Loader<T> : ILoader<T>
            where T : new()
    {
        #region IDbCommand
        public IList<T> Models(IDbCommand cmd, ActionFlags action = ActionFlags.Load)
        {
            if (null == cmd)
            {
                throw new ArgumentNullException("cmd");
            }

            var reader = cmd.ExecuteReader();

            return reader.Models<T>(action);
        }
        public T Model(IDbCommand cmd, ActionFlags action = ActionFlags.Load)
        {
            if (null == cmd)
            {
                throw new ArgumentNullException("cmd");
            }

            var reader = cmd.ExecuteReader();
            return reader.Read() ? reader.Model<T>(action) : default(T);
        }
        #endregion

        #region IDataReader
        public IList<T> Models(IDataReader reader, ActionFlags action = ActionFlags.Load)
        {
            if (null == reader)
            {
                throw new ArgumentNullException("reader");
            }

            return reader.Models<T>(action);
        }

        public T Model(IDataReader reader, ActionFlags action = ActionFlags.Load)
        {
            if (null == reader)
            {
                throw new ArgumentNullException("reader");
            }

            return reader.Model<T>(action);
        }
        #endregion

        #region DataTable
        public IList<T> Models(DataTable data, ActionFlags action = ActionFlags.Load)
        {
            if (null == data)
            {
                throw new ArgumentNullException("data");
            }

            return data.Models<T>(action);
        }
        public T Model(DataTable data, ActionFlags action = ActionFlags.Load)
        {
            if (null == data)
            {
                throw new ArgumentNullException("data");
            }

            return data.Model<T>(action);
        }
        #endregion

        #region DataSet
        public IList<T> Models(DataSet data, ActionFlags action = ActionFlags.Load)
        {
            if (null == data)
            {
                throw new ArgumentNullException("data");
            }

            return data.Models<T>(action);
        }
        public T Model(DataSet data, ActionFlags action = ActionFlags.Load)
        {
            if (null == data)
            {
                throw new ArgumentNullException("data");
            }

            return data.Model<T>(action);
        }
        #endregion
    }
}