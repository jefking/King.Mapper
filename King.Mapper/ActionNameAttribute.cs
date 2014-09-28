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
        protected ActionFlags action;

        /// <summary>
        /// Name
        /// </summary>
        protected string name;
        #endregion

        #region Constructors
        /// <summary>
        /// Action Name Attribute constructor
        /// </summary>
        /// <param name="name">Name</param>
        /// <param name="action">Action</param>
        public ActionNameAttribute(string name, ActionFlags action = ActionFlags.Load)
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
        public virtual string Name
        {
            get
            {
                return this.name;
            }
        }

        /// <summary>
        /// Action
        /// </summary>
        public virtual ActionFlags Action
        {
            get
            {
                return this.action;
            }
        }
        #endregion
    }
}