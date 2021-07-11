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
            if (mergeCube != null && mergeCube.CanCollision)
            {
                _cube.SetStrategy(null);
                mergeCube.SetStrategy(null);

                var nextNumber = mergeCube.number * CoefficientMerge;
                var position = mergeCube.transform.position;
                var strategy = new SimpleCubeStrategy();

                EventSystem.ExecuteEvent(new CubeMergeEvent(nextNumber, position, strategy));

                Object.Destroy(_cube.gameObject);
                Object.Destroy(mergeCube.gameObject);
            }
        }

        void ICubeStrategy.PlaySpawnEffect()
        {
            return;
        }

        void ICubeStrategy.SetSettingsCube(Cube cube, int number, out int offsetIndex)
        {
            _cube = cube;
            offsetIndex = OffsetIndex;
            cube.transform.localScale = Vector3.one * DefaultScale;
            cube.SetStrategy(this);

            cube.number = 1;
            CanCollision = true;
        }
    }
}