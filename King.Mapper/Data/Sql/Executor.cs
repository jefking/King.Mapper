namespace King.Mapper.Data.Sql
{
    using King.Mapper;
    using System;
    using System.Data;
    using System.Data.SqlClient;

    /// <summary>
    /// Stored Procedure Executor
    /// </summary>
    public class Executor
    {
        #region Members
        /// <summary>
        /// Stored Procedure to Execute
        /// </summary>
        private readonly IStoredProcedure sproc = null;

        /// <summary>
        /// SQL Connection
        /// </summary>
        private readonly SqlConnection connection = null;
        #endregion

        #region Constructors
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="connection">SQL Connection</param>
        /// <param name="sproc">Stored Procedure</param>
        public Executor(SqlConnection connection, IStoredProcedure sproc)
        {
            if (null == connection)
            {
                throw new ArgumentNullException("connection");
            }
            if (null == sproc)
            {
                throw new ArgumentNullException("sproc");
            }

            this.connection = connection;
            this.sproc = sproc;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Execute IStored Proc
        /// </summary>
        /// <param name="proc">Procedure</param>
        /// <returns>Data Set</returns>
        public DataSet Execute()
        {
            DataSet ds = null;
            using (var command = this.BuildCommand())
            {
                using (var adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(ds);
                }
            }

            return ds;
        }

        /// <summary>
        /// Execute Non-Query
        /// </summary>
        /// <param name="proc">Procedure To Execute</param>
        /// <returns>rows affected</returns>
        public int NonQuery()
        {
            var rowsAffected = 0;
            using (var command = this.BuildCommand())
            {
                rowsAffected = command.ExecuteNonQuery();
            }

            return rowsAffected;
        }

        /// <summary>
        /// Build Command
        /// </summary>
        /// <param name="proc">Procedure</param>
        /// <param name="database">Database</param>
        /// <returns>Database Command</returns>
        public SqlCommand BuildCommand()
        {
            var command = this.connection.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = this.sproc.Name;

            foreach (var prop in this.sproc.GetProperties())
            {
                var mapper = this.sproc.GetAttribute<DataMapperAttribute>();

                if (mapper != null)
                {
                    var value = prop.GetValue(this.sproc, null);
                    var param = new SqlParameter()
                    {
                        DbType = mapper.DatabaseType,
                        Value = value,
                        ParameterName = mapper.ParameterName,
                    };

                    command.Parameters.Add(param);
                }
            }

            return command;
        }
        #endregion
    }
}