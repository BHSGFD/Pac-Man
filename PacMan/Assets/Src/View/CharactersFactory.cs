using UnityEngine;

namespace Game.View
{ 
    public interface ICharactersFactory
    {
        IPacMan CreatePacMan(Transform parentTransform, Vector2 position);
        IGameField CreateGameField(Transform parentTransform, Vector2 position, int x, int y);
        IGhost CreateGhost(Transform parentTransform, Vector2 position);
        ICherry CreateCherry(Transform parentTransform, Vector2 position);
    }

    // ##############################################

    public class CharactersFactory : MonoBehaviour, ICharactersFactory
    {
        [SerializeField]
        PacMan _pacManPrefab;

        [SerializeField]
        GameField _GameFieldPrefab;

        [SerializeField]
        Ghost _ghostPrefab;

        [SerializeField]
        CherryObj _Cherry;

        // ========== ICharactersFactory ============

        IPacMan ICharactersFactory.CreatePacMan(Transform parentTransform, Vector2 position)
        { return _pacManPrefab.CloneMe(parentTransform, position); }

        // доделать в icoin
        IGameField ICharactersFactory.CreateGameField(Transform parentTransform, Vector2 position, int x, int y)
        { return _GameFieldPrefab.CloneMe(parentTransform, position, x, y); }

        IGhost ICharactersFactory.CreateGhost(Transform parentTransform, Vector2 position)
        { return _ghostPrefab.CloneMe(parentTransform, position); }

        ICherry ICharactersFactory.CreateCherry(Transform parentTransform, Vector2 position)
        { return _Cherry.CloneMe(parentTransform, position); }
    }
}
