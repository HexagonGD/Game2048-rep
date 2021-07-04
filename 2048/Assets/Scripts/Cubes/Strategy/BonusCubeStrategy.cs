using UnityEngine;

namespace Game2048
{
    public class BonusCubeStrategy : ICubeStrategy
    {
        public const int OffsetIndex = 11;
        public const int CoefficientMerge = 2;
        public const float DefaultScale = 25f;

        private Cube _cube;

        public bool CanCollision { get; set; }

        void ICubeStrategy.OnCollision(Collision collision)
        {
            var mergeCube = collision.gameObject.GetComponent<Cube>();
            if (mergeCube != null && mergeCube.Strategy.CanCollision)
            {
                mergeCube.Strategy.CanCollision = false;
                _cube.Strategy.CanCollision = false;

                var nextNumber = mergeCube.number * CoefficientMerge;
                var position = collision.contacts[0].point;
                var velocity = Cube.GetTotalVelocity(_cube.Rigidbody, mergeCube.Rigidbody);
                var strategy = mergeCube.Strategy;

                EventSystem.ExecuteEvent(new CubeMergeEvent(nextNumber, position, velocity, strategy));

                Object.Destroy(mergeCube.gameObject);
                Object.Destroy(_cube.gameObject);
            }
        }

        void ICubeStrategy.SetSettingsCube(Cube cube, int number, out int offsetIndex)
        {
            _cube = cube;
            cube.Strategy = this;

            cube.number = 1;

            offsetIndex = OffsetIndex;
            cube.transform.localScale = Vector3.one * DefaultScale;
            CanCollision = true;
        }
    }
}