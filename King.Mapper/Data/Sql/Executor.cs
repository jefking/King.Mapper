namespace King.Mapper.Data.Sql
{
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Threading.Tasks;

    /// <summary>
    /// Stored Procedure Executor
    /// </summary>
    public class Executor : IExecutor
    {
        #region Members
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
        public Executor(SqlConnection connection)
        {
            if (null == connection)
            {
                throw new ArgumentNullException("connection");
            }

            this.connection = connection;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Query Database with IStored Procedure
        /// </summary>
        /// <param name="proc">Procedure</param>
        /// <returns>Data Set</returns>
        public async Task<DataSet> Query(IStoredProcedure sproc)
        {
            if (null == sproc)
            {
                throw new ArgumentNullException("sproc");
            }

            var ds = new DataSet();
            using (var command = sproc.Build(this.connection))
            {
                ds = await this.Query(command);
            }

            return ds;
        }

        /// <summary>
        /// Query Database with command object
        /// </summary>
        /// <param name="command">Sql Command</param>
        /// <returns>Data Set</returns>
        public async Task<DataSet> Query(SqlCommand command)
        {
            if (null == command)
            {
                throw new ArgumentNullException("command");
            }

            var ds = new DataSet();
            using (var adapter = new SqlDataAdapter(command))
            {
                await this.connection.OpenAsync();

                adapter.Fill(ds);

                this.connection.Close();
            }

            return ds;
        }

        /// <summary>
        /// Non-Query
        /// </summary>
        /// <param name="sproc">Procedure To Execute</param>
        /// <returns>rows affected</returns>
        public async Task<int> NonQuery(IStoredProcedure sproc)
        {
            if (null == sproc)
            {
                throw new ArgumentNullException("sproc");
            }

            var rowsAffected = 0;
            using (var command = sproc.Build(this.connection))
            {
                rowsAffected = await this.NonQuery(command);
            }

            return rowsAffected;
        }

        /// <summary>
        /// Non-Query
        /// </summary>
        /// <param name="command">Command To Execute</param>
        /// <returns>rows affected</returns>
        public async Task<int> NonQuery(SqlCommand command)
        {
            if (null == command)
            {
                throw new ArgumentNullException("command");
            }

            await this.connection.OpenAsync();

            var rowsAffected = await command.ExecuteNonQueryAsync();

            this.connection.Close();

            return rowsAffected;
        }
        #endregion
    }
}