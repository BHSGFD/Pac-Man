using Game.Misc;

namespace Game.Model
{
    public partial class ModelPacMan
    {
        class CmdCreateCherry : ICommand
        {
            int _x;
            int _y;

            // ========================================

            public CmdCreateCherry(int x, int y)
            {

                _x = x;
                _y = y;
            }

            // ============== ICommand ================

            void ICommand.Exec(IContextWritable context)
            {

                context.Field.cells[_x, _y].SetEmployment(true);
                context.CharactardsContainer.Add<ICherryWritable>(new CherryObj(_x, _y));
                context.EventManager.Get<ICherryEventsWritable>().CreateCherry(_x, _y);
            }
        }
    }
}