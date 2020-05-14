namespace Game.Model
{
    public partial class ModelPacMan
    {
        protected class GameField : IGameFieldWritable
        {
            int _x;
            int _y;
            // =============================

            public GameField(int x, int y)
            {
                _x = x;
                _y = y;
            }

            // ======= IGameField =============
            int IGameField.X => _x;
            int IGameField.Y => _y;

            // ====== IGameFieldWritable ==

            void IGameFieldWritable.SetEmploy(int x, int y)
            {
               
            }
        }
    }
}