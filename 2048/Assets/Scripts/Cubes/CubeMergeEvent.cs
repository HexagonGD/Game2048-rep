using UnityEngine;

namespace Game2048
{
    public readonly struct CubeMergeEvent
    {
        public readonly ICubeStrategy strategy;
        public readonly Vector3 position;
        public readonly int number;

        public CubeMergeEvent(int number, Vector3 position, ICubeStrategy strategy)
        {
            this.number = number;
            this.position = position;
            this.strategy = strategy;
        }
    }
}