namespace Game.Model
{
    public delegate void dCreateCherry(int x, int y);
    public delegate void dUpdateCherry(int x, int y);


    public interface ICherryEvents
    {
        event dCreateCherry OnCreateCherry;
        event dUpdateCherry OnUpdateCherry;
    }

    public interface ICherryEventsWritable
    {
        void CreateCherry(int x, int y);
        void UpdateCherry(int x, int y);
    }

    // #############################################

    class CherryEvents : ICherryEvents, ICherryEventsWritable
    {
        // ========= ICherryEvents ================

        public event  dCreateCherry OnCreateCherry;
        public event  dUpdateCherry OnUpdateCherry;

        // ========= ICherryEventsWritable =========

        void ICherryEventsWritable.CreateCherry(int x, int y)
        { OnCreateCherry?.Invoke(x, y); }

        void ICherryEventsWritable.UpdateCherry(int x, int y)
        { OnUpdateCherry?.Invoke(x, y); }
    }
}
