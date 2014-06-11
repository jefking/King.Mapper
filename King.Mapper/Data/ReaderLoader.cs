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
        #region Methods
        public IList<T> LoadObjects(IDbCommand cmd, ActionFlags action = ActionFlags.Load)
        {
            if (null == cmd)
            {
                throw new ArgumentNullException("cmd");
            }

            var reader = cmd.ExecuteReader();
            return reader.LoadObjects<T>(action);
        }
        public T LoadObject(IDbCommand cmd, ActionFlags action = ActionFlags.Load)
        {
            if (null == cmd)
            {
                throw new ArgumentNullException("cmd");
            }

            var reader = cmd.ExecuteReader();
            return reader.LoadObject<T>(action);
        }

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
    }
}