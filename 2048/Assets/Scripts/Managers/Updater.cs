using UnityEngine;

namespace Game2048
{
    public class Updater : MonoBehaviour
    {
        private void Start()
        {
            Starter.StartGame();
        }

        private void Update()
        {
            EventSystem.ExecuteEvent(new UpdateEvent());
        }
    }
}