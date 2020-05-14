using Game.Misc;

namespace Game.Model
{
  

    public partial class ModelPacMan
{
  

        // ============== GameField =================

      

        void IModelPacMan.InitField()
        {
            
            CreateAndExecuteTurn(
                (ITurn turn) =>
                {
                    
                    turn.Push(new CmdCreateField());
                });
        }

        void IModelPacMan.UpdateField()
        {
            CreateAndExecuteTurn(
                (ITurn turn) =>
                {
                    turn.Push(new CmdUpdateField());
                });
        }
    
}
}

