namespace King.Mapper.Data
{
    using System;
    using System.Data;

    /// <summary>
    /// Data Mapper Attribute
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class DataMapperAttribute : Attribute
    {
        #region Members
        /// <summary>
        /// Parameter Name
        /// </summary>
        protected readonly string parameterName;

        /// <summary>
        /// Database Type
        /// </summary>
        protected readonly DbType type;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the DataMapperAttribute class
        /// </summary>
        /// <param name="parameterName">Parameter Name</param>
        /// <param name="type">Database Type</param>
        public DataMapperAttribute(string parameterName, DbType type)
        {
            if (string.IsNullOrWhiteSpace(parameterName))
            {
                throw new ArgumentException("parameterName is invalid");
            }

            this.parameterName = parameterName;
            this.type = type;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets the Parameter Name
        /// </summary>
        public virtual string ParameterName
        {
            get
            {
                return this.parameterName;
            }
        }

        /// <summary>
        /// Gets the Database Type
        /// </summary>
        public virtual DbType DatabaseType
        {
            get
            {
                return this.type;
            }
        }
        #endregion
    }
}
