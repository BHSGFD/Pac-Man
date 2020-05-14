namespace Game.Model
{
    public partial class ModelPacMan
    {
        protected class PacMan : IPacManWritable
        {
            int _x;
            int _y;

            // =============================

            public PacMan(int x, int y)
            {
                _x = x;
                _y = y;
            }

            // ======= IPacMan =============

            int IPacMan.X => _x;
            int IPacMan.Y => _y;

            // ====== IPacManWritable ====

            void IPacManWritable.UpdatePosition(int x, int y)
            {
                _x = x;
                _y = y;
            }
        }
    }
}