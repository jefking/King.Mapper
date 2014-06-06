namespace King.Mapper.Data
{
    using System;
    using System.Linq;
    using System.Collections;
    using System.Collections.Generic;
    using System.Data;
    using System.Diagnostics;

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
        /// <param name="defaultValue">Default Value</param>
        /// <returns>Value</returns>
        public static T Get<T>(this IDataRecord record, string column, T defaultValue = default(T))
        {
            if (null == record)
            {
                throw new ArgumentNullException("record");
            }
            
            if (string.IsNullOrWhiteSpace(column))
            {
                throw new ArgumentOutOfRangeException("column");
            }
            
            try
            {
                if (record[column].IsNotNull())
                {
                    return (T)Convert.ChangeType(record[column], typeof(T));
                }
            }
            catch (IndexOutOfRangeException iorex)
            {
                Trace.TraceInformation(string.Format("{0}", iorex.Message));
            }
            catch (ArgumentException aex)
            {
                Trace.TraceWarning(string.Format("{0}", aex.Message));
            }

            return defaultValue;
        }
        #endregion

        #region System.Data.DataSet
        /// <summary>
        /// Load Object from Data Set
        /// </summary>
        /// <typeparam name="T">T</typeparam>
        /// <param name="ds">Data Set</param>
        /// <param name="action">Action</param>
        /// <returns>Object</returns>
        public static T LoadObject<T>(this DataSet ds, ActionFlags action = ActionFlags.Load)
            where T : new()
        {
            if (null == ds)
            {
                throw new ArgumentNullException("ds");
            }

            var value = default(T);

            if (ds.Tables.Count > 0)
            {
                value = ds.Tables[0].LoadObject<T>(action);
            }

            return value;
        }

        /// <summary>
        /// Load Object from Data Set
        /// </summary>
        /// <typeparam name="T">T</typeparam>
        /// <param name="ds">Data Set</param>
        /// <param name="action">Action</param>
        /// <returns>Object</returns>
        public static IList<T> LoadObjects<T>(this DataSet ds, ActionFlags action = ActionFlags.Load)
            where T : new()
        {
            if (null == ds)
            {
                throw new ArgumentNullException("ds");
            }

            var values = new List<T>();
            foreach (DataTable table in ds.Tables)
            {
                values.AddRange(table.LoadObjects<T>(action));
            }

            return values;
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
        public static T LoadObject<T>(this DataTable table, ActionFlags action = ActionFlags.Load)
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
        public static IList<T> LoadObjects<T>(this DataTable table, ActionFlags action = ActionFlags.Load)
            where T : new()
        {
            if (null == table)
            {
                throw new ArgumentNullException("table");
            }

            return table.LoadObject<List<T>>(action);
        }
        #endregion

        #region System.Data.DataColumnCollection
        /// <summary>
        /// Data Column Collection to Array
        /// </summary>
        /// <param name="columns">Columns</param>
        /// <returns>Column Name Array</returns>
        public static string[] ToArray(this DataColumnCollection columns)
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
        /// Load Object from IData Reader
        /// </summary>
        /// <typeparam name="T">Type to Load</typeparam>
        /// <param name="reader">Data Reader</param>
        /// <param name="action">Load Action</param>
        /// <returns>Object of T</returns>
        public static T LoadObject<T>(this IDataReader reader, ActionFlags action = ActionFlags.Load)
        {
            if (null == reader)
            {
                throw new ArgumentNullException("reader");
            }
            
            var obj = Activator.CreateInstance<T>();

            var columns = reader.GetFieldNames();
            var values = new object[columns.Length];
            reader.GetValues(values);

            obj.Fill(columns, values, action);

            return obj;
        }

        /// <summary>
        /// Get Field Names
        /// </summary>
        /// <param name="reader">Reader</param>
        /// <returns>Field Names</returns>
        public static string[] GetFieldNames(this IDataReader reader)
        {
            if (null == reader)
            {
                throw new ArgumentNullException("reader");
            }

            var fields = new string[reader.FieldCount];
            for (int i = 0; i < fields.Count(); i++)
            {
                fields[i] = reader.GetName(i);
            }

            return fields;
        }
        
        /// <summary>
        /// Load Objects from IData Reader
        /// </summary>
        /// <typeparam name="T">Type to Load</typeparam>
        /// <param name="reader">Data Reader</param>
        /// <param name="action">Load Action</param>
        /// <returns>Objects of T</returns>
        public static IList<T> LoadObjects<T>(this IDataReader reader, ActionFlags action = ActionFlags.Load)
           where T : new()
        {
            if (null == reader)
            {
                throw new ArgumentNullException("reader");
            }

            var values = new List<T>();
            while (reader.Read())
            {
                values.Add(reader.LoadObject<T>(action));
            }

            return values;
        }
        #endregion
    }
}