namespace Game.Model
{
    public delegate void dCreateGhost(int x, int y);
    public delegate void dCreateGhostAnother(int x, int y);
    public delegate void dUpdateGhostPosition(int x, int y);
    public delegate void dUpdateGhostAnotherPosition(int x, int y);
    public delegate void dPlayerDestroed();
    public delegate void dGhostDestroed();
    public delegate void dGhostAnotherDestroed();


    public interface IGhostEvents
    {
        event dCreateGhost OnCreateGhost;
        event dCreateGhostAnother OnCreateGhostAnother;
        event dUpdateGhostPosition OnUpdateGhostPosition;
        event dUpdateGhostAnotherPosition OnUpdateGhostAnotherPosition;
        event dPlayerDestroed OnPlayerDestroyed;
        event dGhostDestroed OnGhostDestroyed;
        event dGhostAnotherDestroed OnGhostAnotherDestroyed;


    }

    public interface IGhostEventsWritable
    {
        void CreateGhost(int x, int y);
        void CreateGhostAnother(int x, int y);
        void UpdateGhostPosition(int x, int y);
        void UpdateGhostAnotherPosition(int x, int y);
        void PlayerDestroyed();
        void GhostDestroyed();
        void GhostAnootherDestroyed();

    }

    // #############################################

    class GhostEvents : IGhostEvents, IGhostEventsWritable
    {
        // ========= IGhostEvents ================

        public event dCreateGhost OnCreateGhost;
        public event dCreateGhostAnother OnCreateGhostAnother;
        public event dUpdateGhostPosition OnUpdateGhostPosition;
        public event dUpdateGhostAnotherPosition OnUpdateGhostAnotherPosition;
        public event dPlayerDestroed OnPlayerDestroyed;
        public event dGhostDestroed OnGhostDestroyed;
        public event dGhostAnotherDestroed OnGhostAnotherDestroyed;


        // ========= IGhostEventsWritable =========

        void IGhostEventsWritable.CreateGhost(int x, int y)
        { OnCreateGhost?.Invoke(x, y); }

        void IGhostEventsWritable.CreateGhostAnother(int x, int y)
        { OnCreateGhostAnother?.Invoke(x, y); }

        void IGhostEventsWritable.UpdateGhostPosition(int x, int y)
        { OnUpdateGhostPosition?.Invoke(x, y); }

        void IGhostEventsWritable.UpdateGhostAnotherPosition(int x, int y)
        { OnUpdateGhostAnotherPosition?.Invoke(x, y); }

        void IGhostEventsWritable.PlayerDestroyed()
        { OnPlayerDestroyed?.Invoke(); }

        void IGhostEventsWritable.GhostDestroyed()
        { OnGhostDestroyed?.Invoke(); }

        void IGhostEventsWritable.GhostAnootherDestroyed()
        { OnGhostAnotherDestroyed?.Invoke(); }
    }
}
