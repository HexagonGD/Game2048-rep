using UnityEngine;

namespace Game2048
{
    public class SimpleCubeStrategy : ICubeStrategy
    {
        public const float ScaleFactor = 4f;
        public const float DefaultScale = 25f;
        public const int CoefficientMerge = 2;

        private Cube _cube;

        public bool CanCollision { get; set; } = true;

        void ICubeStrategy.OnCollision(Collision collision)
        {
            var mergeCube = collision.gameObject.GetComponent<Cube>();
            if (mergeCube != null && mergeCube.Strategy.CanCollision && mergeCube.number == _cube.number)
            {
                mergeCube.Strategy.CanCollision = false;
                CanCollision = false;

                var nextNumber = mergeCube.number * CoefficientMerge;
                var position = collision.contacts[0].point;
                var velocity = Cube.GetTotalVelocity(_cube.Rigidbody, mergeCube.Rigidbody);
                var strategy = mergeCube.Strategy;

                EventSystem.ExecuteEvent(new CubeMergeEvent(nextNumber, position, velocity, strategy));

                Object.Destroy(collision.gameObject);
                Object.Destroy(_cube.gameObject);
            }
        }

        void ICubeStrategy.SetSettingsCube(Cube cube, int number, out int offsetIndex)
        {
            if (number > 2048)
            {
                Object.Destroy(cube);
                offsetIndex = 0;
                return;
            }

            _cube = cube;
            cube.Strategy = this;

            cube.number = number;

            offsetIndex = (int)Mathf.Log(number, 2) - 1;
            cube.transform.localScale = Vector3.one * (offsetIndex * ScaleFactor + DefaultScale);
            CanCollision = true;
        }
    }
}