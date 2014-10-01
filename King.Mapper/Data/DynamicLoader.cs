namespace King.Mapper.Data
{
    using System;
    using System.Collections.Generic;
    using System.Data;

    public class DynamicLoader : IDynamicLoader
    {
        #region DataTable
        public virtual IDictionary<string, object> Dictionary(DataTable data)
        {
            if (null == data)
            {
                throw new ArgumentNullException("data");
            }

            return data.Dictionary();
        }
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
