namespace King.Mapper
{
    using System;

    /// <summary>
    /// Action Naming
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true, Inherited = true)]
    public class ActionNameAttribute : Attribute
    {
        #region Members
        /// <summary>
        /// Action
        /// </summary>
        private ActionFlags action;

        /// <summary>
        /// Name
        /// </summary>
        private string name;
        #endregion

        #region Constructors
        /// <summary>
        /// Action Name Attribute constructor
        /// </summary>
        /// <param name="action">Action</param>
        /// <param name="name">Name</param>
        public ActionNameAttribute(ActionFlags action, string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("name parameter is invalid");
            }

            this.action = action;
            this.name = name;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Name
        /// </summary>
        public string Name
        {
            get
            {
                return this.name;
            }
        }

        /// <summary>
        /// Action
        /// </summary>
        public ActionFlags Action
        {
            get
            {
                return this.action;
            }
        }
        #endregion
    }
}