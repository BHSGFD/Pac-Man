namespace Game.Model
{
    public partial class ModelPacMan
    {
        protected class CherryObj : ICherryWritable
        {
            int _x;
            int _y;
            // =============================

            public CherryObj(int x, int y)
            {
                _x = x;
                _y = y;
            }

            // ======= ICherry =============
            int ICherry.X => _x;
            int ICherry.Y => _y;

            // ====== ICharacterWritable ==

            void ICherryWritable.UpdatePosition(int x, int y)
            {
                _x = x;
                _y = y;
            }
        }
    }
}