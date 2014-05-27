namespace King.Mapper
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Extension Methods
    /// </summary>
    public static class ExtensionMethods
    {
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
            return (T)(from item in attributes
                       where item.GetType() == typeof(T)
                       select item).FirstOrDefault();
        }
        #endregion

        #region System.Reflection.PropertyInfo
        /// <summary>
        /// Get Attribute from Property Info
        /// </summary>
        /// <typeparam name="T">Attribute</typeparam>
        /// <param name="value">Value</param>
        /// <returns>Attribute</returns>
        public static T GetAttribute<T>(this PropertyInfo value)
            where T : Attribute
        {
            var attributes = value.GetCustomAttributes(false);

            return attributes.GetAttribute<T>();
        }

        /// <summary>
        /// Get Attribute
        /// </summary>
        /// <typeparam name="T">Attribute Type</typeparam>
        /// <param name="attributes">Attributes</param>
        /// <returns>Attribute of Type</returns>
        public static IEnumerable<T> GetAttributes<T>(this PropertyInfo property)
            where T : Attribute
        {
            var enumeration = new List<T>();

            foreach (var obj in property.GetCustomAttributes(false))
            {
                if (obj.GetType() == typeof(T))
                {
                    enumeration.Add((T)obj);
                }
            }

            return enumeration;
        }

        /// <summary>
        /// Set Value of Property
        /// </summary>
        /// <param name="property">Property</param>
        /// <param name="value">Value</param>
        public static void Set(this PropertyInfo property, object owner, object value = null)
        {
            if (null == owner)
            {
                throw new ArgumentNullException("owner");
            }
            else
            {
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
        }
        #endregion
    }
}
