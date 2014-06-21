namespace King.Mapper.Data.Sql
{
    using System;
    using System.Data;
    using System.Data.SqlClient;

    public static class ExtensionMethods
    {
        #region Methods
        /// <summary>
        /// Build Command
        /// </summary>
        /// <param name="proc">Procedure</param>
        /// <param name="database">Database</param>
        /// <returns>Database Command</returns>
        public static SqlCommand Build(this IStoredProcedure sproc, SqlConnection connection)
        {
            if (null == sproc)
            {
                throw new ArgumentNullException("sproc");
            }
            if (null == connection)
            {
                throw new ArgumentNullException("connection");
            }

            var command = connection.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = sproc.Name;

            foreach (var prop in sproc.GetProperties())
            {
                var mapper = sproc.GetAttribute<DataMapperAttribute>();

                if (mapper != null)
                {
                    var value = prop.GetValue(sproc, null);
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