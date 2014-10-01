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
    }
}
