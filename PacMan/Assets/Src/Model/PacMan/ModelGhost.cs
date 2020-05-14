namespace Game.Model
{


    public partial class ModelPacMan
    {

        // ============== Ghost =================



        void IModelPacMan.InitGhost()
        {

            CreateAndExecuteTurn(
                (ITurn turn) =>
                {

                    turn.Push(new CmdCreateGhost(5,5));
                });
        }

        void IModelPacMan.UpdateGhost()
        {
            CreateAndExecuteTurn(
                (ITurn turn) =>
                {
                    turn.Push(new CmdMoveGhost());
                });
        }

    }
}

