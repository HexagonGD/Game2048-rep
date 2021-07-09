using UnityEngine;

namespace Game2048
{
    public class AimingState : IShotterState
    {
        private readonly Shotting _shotting;
        private Transform _transformCube;
        private Rigidbody _rigidCube;
        private Ray ray = new Ray(new Vector3(6, 1, -1.9f), Vector3.forward);
        private Vector3 _directionShot = new Vector3(-1, 0, 0);

        public AimingState(Shotting shotter)
        {
            _shotting = shotter;
        }

        void IShotterState.Begin()
        {
            var cube = SpawnRandomCube();
            _transformCube = cube.transform;
            _rigidCube = cube.GetComponent<Rigidbody>();
            _rigidCube.isKinematic = true;
        }

        private Cube SpawnRandomCube()
        {
            var position = new Vector3(6f, 0.75f, 0);
            Cube cube;

            if (Random.value < 0.95f)
            {
                var number = (int)Mathf.Pow(2, Random.Range(1, 6));
                cube = _shotting.SpawnCube(number, position, new SimpleCubeStrategy());
            }
            else if (Random.value < 0.75f)
            {
                cube = _shotting.SpawnCube(1, position, new BonusCubeStrategy());
            }
            else
            {
                cube = _shotting.SpawnCube(5, position, new DestroyCubeStrategy());
            }

            return cube;
        }

        void IShotterState.End()
        {
            if (_rigidCube != null)
                _rigidCube.isKinematic = false;
        }

        void IShotterState.OnUpdate()
        {
            if (_transformCube == null)
            {
                _shotting.ChangeState(new LoseState());
                return;
            }

            var position = new Vector3(6f, 1f, -(Screen.width / 2f - Input.mousePosition.x) / Screen.width * 2.4f);
            _transformCube.position = position;
        }

        void IShotterState.Shot()
        {
            if (_rigidCube == null)
            {
                _shotting.ChangeState(new LoseState());
                return;
            }

            _rigidCube.velocity = _directionShot * 13f;
            _shotting.ChangeState(new ReloadState(_shotting));
        }
    }
}