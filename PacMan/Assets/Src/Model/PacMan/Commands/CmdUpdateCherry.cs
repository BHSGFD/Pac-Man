using Game.Misc;
using UnityEngine;

namespace Game.Model
{
    public partial class ModelPacMan
    {
        class CmdUpdateCherry : ICommand
        {

            // ============== ICommand ================

            void ICommand.Exec(IContextWritable context)
            {
                bool trigger = true;
                (int x, int y) position = (0,0);

                IPacManWritable pacMan = context.CharactardsContainer.Get<IPacManWritable>();
                ICherryWritable cherry = context.CharactardsContainer.Get<ICherryWritable>();

                while (trigger)
                {
                   position  = (Random.Range(0, 16), Random.Range(0, 12));
                    if (context.Field.Cells[position.x, position.y].IsOccupied == true) trigger = false;
                }
                if (pacMan.X == cherry.X && pacMan.Y == cherry.Y)
                {
                    Cherry.EnumCherry = eCherry.isActive;
                    context.CharactardsContainer.Get<ICherryWritable>().UpdatePosition(position.x, position.y);
                    context.EventManager.Get<ICherryEventsWritable>().UpdateCherry(position.x, position.y);
                }



            }
        }
    }
}