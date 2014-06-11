namespace King.Mapper.Data
{
    using System;
    using System.Collections.Generic;
    using System.Data;

    /// <summary>
    /// Reader Loader
    /// </summary>
    public class ReaderLoader<T> : IReaderLoader<T>
            where T : new()
    {
        #region Members
        private readonly IDataReader reader = null;
        #endregion

        #region Constructors
        public ReaderLoader(IDataReader reader)
        {
            if (null == reader)
            {
                throw new ArgumentNullException("reader");
            }

            this.reader = reader;
        }
        #endregion

        #region Methods
        public IList<T> LoadObjects(ActionFlags action = ActionFlags.Load)
        {
            return this.reader.LoadObjects<T>(action);
        }
        #endregion
    }
}