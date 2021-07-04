using UnityEngine;

namespace Game2048
{
    internal class ReloadState : IShotterState
    {
        private const float _timeToReload = 0.5f;
        private readonly Shotting _shotter;
        private float _leftTimeToReload;

        public ReloadState(Shotting shotter)
        {
            _shotter = shotter;
        }

        void IShotterState.Begin()
        {
            _leftTimeToReload = _timeToReload;
        }

        void IShotterState.End()
        {
            return;
        }

        void IShotterState.OnUpdate()
        {
            _leftTimeToReload -= Time.deltaTime;
            if (_leftTimeToReload < 0)
            {
                _shotter.ChangeState(new AimingState(_shotter));
            }
        }

        void IShotterState.Shot()
        {
            return;
        }
    }
}