using System.Collections.Generic;
using UnityEngine;

namespace Game2048
{
    [CreateAssetMenu(menuName = "Game2048/OffsetConfig")]
    public class OffsetConfig : ScriptableObject
    {
        [SerializeField] private List<Vector2> _offsets;

        public IReadOnlyList<Vector2> Offsets => _offsets;
    }
}