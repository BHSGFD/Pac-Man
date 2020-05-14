namespace Game.Model
{


    public partial class ModelPacMan
    {

        // ============== Cherry =================



        void IModelPacMan.InitCherry()
        {

            CreateAndExecuteTurn(
                (ITurn turn) =>
                {

                    turn.Push(new CmdCreateCherry(10, 5));
                });
        }

        void IModelPacMan.UpdateCherrry()
        {
            CreateAndExecuteTurn(
                (ITurn turn) =>
                {
                    turn.Push(new CmdUpdateCherry());
                });
        }

    }
}

