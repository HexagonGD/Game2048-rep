using UnityEngine;

namespace Game2048
{
    public class AimingState : IShotterState
    {
        private readonly Shotting _shotting;
        private Transform _transformCube;
        private Rigidbody _rigidCube;
        private Ray ray = new Ray(new Vector3(6, 1, -1.9f), Vector3.forward);

        public AimingState(Shotting shotter)
        {
            _shotting = shotter;
        }

        void IShotterState.Begin()
        {
            if (Physics.Raycast(ray, 2f))
            {
                _shotting.ChangeState(new LoseState());
                return;
            }

            var cube = SpawnRandomCube();
            _transformCube = cube.transform;
            _rigidCube = cube.GetComponent<Rigidbody>();
            _rigidCube.isKinematic = true;
        }

        private Cube SpawnRandomCube()
        {
            var position = new Vector3(6f, 1f, Mathf.Sin(Time.time) * 1.5f);
            Cube cube;

            if (Random.value < 0.95f)
            {
                var number = (int)Mathf.Pow(2, Random.Range(1, 3));
                cube = _shotting.SpawnCube(number, position, new SimpleCubeStrategy());
            }
            else if (Random.value < 0.75f)
            {
                cube = _shotting.SpawnCube(1, position, new BonusCubeStrategy());
            }
            else if (Random.value < 0.75f)
            {
                cube = _shotting.SpawnCube(3, position, new EmptyCubeStrategy());
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
            var position = new Vector3(6f, 1f, Mathf.Sin(Time.time) * 1.5f);
            _transformCube.position = position;
        }

        void IShotterState.Shot()
        {
            _shotting.ChangeState(
                new ShotState(_shotting, _transformCube.GetComponent<Cube>()));
        }
    }
}