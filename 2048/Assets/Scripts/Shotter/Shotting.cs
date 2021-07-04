using UnityEngine;

namespace Game2048
{
    public class Shotting
    {
        private IShotterState _state;
        private CubeHandler _handler;

        public Shotting(CubeHandler handler)
        {
            _handler = handler;
            EventSystem.AddListener<ShotButtonClickEvent>(this, OnShot);
            EventSystem.AddListener<UpdateEvent>(this, OnUpdate);
            EventSystem.AddListener<LoseGameEvent>(this, OnLoseGame); 
            ChangeState(new ReloadState(this));
        }

        private void OnLoseGame(LoseGameEvent obj)
        {
            EventSystem.RemoveListener<ShotButtonClickEvent>(this);
            EventSystem.RemoveListener<UpdateEvent>(this);
            EventSystem.RemoveListener<LoseGameEvent>(this);
        }

        public Cube SpawnCube(int number, Vector3 position, ICubeStrategy strategy)
            => _handler.Spawn(number, position, Vector3.zero, strategy);

        #region State Methods
        public void OnShot(ShotButtonClickEvent eventArg) => _state.Shot();

        public void OnUpdate(UpdateEvent eventArg) => _state.OnUpdate();

        public void ChangeState(IShotterState shotterState)
        {
            _state?.End();
            _state = shotterState;
            _state.Begin();
        }
        #endregion
    }
}