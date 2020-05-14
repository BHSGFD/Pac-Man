using Game.Misc;

namespace Game.Model
{
    public partial class ModelPacMan
    {
        class CmdCreateGhost : ICommand
        {
            int _x;
            int _y;

            // ========================================

            public CmdCreateGhost(int x, int y)
            {

                _x = x;
                _y = y;
            }

            // ============== ICommand ================

            void ICommand.Exec(IContextWritable context)
            {

                context.Field.cells[_x, _y].SetEmployment(true);
                context.Field.cells[_x - 1, _y - 2].SetEmployment(true);

                context.CharactardsContainer.Add<IGhostWritable>(new Ghost(_x, _y));
                context.CharactardsContainer.Add<IGhostAnotherWritable>(new Ghost(_x - 1, _y - 2));

                context.EventManager.Get<IGhostEventsWritable>().CreateGhost(_x, _y);
                context.EventManager.Get<IGhostEventsWritable>().CreateGhostAnother(_x-1, _y-2);
            }
        }
    }
}