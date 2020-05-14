using Game.Misc;

namespace Game.Model
{
    public partial class ModelBase
    {
        protected interface IFieldCells
        {
            IFieldCells FieldCells { get; }
            IFieldCell[,] Cells { get; }

            void setCells(int x, int y );

        }

        // ##############################################

        public class FieldCells : IFieldCells
        {
            IFieldCells IFieldCells.FieldCells { get { return this; } }
            IFieldCell[,] myCells;


            // ============ IFieldCells ======================


           IFieldCell[,] IFieldCells.Cells => myCells;

           void IFieldCells.setCells(int x, int y)
            {
                PacManField.Init();

                myCells = new FieldCell[x, y];

                for (int i = 0; i < x; i++)
                {
                    for (int j = 0; j < y; j++)
                    {
                       
                        myCells[i, j] = PacManField.field[i,j] ;
                                                
                    }
                }

               
              
               
            }
        }
    }
}