using Game.Misc;

namespace Game.Model
{
    public partial class ModelPacMan
    {
        class CmdCreateField: ICommand
        {
           

            int _X;
            int _Y;

            // ============== ICommand ================

            void ICommand.Exec(IContextWritable context)
            {
                context.Field.winCount = 0;

                for (int i =0; i < 16; i++)
                {
                    for (int j = 0; j < 12; j++) {
                        if (context.Field.Cells[i, j].IsOccupied == false)
                        {
                            context.Field.winCount += 1;
                            
                            context.CharactardsContainer.Add<IGameField>(new GameField(i , j));
                            context.EventManager.Get<IFieldEventsWritable>().CreateField(i, j);
                        }
                    }
                }
                context.EventManager.Get<IFieldEventsWritable>().SetWinCount(context.Field.winCount);
              
            }
        }
    }
}