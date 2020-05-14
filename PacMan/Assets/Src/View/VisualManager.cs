using UnityEngine;

namespace Game.View
{
    public interface IVisualManager
    {
        void Init(Model.IEventManager pacManEventManger, float iterationTime);
    }

    // #################################################

    public class VisualManager : MonoBehaviour, IVisualManager
    {
        [SerializeField]
        Transform _gameObjectsParent;
        [SerializeField]
        CharactersFactory _charactersFactory;
        [SerializeField]
        PositionManager _positionManager;
        [SerializeField]
        UIManger _uiManager;


        int X=0;
        float _iterationTime;
        IPacMan _pacMan;
        IGhost _ghost;
        IGhost _ghostAnother;
        ICherry _cherry;
        //доделать
        IGameField[,] gameField  = new IGameField[16,12];
        int _winCount;

        // =============================================

        ICharactersFactory CharactersFactory => _charactersFactory;
        IPositionManager PositionManager => _positionManager;

        // ============ IVisualManager =================

        void IVisualManager.Init(Model.IEventManager pacManEventManger, float iterationTime)
        {
            _iterationTime = iterationTime;

            pacManEventManger.Get<Model.IPacManEvents>().OnCreatePacMan += OnCreatePacMan;
            pacManEventManger.Get<Model.IPacManEvents>().OnUpdatePacManPosition += OnUpdatePacManPosition;

            pacManEventManger.Get<Model.IFieldEvents>().OnCreateField += OnCreateField;
            pacManEventManger.Get<Model.IFieldEvents>().OnUpdateField += OnUpdateField;
            pacManEventManger.Get<Model.IFieldEvents>().OnCountSet += onCountSet;

            pacManEventManger.Get<Model.IGhostEvents>().OnCreateGhost += OnCreateGhost;
            pacManEventManger.Get<Model.IGhostEvents>().OnUpdateGhostPosition += OnUpdateGhostPosition;
            pacManEventManger.Get<Model.IGhostEvents>().OnCreateGhostAnother += OnCreateAnotherGhost;
            pacManEventManger.Get<Model.IGhostEvents>().OnUpdateGhostAnotherPosition += OnUpdateGhostAnotherPosition;
            pacManEventManger.Get<Model.IGhostEvents>().OnPlayerDestroyed += OnPlayerDestroyed;
            pacManEventManger.Get<Model.IGhostEvents>().OnGhostDestroyed += OnGhostDestroyed;
            pacManEventManger.Get<Model.IGhostEvents>().OnGhostAnotherDestroyed += OnGhostAnotherDestroyed;



            pacManEventManger.Get<Model.ICherryEvents>().OnCreateCherry += OnCreateCherry;
            pacManEventManger.Get<Model.ICherryEvents>().OnUpdateCherry += OnUpdateCherry;

        }

        // ======================  Create   =======================


        void OnCreateField(int x, int y)
        {
            bool t = true;
            Vector2 position = PositionManager.GetPosition(x, y);
            Vector2 LogicPosition = new Vector2(x, y);
          
            gameField[x,y] = CharactersFactory.CreateGameField(_gameObjectsParent, position, x, y);

        }

        void OnCreatePacMan(int x, int y)
        {
            
            Vector2 position = PositionManager.GetPosition(x, y);
            _pacMan = CharactersFactory.CreatePacMan(_gameObjectsParent, position);
        }

        void OnCreateGhost(int x, int y)
        {

            Vector2 position = PositionManager.GetPosition(x, y);
            _ghost = CharactersFactory.CreateGhost(_gameObjectsParent, position);
        }

        void OnCreateAnotherGhost(int x, int y)
        {

            Vector2 position = PositionManager.GetPosition(x, y);
            _ghostAnother = CharactersFactory.CreateGhost(_gameObjectsParent, position);
        }

        void OnCreateCherry(int x, int y)
        {
            Vector2 position = PositionManager.GetPosition(x, y);
            _cherry = CharactersFactory.CreateCherry(_gameObjectsParent, position);
        }


        // ======================  Update   =======================

        void OnUpdatePacManPosition(int x, int y)
        {
          
            Vector2 position = PositionManager.GetPosition(x, y);
            _pacMan.UpdatePosition(position, _iterationTime);
        }

        void OnUpdateField(int x, int y)
        {
             if (gameField[x, y] != null)
            {
                _winCount = gameField[x, y].HideMe(_winCount);
                if (_winCount == 0) _uiManager.EndSceneLose.SetActive(true);

            }
        }

        void OnUpdateGhostPosition(int x, int y)
        {

            Vector2 position = PositionManager.GetPosition(x, y);
            _ghost.UpdatePosition(position, _iterationTime);
        }

        

        void OnUpdateGhostAnotherPosition(int x, int y)
        {

            Vector2 position = PositionManager.GetPosition(x, y);
            _ghostAnother.UpdatePosition(position, _iterationTime);
        }

        void OnUpdateCherry(int x, int y)
        {

            Vector2 position = PositionManager.GetPosition(x, y);
            _cherry.SetPosition(position);
        }

        // ======================  Destroy  =======================

        void OnPlayerDestroyed()
        {
            _pacMan.SetGameLose();
            _uiManager.EndSceneWin.SetActive(true);
        }

        void OnGhostDestroyed()
        {
            _ghost.setInactive();
        }

        void OnGhostAnotherDestroyed()
        {
            _ghostAnother.setInactive();
        }

        // ======================  Set   =======================

        void onCountSet(int winCount)
        {
            _winCount = winCount;
        }
    }
}