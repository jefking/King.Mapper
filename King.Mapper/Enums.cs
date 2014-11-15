namespace King.Mapper
{
    using System;

    #region Action
    /// <summary>
    /// Action Flags
    /// </summary>
    [Flags]
    public enum ActionFlags : byte
    {
        /// <summary>
        /// During Execution
        /// </summary>
        Execute = 0,
        /// <summary>
        /// During Load
        /// </summary>
        Load = 1
    }
    #endregion
}