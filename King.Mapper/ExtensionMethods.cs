namespace King.Mapper
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.Dynamic;
    using System.Linq;
    using System.Reflection;
    using System.Threading.Tasks;

    /// <summary>
    /// Extension Methods
    /// </summary>
    public static class ExtensionMethods
    {
        #region System.Object
        /// <summary>
        /// Get Properties
        /// </summary>
        /// <param name="value">Value</param>
        /// <returns>Property Info</returns>
        public static IEnumerable<PropertyInfo> GetProperties(this object value)
        {
            if (null == value)
            {
                throw new ArgumentNullException("value");
            }

            var type = value.GetType();
            return type.GetProperties();
        }

        /// <summary>
        /// Convert Object to Dictionary
        /// </summary>
        /// <param name="value">Object to convert</param>
        /// <returns>Dictionary</returns>
        public static IDictionary<string, object> ToDictionary(this object value, ActionFlags action = ActionFlags.Load)
        {
            if (null == value)
            {
                throw new ArgumentNullException("value");
            }

            return value.ValueMapping(value.Parameters(), action);
        }

        /// <summary>
        /// Parameters
        /// </summary>
        /// <param name="value">Value</param>
        /// <returns>Parameters</returns>
        public static IEnumerable<string> Parameters(this object value)
        {
            if (null == value)
            {
                throw new ArgumentNullException("value");
            }

            return value.GetProperties().Where(p => p.CanWrite).Select(p => p.Name);
        }

        /// <summary>
        /// Get Value Mapping of Object and parameters
        /// </summary>
        /// <param name="value">Object with Values</param>
        /// <param name="parameters">Stored Procedure Parameters</param>
        /// <param name="action">Action</param>
        /// <returns>Mapped Parameters to Values</returns>
        public static IDictionary<string, object> ValueMapping(this object value, IEnumerable<string> parameters, ActionFlags action = ActionFlags.Execute)
        {
            if (null == value)
            {
                throw new ArgumentNullException("value");
            }
            if (null == parameters)
            {
                throw new ArgumentNullException("parameters");
            }

            var row = new Dictionary<string, object>(parameters.Count());
            var columnHash = new HashSet<string>(parameters);

            foreach (var property in value.GetProperties().Where(p => p != null))
            {
                foreach (var actionName in property.GetAttributes<ActionNameAttribute>().Where(p => p.Action == action))
                {
                    var name = actionName.Name.Replace("@", string.Empty);
                    if (!columnHash.Contains(name) && !row.ContainsKey(name))
                    {
                        row.Add(name, property.GetValue(value, null));
                    }
                }

                if (columnHash.Contains(property.Name))
                {
                    row.Add(property.Name, property.GetValue(value, null));
                }
            }

            return row;
        }

        /// <summary>
        /// Fill Object with values from the data store
        /// </summary>
        /// <typeparam name="T">T</typeparam>
        /// <param name="value">Value</param>
        /// <param name="columns">Columns</param>
        /// <param name="values">Values</param>
        /// <param name="action">Action</param>
        public static void Fill(this object value, IEnumerable<string> columns, IEnumerable<object> values, ActionFlags action = ActionFlags.Load)
        {
            if (null == value)
            {
                throw new ArgumentNullException("value");
            }
            if (null == columns)
            {
                throw new ArgumentNullException("columns");
            }
            if (null == values)
            {
                throw new ArgumentNullException("values");
            }
            if (columns.Count() != values.Count())
            {
                throw new ArgumentException("Columns don't match values.");
            }

            var properties = value.GetProperties();

            var propertyDictionary = new Dictionary<string, PropertyInfo>(properties.Count());

            foreach (var property in properties)
            {
                propertyDictionary.Add(property.Name, property);

                foreach (var actionName in property.GetAttributes<ActionNameAttribute>().Where(a => null != a && a.Action == action  && !propertyDictionary.ContainsKey(a.Name)))
                {
                    propertyDictionary.Add(actionName.Name, property);
                }
            }

            for (ushort i = 0; i < columns.Count(); i++)
            {
                if (propertyDictionary.ContainsKey(columns.ElementAt(i)))
                {
                    var property = propertyDictionary[columns.ElementAt(i)];
                    if (null != property)
                    {
                        property.Set(value, values.ElementAt(i));
                    }
                }
            }
        }

        /// <summary>
        /// Map properties from one object to another
        /// </summary>
        /// <typeparam name="T">Type of Secondary Object</typeparam>
        /// <param name="from">From</param>
        /// <param name="to">To</param>
        /// <returns>Object</returns>
        public static T Map<T>(this object from, T to)
        {
            if (null == from)
            {
                throw new ArgumentNullException("from");
            }
            if (null == to)
            {
                throw new ArgumentNullException("to");
            }

            var properties = from.ValueMapping(from.Parameters());
            to.Fill(properties.Keys.ToArray(), properties.Values.ToArray());
            return to;
        }

        /// <summary>
        /// Map properties from one object to another
        /// </summary>
        /// <typeparam name="T">Type of Secondary Object</typeparam>
        /// <param name="from">From</param>
        /// <returns>Object</returns>
        public static T Map<T>(this object from)
        {
            if (null == from)
            {
                throw new ArgumentNullException("from");
            }

            return from.Map<T>(Activator.CreateInstance<T>());
        }

        /// <summary>
        /// Get Attribute
        /// </summary>
        /// <param name="value">Value</param>
        /// <returns>Attribute</returns>
        public static T GetAttribute<T>(this object value)
            where T : Attribute
        {
            if (null == value)
            {
                throw new ArgumentNullException("value");
            }

            var type = value.GetType();
            var attributes = type.GetCustomAttributes(false);
            return attributes.GetAttribute<T>();
        }
        #endregion

        #region System.Object[]
        /// <summary>
        /// Get Attribute
        /// </summary>
        /// <typeparam name="T">Attribute Type</typeparam>
        /// <param name="attributes">Attributes</param>
        /// <returns>Attribute of Type</returns>
        public static T GetAttribute<T>(this object[] attributes)
            where T : Attribute
        {
            if (null == attributes)
            {
                throw new ArgumentNullException("attributes");
            }

            return (from item in attributes
                    where item.GetType() == typeof(T)
                    select item as T).FirstOrDefault();
        }
        #endregion

        #region System.Reflection.PropertyInfo
        /// <summary>
        /// Get Attribute
        /// </summary>
        /// <typeparam name="T">Attribute Type</typeparam>
        /// <param name="attributes">Attributes</param>
        /// <returns>Attribute of Type</returns>
        public static IEnumerable<T> GetAttributes<T>(this PropertyInfo property)
            where T : Attribute
        {
            if (null == property)
            {
                throw new ArgumentNullException("property");
            }

            return property.GetCustomAttributes(false).Where(p => p.GetType() == typeof(T)).Select(p => (T)p);
        }

        /// <summary>
        /// Get Attribute
        /// </summary>
        /// <typeparam name="T">Attribute Type</typeparam>
        /// <param name="attributes">Attributes</param>
        /// <returns>Attribute of Type</returns>
        public static T GetAttribute<T>(this PropertyInfo property)
            where T : Attribute
        {
            if (null == property)
            {
                throw new ArgumentNullException("property");
            }

            return property.GetAttributes<T>().FirstOrDefault();
        }

        /// <summary>
        /// Set Value of Property
        /// </summary>
        /// <param name="property">Property</param>
        /// <param name="value">Value</param>
        public static void Set(this PropertyInfo property, object owner, object value = null)
        {
            if (null == property)
            {
                throw new ArgumentNullException("property");
            }
            if (null == owner)
            {
                throw new ArgumentNullException("owner");
            }

            if (property.CanWrite)
            {
                object ptr = null;
                if (DBNull.Value != value && null != value)
                {
                    if (property.PropertyType.BaseType == typeof(Enum))
                    {
                        ptr = Enum.ToObject(property.PropertyType, value);
                    }
                    else if (value as IConvertible != null)
                    {
                        var t = Nullable.GetUnderlyingType(property.PropertyType) ?? property.PropertyType;
                        ptr = Convert.ChangeType(value, t);
                    }
                    else
                    {
                        ptr = value;
                    }
                }

                property.SetValue(owner, ptr, null);
            }
        }
        #endregion

        #region System.Collections.IDictionary
        /// <summary>
        /// Map type from Dictionary
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="dictionary">Dictionary</param>
        /// <param name="action">Action</param>
        /// <returns>Type</returns>
        public static T Map<T>(this IDictionary<string, object> dictionary, ActionFlags action = ActionFlags.Load)
        {
            if (null == dictionary)
            {
                throw new ArgumentNullException("dictionary");
            }

            var obj = Activator.CreateInstance<T>();
            obj.Fill(dictionary.Keys.ToArray(), dictionary.Values.ToArray(), action);
            return obj;
        }

        /// <summary>
        /// Map type from Dictionary
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="dictionary">Dictionary</param>
        /// <returns>Type</returns>
        public static dynamic Map(this IDictionary<string, object> dictionary)
        {
            if (null == dictionary)
            {
                throw new ArgumentNullException("dictionary");
            }

            var obj = new ExpandoObject() as IDictionary<string, object>;

            foreach (var key in dictionary.Keys)
            {
                obj.Add(key, dictionary[key]);
            }

            return obj;
        }
        #endregion

        #region System.Collections.Specialized.NameValueCollection
        /// <summary>
        /// Map object to Name Value Collection
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="dictionary">Dictionary</param>
        /// <param name="action">Action</param>
        /// <returns>Type</returns>
        public static T Map<T>(this NameValueCollection dictionary, ActionFlags action = ActionFlags.Load)
        {
            if (null == dictionary)
            {
                throw new ArgumentNullException("dictionary");
            }

            var obj = Activator.CreateInstance<T>();
            if (dictionary.HasKeys())
            {
                var values = dictionary.AllKeys.Select(d => dictionary[d]);
                obj.Fill(dictionary.AllKeys, values, action);
            }

            return obj;
        }
        #endregion
    }
}