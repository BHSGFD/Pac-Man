using Game.Misc;

namespace Game.Model
{
    public partial class ModelBase
    {
        protected interface IField  : IFieldCells
        {
            int Width { get; }
            int Height { get; }
            IFieldCell[,] cells { get; }

            int winCount { get; set; }
            bool IsCanMove(int x, int y, eDirection direction);
        }

        // ##############################################

        public class Field : FieldCells, IField
        {
            IField IField { get { return this; } }



            public Field()
            {
                IField.FieldCells.setCells(16, 12);
            }

            
            
            bool IsOutOfRange(int x, int y, eDirection direction)
            {
                return x < 0 || y < 0 || x >= IField.Width || y >= IField.Height || IField.FieldCells.Cells[x, y].First == direction || IField.FieldCells.Cells[x, y].Second == direction; }

            // ============ IField ======================

           

            IFieldCell[,] IField.cells { get { return IField.Cells; } }

            int IField.Width => 16;
            int IField.Height => 12;

            int IField.winCount { get; set; }

            bool IField.IsCanMove(int x, int y, eDirection direction)
            {
                (int x, int y) nextPositon = Direction.GetNextPosition(x, y, direction);
                return !IsOutOfRange(nextPositon.x, nextPositon.y, direction);
            }
        }
    }
}