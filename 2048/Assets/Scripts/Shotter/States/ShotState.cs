using UnityEngine;

namespace Game2048
{
    public class ShotState : IShotterState
    {
        private const float MaxForce = 1000f;
        private const float MinForce = 300f;

        private readonly Shotting _shotter;
        private readonly Rigidbody _rigid;

        private Vector3 _directionShot = new Vector3(-1, 0, 0);

        public ShotState(Shotting shotter, Cube cube)
        {
            _shotter = shotter;
            _rigid = cube.GetComponent<Rigidbody>();
        }

        void IShotterState.Begin()
        {
            EventSystem.ExecuteEvent(new ChangeShotStateEvent(true));
        }

        void IShotterState.End()
        {
            EventSystem.ExecuteEvent(new ChangeShotStateEvent(false));
        }

        void IShotterState.OnUpdate()
        {
            return;
        }

        void IShotterState.Shot()
        {
            if(_rigid == null)
            {
                _shotter.ChangeState(new LoseState());
                return;
            }
            var value = Mathf.Sin(Time.time * 2f) / 2f + 0.5f;
            _rigid.AddForce(_directionShot * Mathf.Lerp(MinForce, MaxForce, value));
            _shotter.ChangeState(new ReloadState(_shotter));
        }
    }
}