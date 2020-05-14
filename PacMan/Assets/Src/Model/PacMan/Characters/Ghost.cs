namespace Game.Model
{
    public partial class ModelPacMan
    {
        protected class Ghost : IGhostWritable, IGhostAnotherWritable
        {
            int _x;
            int _y;


            // =============================

            public Ghost(int x, int y)
            {
                _x = x;
                _y = y;
                
            }

            // ======= IGhost =============

            int IGhost.X => _x;
            int IGhost.Y => _y;
           

            // ====== IGhostWritable =====

            void IGhostWritable.UpdatePosition(int x, int y)
            {
                _x = x;
                _y = y;
            }
            // ====== IGhostAnoterWritable ======

            void IGhostAnotherWritable.UpdatePosition(int x, int y)
            {
                _x = x;
                _y = y;
            }
        }
    }
}