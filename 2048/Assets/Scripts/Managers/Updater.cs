using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game2048
{
    public class Updater : MonoBehaviour
    {
        private void Start()
        {
            Starter.StartGame();
            EventSystem.AddListener<LoseGameEvent>(this, OnLoseGame);
        }

        private void Update()
        {
            EventSystem.ExecuteEvent(new UpdateEvent());
        }

        private void OnLoseGame(LoseGameEvent eventArg)
        {
            SceneManager.LoadScene("Game");
        }
    }
}