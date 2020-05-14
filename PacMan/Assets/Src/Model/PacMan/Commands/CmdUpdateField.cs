using Game.Misc;

namespace Game.Model
{
    public partial class ModelPacMan
    {
        class CmdUpdateField : ICommand
        {

            // ============== ICommand ================

            void ICommand.Exec(IContextWritable context)
            {
                IPacManWritable pacMan = context.CharactardsContainer.Get<IPacManWritable>();
                context.EventManager.Get<IFieldEventsWritable>().UpdateField(pacMan.X,pacMan.Y);
                
            

            }
        }
    }
}