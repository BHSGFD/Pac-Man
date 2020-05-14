namespace Game.Model
{
    public partial class ModelBase
    {
        protected interface IGameField
        {
            int X { get; }
            int Y { get; }
        }

        protected interface IGameFieldWritable : IGameField
        {
            void SetEmploy(int x, int y);
        }
    }
}