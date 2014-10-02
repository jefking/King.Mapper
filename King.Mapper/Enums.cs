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
        Execute = 0,
        Load = 1
    }
    #endregion
}