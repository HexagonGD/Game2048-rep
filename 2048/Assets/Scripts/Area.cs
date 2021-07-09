using UnityEngine;

namespace Game2048
{
    [CreateAssetMenu(menuName = "Game2048/Area")]
    public class Area : ScriptableObject
    {
        [SerializeField] private Vector3 _center;
        [SerializeField] private Vector3 _scale;

        public Vector3 Center => _center;
        public Vector3 Scale => _scale;
    }
}