namespace Game.Model
{
    public partial class ModelBase
    {
        protected interface IGhost
        {
            int X { get; }
            int Y { get; }
        }

        protected interface IGhostWritable : IGhost
        {
            void UpdatePosition(int x, int y);
        }

        protected interface IGhostAnotherWritable : IGhost
        {
            void UpdatePosition(int x, int y);
        }
    }
}