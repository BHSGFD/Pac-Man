using UnityEngine;
using WCTools;

namespace Game.View
{
    public interface IGameField
    {
       Vector2 pos { get; }
      int HideMe(int WinCount);
    }

    // #########################################

    public class GameField : MonoBehaviour, IGameField
    {
       
        
        int x;
        int y;
        int i = 0;
        Vector2 pos1;
        GameField field;
        int count = -1;
        

        public IGameField CloneMe(Transform parent, Vector2 position, int X, int Y)
        {
            pos1 = position;
            i++;
          //  Debug.Log(i + "  " + position);
            GameObject coin = Instantiate(gameObject, parent);
            GameField field = coin.GetComponent<GameField>();
            field.transform.localPosition = position;
            field.transform.name = "coin  " + X.ToString() + " " + Y.ToString();
            return field;
        }

        // ===================================

        Vector2 IGameField.pos => pos1;

        int IGameField.HideMe(int WinCount)
        {
          //  if (count == -1)
          //  {
          //      count = WinCount;
          //  }
          
            if (gameObject.activeInHierarchy == true)
            {
                WinCount--;
                gameObject.SetActive(false);    
            }
            return WinCount;



        }


        CoroutineInterpolator _positionInterp;


        void Awake()
        {
            _positionInterp = new CoroutineInterpolator(this);
        }


    }
}
