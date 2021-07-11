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
            if (mergeCube != null && mergeCube.CanCollision && mergeCube.number == _cube.number)
            {
                var nextNumber = mergeCube.number * CoefficientMerge;
                var strategy = new SimpleCubeStrategy();

                new Connector(_cube, mergeCube, nextNumber, strategy);
            }
        }

        void ICubeStrategy.SetSettingsCube(Cube cube, int number, out int offsetIndex)
        {
            if (number > 2048)
            {
                Object.Destroy(cube.gameObject);
                EventSystem.ExecuteEvent(new CubeMergeEvent(3, cube.transform.position, new EmptyCubeStrategy()));
                offsetIndex = 0;
                return;
            }

            _cube = cube;
            offsetIndex = (int)Mathf.Log(number, 2) - 1;
            cube.transform.localScale = Vector3.one * (offsetIndex * ScaleFactor + DefaultScale);
            cube.SetStrategy(this);

            cube.number = number;
            CanCollision = true;
        }

        void ICubeStrategy.PlaySpawnEffect()
        {
            if (_cube.number != 2)
            {
                var velocity = Vector3.up * 7.5f + Vector3.left * 1.5f;
                var area = General.Instance.GameResources.GameArea;
                var hits = Physics.BoxCastAll(area.Center, area.Scale / 2f, Vector3.up, Quaternion.identity);
                foreach (var hit in hits)
                {
                    var cubeFriend = hit.collider.gameObject.GetComponent<Cube>();
                    if (cubeFriend != null && cubeFriend.number == _cube.number && cubeFriend != _cube)
                    {
                        var deltaPosition = cubeFriend.transform.position - _cube.transform.position;
                        velocity = deltaPosition * 0.75f + Vector3.up * 7.5f;
                        break;
                    }
                }

                _cube.Rigidbody.velocity = velocity;
            }
        }
    }
}