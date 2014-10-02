﻿namespace King.Mapper.Data
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.Dynamic;
    using System.Linq;
    using System.Threading.Tasks;

    public static class ExtensionMethods
    {
        #region System.Object
        /// <summary>
        /// Is the object a valid one
        /// </summary>
        /// <param name="obj">the object to validate</param>
        /// <returns>true if valid, false otherwise</returns>
        public static bool IsNotNull(this object obj)
        {
            return obj != null && obj != DBNull.Value;
        }
        #endregion

        #region System.Data.IDataRecord
        /// <summary>
        /// Get Value
        /// </summary>
        /// <typeparam name="T">Type Value</typeparam>
        /// <param name="record">Row</param>
        /// <param name="column">Column</param>
        /// <param name="value">Default Value</param>
        /// <returns>Value</returns>
        public static T Get<T>(this IDataRecord record, string column, T value = default(T))
        {
            if (null == record)
            {
                throw new ArgumentNullException("record");
            }
            if (string.IsNullOrWhiteSpace(column))
            {
                throw new ArgumentException("column");
            }

            return record[column].IsNotNull() ? (T)Convert.ChangeType(record[column], typeof(T)) : value;
        }
        #endregion

        #region System.Data.DataSet
        /// <summary>
        /// Load Model from Data Set
        /// </summary>
        /// <typeparam name="T">T</typeparam>
        /// <param name="ds">Data Set</param>
        /// <param name="action">Action</param>
        /// <returns>Model</returns>
        public static T Model<T>(this DataSet ds, ActionFlags action = ActionFlags.Load)
            where T : new()
        {
            if (null == ds)
            {
                throw new ArgumentNullException("ds");
            }

            return ds.Tables.Count > 0 ? ds.Tables[0].Model<T>(action) : default(T);
        }

        /// <summary>
        /// Load Models from Data Set
        /// </summary>
        /// <typeparam name="T">T</typeparam>
        /// <param name="ds">Data Set</param>
        /// <param name="action">Action</param>
        /// <returns>Models</returns>
        public static IEnumerable<T> Models<T>(this DataSet ds, ActionFlags action = ActionFlags.Load)
            where T : new()
        {
            if (null == ds)
            {
                throw new ArgumentNullException("ds");
            }

            return null != ds.Tables[0] ? ds.Tables[0].Models<T>(action) : new List<T>();
        }

        /// <summary>
        /// Load Object from Data Set
        /// </summary>
        /// <typeparam name="T">T</typeparam>
        /// <param name="ds">Data Set</param>
        /// <param name="action">Action</param>
        /// <returns>Dictionary</returns>
        public static IDictionary<string, object> Dictionary(this DataSet ds)
        {
            if (null == ds)
            {
                throw new ArgumentNullException("ds");
            }

            return ds.Tables.Count > 0 ? ds.Tables[0].Dictionary() : new Dictionary<string, object>(0);
        }

        /// <summary>
        /// Load Ditionaries from Data Set
        /// </summary>
        /// <param name="ds">Data Set</param>
        /// <returns>Dictionaries</returns>
        public static IEnumerable<IDictionary<string, object>> Dictionaries(this DataSet ds)
        {
            if (null == ds)
            {
                throw new ArgumentNullException("ds");
            }

            return null != ds.Tables[0] ? ds.Tables[0].Dictionaries() : new List<IDictionary<string, object>>(0);
        }
        #endregion

        #region System.Data.DataTable
        /// <summary>
        /// Load Object from Data Table
        /// </summary>
        /// <typeparam name="T">T</typeparam>
        /// <param name="table">Data Table</param>
        /// <param name="action">Action</param>
        /// <returns>Object</returns>
        public static T Model<T>(this DataTable table, ActionFlags action = ActionFlags.Load)
            where T : new()
        {
            if (null == table)
            {
                throw new ArgumentNullException("table");
            }

            var type = typeof(T);
            T value = Activator.CreateInstance<T>();
            Type createType;
            var isEnumerable = type.IsGenericType && value is IEnumerable;

            if (isEnumerable)
            {
                createType = type.GetGenericArguments()[0];
            }
            else
            {
                value = default(T);
                createType = type;
            }

            var list = value as IList;
            var columns = table.Columns.ToArray();
            foreach (DataRow row in table.Rows)
            {
                var instance = Activator.CreateInstance(createType);

                instance.Fill(columns, row.ItemArray, action);

                if (isEnumerable)
                {
                    if (null != list)
                    {
                        list.Add(instance);
                    }
                }
                else
                {
                    return (T)instance;
                }
            }

            return value;
        }

        /// <summary>
        /// Load Object from Data Table
        /// </summary>
        /// <typeparam name="T">T</typeparam>
        /// <param name="table">Data Table</param>
        /// <param name="action">Action</param>
        /// <returns>Object</returns>
        public static IEnumerable<T> Models<T>(this DataTable table, ActionFlags action = ActionFlags.Load)
            where T : new()
        {
            if (null == table)
            {
                throw new ArgumentNullException("table");
            }

            return table.Model<List<T>>(action);
        }

        /// <summary>
        /// Load Dictionary from Data Table
        /// </summary>
        /// <param name="table">Data Table</param>
        /// <returns>Dictionary</returns>
        public static IDictionary<string, object> Dictionary(this DataTable table)
        {
            if (null == table)
            {
                throw new ArgumentNullException("table");
            }

            return table.Dynamic() as IDictionary<string, object>;
        }

        /// <summary>
        /// Load Dictionaries from Data Table
        /// </summary>
        /// <param name="table">Data Table</param>
        /// <returns>Dictionaries</returns>
        public static IEnumerable<IDictionary<string, object>> Dictionaries(this DataTable table)
        {
            if (null == table)
            {
                throw new ArgumentNullException("table");
            }

            return table.Dynamics() as IEnumerable<IDictionary<string, object>>;
        }

        /// <summary>
        /// Load Dynamic from Data Table
        /// </summary>
        /// <param name="table">Data Table</param>
        /// <returns>Dynamic</returns>
        public static IDictionary<string, object> Dynamic(this DataTable table)
        {
            if (null == table)
            {
                throw new ArgumentNullException("table");
            }

            var dic = new ExpandoObject() as IDictionary<string, object>;

            var row = table.Rows[0];
            foreach (var col in table.Columns.ToArray())
            {
                dic.Add(col, row[col]);
            }

            return dic;
        }

        /// <summary>
        /// Load Dictionaries from Data Table
        /// </summary>
        /// <param name="table">Data Table</param>
        /// <returns>Dictionaries</returns>
        public static IEnumerable<dynamic> Dynamics(this DataTable table)
        {
            if (null == table)
            {
                throw new ArgumentNullException("table");
            }

            var columns = table.Columns.ToArray();
            var list = new List<IDictionary<string, object>>(table.Rows.Count);
            foreach (DataRow row in table.Rows)
            {
                var dic = new ExpandoObject() as IDictionary<string, object>;

                foreach (var col in columns)
                {
                    dic.Add(col, row[col]);
                }

                list.Add(dic);
            }

            return list;
        }
        #endregion

        #region System.Data.DataColumnCollection
        /// <summary>
        /// Data Column Collection to Array
        /// </summary>
        /// <param name="columns">Columns</param>
        /// <returns>Column Name Array</returns>
        public static IEnumerable<string> ToArray(this DataColumnCollection columns)
        {
            if (null == columns)
            {
                throw new ArgumentNullException("columns");
            }
            
            var cols = new string[columns.Count];
            for (var i = 0; i < cols.Length; i++)
            {
                cols[i] = columns[i].ColumnName;
            }

            return cols;
        }
        #endregion

        #region System.Data.IDataReader
        /// <summary>
        /// Get Field Names
        /// </summary>
        /// <param name="reader">Reader</param>
        /// <returns>Field Names</returns>
        public static IEnumerable<string> GetFieldNames(this IDataReader reader)
        {
            if (null == reader)
            {
                throw new ArgumentNullException("reader");
            }

            var fields = new string[reader.FieldCount];
            for (var i = 0; i < fields.Count(); i++)
            {
                fields[i] = reader.GetName(i);
            }

            return fields;
        }

        /// <summary>
        /// Load Model from IData Reader
        /// </summary>
        /// <typeparam name="T">Type to Load</typeparam>
        /// <param name="reader">Data Reader</param>
        /// <param name="action">Load Action</param>
        /// <returns>Model of T</returns>
        public static T Model<T>(this IDataReader reader, ActionFlags action = ActionFlags.Load)
        {
            if (null == reader)
            {
                throw new ArgumentNullException("reader");
            }

            var obj = Activator.CreateInstance<T>();

            var columns = reader.GetFieldNames();
            var values = new object[columns.Count()];
            reader.GetValues(values);

            obj.Fill(columns, values, action);

            return obj;
        }

        /// <summary>
        /// Load Models from IData Reader
        /// </summary>
        /// <typeparam name="T">Type to Load</typeparam>
        /// <param name="reader">Data Reader</param>
        /// <param name="action">Load Action</param>
        /// <returns>Models of T</returns>
        public static IEnumerable<T> Models<T>(this IDataReader reader, ActionFlags action = ActionFlags.Load)
           where T : new()
        {
            if (null == reader)
            {
                throw new ArgumentNullException("reader");
            }

            var values = new List<T>();
            while (reader.Read())
            {
                values.Add(reader.Model<T>(action));
            }

            return values;
        }

        /// <summary>
        /// Load Dictionary from IData Reader
        /// </summary>
        /// <param name="reader">Data Reader</param>
        /// <returns>Dictionary</returns>
        public static IDictionary<string, object> Dictionary(this IDataReader reader)
        {
            if (null == reader)
            {
                throw new ArgumentNullException("reader");
            }

            var columns = reader.GetFieldNames();
            var dic = new Dictionary<string, object>(columns.Count());
            foreach (var col in columns)
            {
                dic.Add(col, reader[col]);
            }

            return dic;
        }

        /// <summary>
        /// Load Dictionaries from IData Reader
        /// </summary>
        /// <param name="reader">Data Reader</param>
        /// <param name="action">Load Action</param>
        public static IEnumerable<IDictionary<string, object>> Dictionaries(this IDataReader reader)
        {
            if (null == reader)
            {
                throw new ArgumentNullException("reader");
            }

            var values = new List<IDictionary<string, object>>();
            while (reader.Read())
            {
                values.Add(reader.Dictionary());
            }

            return values;
        }
        #endregion

        #region IStoredProcedure
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
            command.CommandText = sproc.FullyQualifiedName();

            foreach (var prop in sproc.GetProperties())
            {
                var mapper = prop.GetAttribute<DataMapperAttribute>();
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