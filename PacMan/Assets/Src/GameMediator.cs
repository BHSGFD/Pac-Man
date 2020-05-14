using System.Collections;
using UnityEngine;
using Game.Model;
using Game.Misc;

namespace Game
{ 
    public class GameMediator : MonoBehaviour
    {
        
        const float ITERATION_TIME = 0.2f;

        [SerializeField]
        View.VisualManager _visualManager;
        [SerializeField]
        View.InputManager inputManager;

        IModelPacMan _model = new ModelPacMan();
        

        eDirection direction = eDirection.RIGHT;

        // ====================================

        View.IVisualManager VisualManager => _visualManager;

        // ====================================

        IEnumerator Start()
        {
           
            VisualManager.Init(_model.EventManager, ITERATION_TIME);

            int i = 0;

            _model.Init();
            _model.InitGhost();
            _model.InitField();

            _model.InitCherry();
            
            while (true)
            {
                if (Input.GetKeyDown(KeyCode.UpArrow))
                {
                    Debug.Log("woek on direction");
                    direction = eDirection.LEFT;

                }
                
                _model.UpdateField();
                _model.Update(inputManager.direction);
                _model.UpdateGhost();
                _model.UpdateCherrry();
                yield return new WaitForSeconds(ITERATION_TIME);
            }
        }
    }
}
