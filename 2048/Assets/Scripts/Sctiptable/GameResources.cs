using UnityEngine;

namespace Game2048
{
    [CreateAssetMenu(menuName = "Game2048/GameResources")]
    public class GameResources : ScriptableObject
    {
        [SerializeField] private Cube _cubePrefab;
        [SerializeField] private OffsetConfig _offsetConfig;

        public Cube CubePrefab => _cubePrefab;
        public OffsetConfig OffsetConfig => _offsetConfig;
    }
}