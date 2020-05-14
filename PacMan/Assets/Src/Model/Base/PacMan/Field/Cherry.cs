namespace Game.Model
{
    public partial class ModelBase
    {
        protected interface ICherry
        {
            int X { get; }
            int Y { get; }
        }

        protected interface ICherryWritable : ICherry
        {
            void UpdatePosition(int x, int y);
        }
    }
}