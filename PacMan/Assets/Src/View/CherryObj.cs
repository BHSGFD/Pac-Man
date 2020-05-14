using Game.Misc;
using System.Collections;
using UnityEngine;
using WCTools;

namespace Game.View
{
    public interface ICherry
    {
        void SetPosition(Vector2 position);
    }

    // #########################################

    public class CherryObj : MonoBehaviour, ICherry
    {
        public ICherry CloneMe(Transform parent, Vector2 position)
        {
            GameObject newObj = Instantiate(gameObject, parent);
            CherryObj cherry = newObj.GetComponent<CherryObj>();
            cherry.transform.localPosition = position;
            return cherry;
        }

        // ===================================


        // ========== IPacMan ================
        void ICherry.SetPosition(Vector2 position)
        {
            StartCoroutine(Timer());
            gameObject.GetComponent<SpriteRenderer>().enabled = false ;
            transform.localPosition = position;
           
            
        }

        IEnumerator Timer()
        {
            yield return new WaitForSeconds(5);
            gameObject.GetComponent<SpriteRenderer>().enabled = true; 
            Cherry.EnumCherry = eCherry.isInactive;

        }
       
    }
}
