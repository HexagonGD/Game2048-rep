using UnityEngine;

namespace Game2048
{
    public class ServicesUI : MonoBehaviour
    {
        public void OnShotButtonClick()
        {
            EventSystem.ExecuteEvent<ShotButtonClickEvent>(new ShotButtonClickEvent());
        }
    }
}