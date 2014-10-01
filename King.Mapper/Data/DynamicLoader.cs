namespace King.Mapper.Data
{
    using System;
    using System.Collections.Generic;
    using System.Data;

    /// <summary>
    /// Dynamic Loader
    /// </summary>
    public class DynamicLoader : IDynamicLoader
    {
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
        #endregion

        #region DataSet
        /// <summary>
        /// Generate Models from Data Set
        /// </summary>
        /// <param name="data">Data Set</param>
        /// <param name="action">Action</param>
        /// <returns>Models</returns>
        public virtual IEnumerable<IDictionary<string, object>> Dictionaries(DataSet data)
        {
            if (null == data)
            {
                throw new ArgumentNullException("data");
            }

            return data.Dictionaries();
        }

        /// <summary>
        /// Generate Model from Data Set
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
        #endregion
    }
}