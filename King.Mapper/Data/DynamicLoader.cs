namespace King.Mapper.Data
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Dynamic;

    /// <summary>
    /// Dynamic Loader
    /// </summary>
    public class DynamicLoader : IDynamicLoader
    {
        #region IDbCommand
        /// <summary>
        /// Generate Dictionaries from Database Command
        /// </summary>
        /// <param name="cmd">Command</param>
        /// <returns>Dictionaries</returns>
        public virtual IEnumerable<IDictionary<string, object>> Dictionaries(IDbCommand cmd)
        {
            if (null == cmd)
            {
                throw new ArgumentNullException("cmd");
            }

            var reader = cmd.ExecuteReader();

            return reader.Dictionaries();
        }

        /// <summary>
        /// Generate Dictionary from Database Command
        /// </summary>
        /// <param name="cmd">Command</param>
        /// <returns>Dictionary</returns>
        public virtual IDictionary<string, object> Dictionary(IDbCommand cmd)
        {
            if (null == cmd)
            {
                throw new ArgumentNullException("cmd");
            }

            return this.Dynamic(cmd) as IDictionary<string, object>;
        }

        /// <summary>
        /// Generate Dynamics from Database Command
        /// </summary>
        /// <param name="cmd">Command</param>
        /// <returns>Dynamics</returns>
        public virtual IEnumerable<dynamic> Dynamics(IDbCommand cmd)
        {
            if (null == cmd)
            {
                throw new ArgumentNullException("cmd");
            }

            var reader = cmd.ExecuteReader();
            return reader.Dynamics();
        }

        /// <summary>
        /// Generate Dynamic from Database Command
        /// </summary>
        /// <param name="cmd">Command</param>
        /// <returns>Dynamic</returns>
        public virtual dynamic Dynamic(IDbCommand cmd)
        {
            if (null == cmd)
            {
                throw new ArgumentNullException("cmd");
            }

            var reader = cmd.ExecuteReader();
            return reader.Read() ? reader.Dynamic() : new ExpandoObject();
        }
        #endregion

        #region IDataReader
        /// <summary>
        /// Generate Dictionaries from Data Reader
        /// </summary>
        /// <param name="reader">Data Reader</param>
        /// <param name="action">Action</param>
        /// <returns>Dictionaries</returns>
        public virtual IEnumerable<IDictionary<string, object>> Dictionaries(IDataReader reader)
        {
            if (null == reader)
            {
                throw new ArgumentNullException("reader");
            }

            return reader.Dictionaries();
        }

        /// <summary>
        /// Generate Dictionary from Data Reader
        /// </summary>
        /// <param name="reader">Data Reader</param>
        /// <param name="action">Action</param>
        /// <returns>Dictionary</returns>
        public virtual IDictionary<string, object> Dictionary(IDataReader reader)
        {
            if (null == reader)
            {
                throw new ArgumentNullException("reader");
            }

            return reader.Dictionary();
        }

        /// <summary>
        /// Generate Dynamics from Data Reader
        /// </summary>
        /// <param name="reader">Data Reader</param>
        /// <param name="action">Action</param>
        /// <returns>Dynamics</returns>
        public virtual IEnumerable<dynamic> Dynamics(IDataReader reader)
        {
            if (null == reader)
            {
                throw new ArgumentNullException("reader");
            }

            return reader.Dynamics();
        }

        /// <summary>
        /// Generate Dynamic from Data Reader
        /// </summary>
        /// <param name="reader">Data Reader</param>
        /// <param name="action">Action</param>
        /// <returns>Dynamic</returns>
        public virtual dynamic Dynamic(IDataReader reader)
        {
            if (null == reader)
            {
                throw new ArgumentNullException("reader");
            }

            return reader.Dynamic();
        }
        #endregion

        #region DataTable
        /// <summary>
        /// Generate Dictionary from Data Table
        /// </summary>
        /// <param name="data">Data Table</param>
        /// <returns>Dictionary</returns>
        public virtual IDictionary<string, object> Dictionary(DataTable data)
        {
            if (null == data)
            {
                throw new ArgumentNullException("data");
            }

            return data.Dictionary();
        }

        /// <summary>
        /// Generate Dictionaries from Data Table
        /// </summary>
        /// <param name="data">Data Table</param>
        /// <returns>Dictionaries</returns>
        public virtual IEnumerable<IDictionary<string, object>> Dictionaries(DataTable data)
        {
            if (null == data)
            {
                throw new ArgumentNullException("data");
            }

            return data.Dictionaries();
        }

        /// <summary>
        /// Generate Dynamic from Data Table
        /// </summary>
        /// <param name="data">Data Table</param>
        /// <returns>Dynamic</returns>
        public virtual dynamic Dynamic(DataTable data)
        {
            if (null == data)
            {
                throw new ArgumentNullException("data");
            }

            return data.Dynamic();
        }

        /// <summary>
        /// Generate Dynamics from Data Table
        /// </summary>
        /// <param name="data">Data Table</param>
        /// <returns>Dynamics</returns>
        public virtual IEnumerable<dynamic> Dynamics(DataTable data)
        {
            if (null == data)
            {
                throw new ArgumentNullException("data");
            }

            return data.Dynamics();
        }
        #endregion

        #region DataSet
        /// <summary>
        /// Generate Dictionaries from Data Set
        /// </summary>
        /// <param name="data">Data Set</param>
        /// <param name="action">Action</param>
        /// <returns>Dictionaries</returns>
        public virtual IEnumerable<IDictionary<string, object>> Dictionaries(DataSet data)
        {
            if (null == data)
            {
                throw new ArgumentNullException("data");
            }

            return data.Dictionaries();
        }

        /// <summary>
        /// Generate Dictionary from Data Set
        /// </summary>
        /// <param name="data">Data Set</param>
        /// <param name="action">Action</param>
        /// <returns>Dictionary</returns>
        public virtual IDictionary<string, object> Dictionary(DataSet data)
        {
            if (null == data)
            {
                throw new ArgumentNullException("data");
            }

            return data.Dictionary();
        }

        /// <summary>
        /// Generate Dynamics from Data Set
        /// </summary>
        /// <param name="data">Data Set</param>
        /// <param name="action">Action</param>
        /// <returns>Dynamics</returns>
        public virtual IEnumerable<dynamic> Dynamics(DataSet data)
        {
            if (null == data)
            {
                throw new ArgumentNullException("data");
            }

            return data.Dynamics();
        }

        /// <summary>
        /// Generate Dynamic from Data Set
        /// </summary>
        /// <param name="data">Data Set</param>
        /// <param name="action">Action</param>
        /// <returns>Dynamic</returns>
        public virtual dynamic Dynamic(DataSet data)
        {
            if (null == data)
            {
                throw new ArgumentNullException("data");
            }

            return data.Dynamic();
        }
        #endregion
    }
}