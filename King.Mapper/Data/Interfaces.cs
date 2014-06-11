namespace King.Mapper.Data
{
    using System.Collections.Generic;

    public interface IReaderLoader<T>
    {
        IList<T> LoadObjects(ActionFlags action = ActionFlags.Load);
    }
}