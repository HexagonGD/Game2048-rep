using UnityEngine;

namespace Game2048
{
    public class EmptyCubeStrategy : ICubeStrategy
    {
        public const int OffsetIndex = 12;
        public const float DefaultScale = 25f;
        public const float ScaleFactor = 4f;

        public bool CanCollision { get => false; set { } }

        void ICubeStrategy.OnCollision(Collision collision)
        {
            return;
        }

        void ICubeStrategy.PlaySpawnEffect()
        {
            return;
        }

        void ICubeStrategy.SetSettingsCube(Cube cube, int number, out int offsetIndex)
        {
            cube.number = number;
            offsetIndex = OffsetIndex;
            cube.transform.localScale = Vector3.one * (DefaultScale + Mathf.Log(number, 2) * ScaleFactor);
            cube.SetStrategy(this);

            CanCollision = true;
        }
    }
}