namespace Game.Model
{
    public delegate void dCreatePacMan(int x, int y);
    public delegate void dUpdatePacManPosition(int x, int y);


    public interface IPacManEvents
    {
        event dCreatePacMan OnCreatePacMan;
        event dUpdatePacManPosition OnUpdatePacManPosition;
    }

    public interface IPacManEventsWritable
    {
        void CreatePacMan(int x, int y);
        void UpdatePacManPosition(int x, int y);
    }

    // #############################################

    class PacManEvents : IPacManEvents, IPacManEventsWritable
    {
        // ========= IPacManEvents ================

        public event dCreatePacMan OnCreatePacMan;
        public event dUpdatePacManPosition OnUpdatePacManPosition;

        // ========= IPacManEventsWritable =========

        void IPacManEventsWritable.CreatePacMan(int x, int y)
        { OnCreatePacMan?.Invoke(x, y); }

        void IPacManEventsWritable.UpdatePacManPosition(int x, int y)
        { OnUpdatePacManPosition?.Invoke(x, y); }
    }
}
