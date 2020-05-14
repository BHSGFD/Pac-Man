using Game.Misc;
using System.Collections;
using UnityEngine;

namespace Game.View
{
   


    public class InputManager : MonoBehaviour
    {
         public eDirection direction = eDirection.RIGHT;

        IEnumerator Start()
        {
            while (true)
            {
                direction = InputDirection();
                yield return new WaitForSeconds(0.005f);
            }
        }
            
        

          eDirection InputDirection()
        {
            if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
            {
                return eDirection.UP;
            }

            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                return eDirection.DOWN;
            }

            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                return eDirection.LEFT;
            }

            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                return eDirection.RIGHT;
            }

            return direction;

        }



    }
}