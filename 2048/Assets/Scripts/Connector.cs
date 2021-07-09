using UnityEngine;
using Object = UnityEngine.Object;

namespace Game2048
{
    public class Connector
    {
        private readonly CubeMergeEvent _mergeEvent;
        private readonly Transform _cubeA;
        private readonly Transform _cubeB;
        private readonly Vector3 _centerPosition;
        private readonly Vector3 _startScaleCube;
        private readonly float _startDistanceCube;

        public Connector(Cube cubeA, Cube cubeB, int number, ICubeStrategy strategy)
        {
            _cubeA = cubeA.transform;
            _cubeB = cubeB.transform;
            _centerPosition = (_cubeA.position + _cubeB.position) / 2f;
            _mergeEvent = new CubeMergeEvent(number, _centerPosition, strategy);
            _startScaleCube = _cubeA.localScale;
            _startDistanceCube = Vector3.Magnitude(_centerPosition - _cubeA.position);

            cubeA.SetStrategy(null);
            cubeB.SetStrategy(null);

            cubeA.Rigidbody.isKinematic = true;
            cubeB.Rigidbody.isKinematic = true;

            EventSystem.AddListener<UpdateEvent>(this, OnUpdate);
            EventSystem.AddListener<LoseGameEvent>(this, OnLoseGame);
        }

        private void OnUpdate(UpdateEvent eventArg)
        {
            MoveCubes();
            SetNewScale();

            if (_cubeA.position == _cubeB.position)
            {
                DestroyObjects();
                Disable();
                EventSystem.ExecuteEvent(_mergeEvent);
            }
        }

        private void MoveCubes()
        {
            _cubeA.position = Vector3.MoveTowards(_cubeA.position, _centerPosition, Time.deltaTime);
            _cubeB.position = Vector3.MoveTowards(_cubeB.position, _centerPosition, Time.deltaTime);
        }

        private void SetNewScale()
        {
            var currentDistanceCube = Vector3.Magnitude(_centerPosition - _cubeA.position);
            var currentLocalScale = _startScaleCube * Mathf.InverseLerp(0, _startDistanceCube, currentDistanceCube);
            _cubeA.localScale = _cubeB.localScale = currentLocalScale;
        }

        private void DestroyObjects()
        {
            Object.Destroy(_cubeA.gameObject);
            Object.Destroy(_cubeB.gameObject);
        }

        private void Disable()
        {
            EventSystem.RemoveListener<UpdateEvent>(this);
            EventSystem.RemoveListener<LoseGameEvent>(this);
        }

        private void OnLoseGame(LoseGameEvent eventArg)
        {
            Disable();
        }
    }
}