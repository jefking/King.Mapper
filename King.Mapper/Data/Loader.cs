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
        public IList<T> LoadObjects(IDbCommand cmd, ActionFlags action = ActionFlags.Load)
        {
            if (null == cmd)
            {
                throw new ArgumentNullException("cmd");
            }

            var reader = cmd.ExecuteReader();

            return reader.Read() ? reader.LoadObjects<T>(action) : null;
        }
        public T LoadObject(IDbCommand cmd, ActionFlags action = ActionFlags.Load)
        {
            if (null == cmd)
            {
                throw new ArgumentNullException("cmd");
            }

            var reader = cmd.ExecuteReader();
            return reader.Read() ? reader.LoadObject<T>(action) : default(T);
        }
        #endregion

        #region IDataReader
        public IList<T> LoadObjects(IDataReader reader, ActionFlags action = ActionFlags.Load)
        {
            if (null == reader)
            {
                throw new ArgumentNullException("reader");
            }

            return reader.LoadObjects<T>(action);
        }
        public T LoadObject(IDataReader reader, ActionFlags action = ActionFlags.Load)
        {
            if (null == reader)
            {
                throw new ArgumentNullException("reader");
            }

            return reader.LoadObject<T>(action);
        }
        #endregion

        #region DataTable
        public IList<T> LoadObjects(DataTable data, ActionFlags action = ActionFlags.Load)
        {
            if (null == data)
            {
                throw new ArgumentNullException("data");
            }

            return data.LoadObjects<T>(action);
        }
        public T LoadObject(DataTable data, ActionFlags action = ActionFlags.Load)
        {
            if (null == data)
            {
                throw new ArgumentNullException("data");
            }

            return data.LoadObject<T>(action);
        }
        #endregion

        #region DataSet
        public IList<T> LoadObjects(DataSet data, ActionFlags action = ActionFlags.Load)
        {
            if (null == data)
            {
                throw new ArgumentNullException("data");
            }

            return data.LoadObjects<T>(action);
        }
        public T LoadObject(DataSet data, ActionFlags action = ActionFlags.Load)
        {
            if (null == data)
            {
                throw new ArgumentNullException("data");
            }

            return data.LoadObject<T>(action);
        }
        #endregion
    }
}