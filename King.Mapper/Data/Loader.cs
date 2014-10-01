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
        /// <summary>
        /// Generate Models from Database Command
        /// </summary>
        /// <param name="cmd">Command</param>
        /// <param name="action">Action</param>
        /// <returns>Models</returns>
        public virtual IEnumerable<T> Models(IDbCommand cmd, ActionFlags action = ActionFlags.Load)
        {
            if (null == cmd)
            {
                throw new ArgumentNullException("cmd");
            }

            var reader = cmd.ExecuteReader();

            return reader.Models<T>(action);
        }

        /// <summary>
        /// Generate Model from Database Command
        /// </summary>
        /// <param name="cmd">Command</param>
        /// <param name="action">Action</param>
        /// <returns>Model</returns>
        public virtual T Model(IDbCommand cmd, ActionFlags action = ActionFlags.Load)
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
        public virtual IEnumerable<T> Models(IDataReader reader, ActionFlags action = ActionFlags.Load)
        {
            if (null == reader)
            {
                throw new ArgumentNullException("reader");
            }

            return reader.Models<T>(action);
        }

        public virtual T Model(IDataReader reader, ActionFlags action = ActionFlags.Load)
        {
            if (null == reader)
            {
                throw new ArgumentNullException("reader");
            }

            return reader.Model<T>(action);
        }
        #endregion

        #region DataTable
        public virtual IEnumerable<T> Models(DataTable data, ActionFlags action = ActionFlags.Load)
        {
            if (null == data)
            {
                throw new ArgumentNullException("data");
            }

            return data.Models<T>(action);
        }
        public virtual T Model(DataTable data, ActionFlags action = ActionFlags.Load)
        {
            if (null == data)
            {
                throw new ArgumentNullException("data");
            }

            return data.Model<T>(action);
        }
        #endregion

        #region DataSet
        public virtual IEnumerable<T> Models(DataSet data, ActionFlags action = ActionFlags.Load)
        {
            if (null == data)
            {
                throw new ArgumentNullException("data");
            }

            return data.Models<T>(action);
        }
        public virtual T Model(DataSet data, ActionFlags action = ActionFlags.Load)
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