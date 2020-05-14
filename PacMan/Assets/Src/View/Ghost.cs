using UnityEngine;
using WCTools;

namespace Game.View
{
    public interface IGhost
    {
        void UpdatePosition(Vector2 position, float time);
        void setInactive();
    }

    // #########################################

    public class Ghost : MonoBehaviour, IGhost
    {
        bool interpolateStop = true;

        public IGhost CloneMe(Transform parent, Vector2 position)
        {
            GameObject newObj = Instantiate(gameObject, parent);
            Ghost ghost = newObj.GetComponent<Ghost>();
            ghost.transform.localPosition = position;
            return ghost;
        }

        // ===================================

        CoroutineInterpolator _positionInterp;

        void Awake()
        {
            _positionInterp = new CoroutineInterpolator(this);
        }

        // ========== IPacMan ================

        void IGhost.UpdatePosition(Vector2 position, float time)
        {
            if (interpolateStop)
            _positionInterp.Interpolate(transform.localPosition, position, time,
                (Vector2 pos) =>
                {
                    transform.localPosition = pos;
                });
        }

        void IGhost.setInactive()
        {
            interpolateStop = false;
            gameObject.SetActive(false);
        }
    }
}
