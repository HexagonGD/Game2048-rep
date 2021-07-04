using UnityEngine.SceneManagement;

namespace Game2048
{
    public class LoseState : IShotterState
    {
        void IShotterState.Begin()
        {
            EventSystem.ExecuteEvent(new LoseGameEvent());
            SceneManager.LoadScene("Game");
        }

        void IShotterState.End()
        {

        }

        void IShotterState.OnUpdate()
        {
            return;
        }

        void IShotterState.Shot()
        {
            return;
        }
    }
}