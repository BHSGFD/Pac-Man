using Game.Misc;

namespace Game.Model
{
    public partial class ModelBase
    {
        protected interface IFieldCell
        {
            eDirection First { get; }
            eDirection Second { get; }
          
            int X { get; }
            int Y { get; }
            
            void SetEmployment(bool Boolean);
            bool IsOccupied { get; }

        }

        // ##############################################


        public class FieldCell : IFieldCell
        {



            bool Occupied = false;

            public eDirection myDirectionFirst = eDirection.NONE;
            public eDirection myDirectionSecond = eDirection.NONE;

            int myX;
            int myY;

            public FieldCell(int x, int y)
            {
                myX = x;
                myY = y;
            }

            // ============ IFieldCell ======================

          
           public void  SetWall(eDirection first, eDirection second)
            {
                myDirectionFirst = first;
                myDirectionSecond = second;
            }

           
            public void SetWall(eDirection first)
            {
                myDirectionFirst = first;
            }

            bool IFieldCell.IsOccupied => Occupied;

            void IFieldCell.SetEmployment(bool Boolean)
            {
                Occupied = Boolean;
            }


            eDirection IFieldCell.First => myDirectionFirst;
            eDirection IFieldCell.Second => myDirectionSecond;
            int IFieldCell.X => myX;
            int IFieldCell.Y => myY;
        }
    }
}