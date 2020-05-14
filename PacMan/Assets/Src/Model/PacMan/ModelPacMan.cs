using Game.Misc;

namespace Game.Model
{
    public interface IModelPacMan 
    {
        IEventManager EventManager { get; }

        void Init();
        void Update(eDirection direction);
        void InitField();
        void UpdateField();
        void InitGhost();
        void UpdateGhost();
        void InitCherry();
        void UpdateCherrry();
    }

    // ##################################################

    public partial class ModelPacMan : ModelBase, IModelPacMan
    {
        protected override void RegisterEvents(IEventManagerInternal eventManager)
        {eventManager.Register<IPacManEvents, IPacManEventsWritable>(new PacManEvents());
         eventManager.Register<IFieldEvents, IFieldEventsWritable>(new FieldEvents());
         eventManager.Register<IGhostEvents, IGhostEventsWritable>(new GhostEvents());
         eventManager.Register<ICherryEvents, ICherryEventsWritable>(new CherryEvents());
        }

        // ============== IModelPacMan =================

        IEventManager IModelPacMan.EventManager => EventManager;

        void IModelPacMan.Init()
        {
          
            CreateAndExecuteTurn(
                (ITurn turn) =>
                {
                   
                    turn.Push(new CmdCreatePacMan(0, 0));
                });
        }

        void IModelPacMan.Update(eDirection direction)
        {
            CreateAndExecuteTurn(
                (ITurn turn) =>
                {
                    turn.Push(new CmdMovePacMan(direction));
                });
        }
    }
}