namespace Game.Model
{
    public delegate void dCreateField(int x, int y);
    public delegate void dUpdateField(int x, int y);
    public delegate void dSetWinCount(int count);

    public interface IFieldEvents
    {
        event dCreateField OnCreateField;
        event dUpdateField OnUpdateField;
        event dSetWinCount OnCountSet;
    }

    public interface IFieldEventsWritable
    {
        void CreateField(int x, int y);
        void UpdateField(int x, int y);
        void SetWinCount(int count);
    }

    // #############################################

    class FieldEvents : IFieldEvents, IFieldEventsWritable
    {
        // ========= IFieldEvents ================

        public event dCreateField OnCreateField;
        public event dUpdateField OnUpdateField;
        public event dSetWinCount OnCountSet;

        // =========  IFieldEventsWritable =========

        void IFieldEventsWritable.CreateField (int x, int y)
        { OnCreateField?.Invoke(x,y); }

        void IFieldEventsWritable.UpdateField(int x, int y)
        { OnUpdateField?.Invoke(x, y); }

        void IFieldEventsWritable.SetWinCount(int count)
        {
            OnCountSet?.Invoke(count);
        }
    }
}
