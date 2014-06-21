namespace King.Mapper.Data.Sql
{
    using King.Mapper;
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
        /// Execute IStored Proc
        /// </summary>
        /// <param name="proc">Procedure</param>
        /// <returns>Data Set</returns>
        public async Task<DataSet> Execute(IStoredProcedure sproc)
        {
            if (null == sproc)
            {
                throw new ArgumentNullException("sproc");
            }

            DataSet ds = null;
            using (var command = sproc.Build(this.connection))
            {
                using (var adapter = new SqlDataAdapter(command))
                {
                    await this.connection.OpenAsync();

                    adapter.Fill(ds);

                    this.connection.Close();
                }
            }

            return ds;
        }

        /// <summary>
        /// Execute Non-Query
        /// </summary>
        /// <param name="proc">Procedure To Execute</param>
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
                await this.connection.OpenAsync();

                rowsAffected = await command.ExecuteNonQueryAsync();

                this.connection.Close();
            }

            return rowsAffected;
        }
        #endregion
    }
}