using UnityEngine;

namespace Game2048
{
    public readonly struct CubeMergeEvent
    {
        public readonly ICubeStrategy strategy;
        public readonly Vector3 position;
        public readonly Vector3 totalVelocity;
        public readonly int number;

        public CubeMergeEvent(int number, Vector3 position,
            Vector3 totalVelocity, ICubeStrategy strategy)
        {
            this.number = number;
            this.position = position;
            this.totalVelocity = totalVelocity;
            this.strategy = strategy;
        }
    }
}