using UnityEngine;

namespace Game2048
{
    public class DeadZone : MonoBehaviour
    {
        private int countObjectInCollider = 0;
        private int maxCountObjectInCollider = 1;

        private void OnTriggerEnter(Collider other)
        {
            countObjectInCollider++;
            if (countObjectInCollider > maxCountObjectInCollider)
            {
                EventSystem.ExecuteEvent(new LoseGameEvent());
            }
        }

        private void OnTriggerExit(Collider other)
        {
            countObjectInCollider--;
        }
    }
}