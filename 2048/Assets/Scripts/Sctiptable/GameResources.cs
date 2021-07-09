using UnityEngine;

namespace Game2048
{
    [CreateAssetMenu(menuName = "Game2048/GameResources")]
    public class GameResources : ScriptableObject
    {
        [SerializeField] private Cube _cubePrefab;
        [SerializeField] private OffsetConfig _offsetConfig;
        [SerializeField] private Area _gameArea;
        [SerializeField] private Area _deadArea;

        public Cube CubePrefab => _cubePrefab;
        public OffsetConfig OffsetConfig => _offsetConfig;
        public Area GameArea => _gameArea;
        public Area DeadArea => _deadArea;
    }
}