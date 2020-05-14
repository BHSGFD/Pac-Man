using UnityEngine;

namespace Game.View
{

    public interface IUIManager
    {
        GameObject EndSceneWin { get; }
        GameObject EndSceneLose { get; }
    }

    public class UIManger : MonoBehaviour, IUIManager
    {
        [SerializeField]
        public GameObject EndSceneWin;

        [SerializeField]
        public GameObject EndSceneLose;

        GameObject IUIManager.EndSceneWin => EndSceneWin;
        GameObject IUIManager.EndSceneLose => EndSceneLose;


       public void Restart()
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }
    }
}