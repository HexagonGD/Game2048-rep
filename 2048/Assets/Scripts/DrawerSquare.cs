using UnityEngine;

namespace Game2048
{
    public class DrawerSquare : MonoBehaviour
    {
        [SerializeField] private Area _area;

        private void OnDrawGizmos()
        {
            Gizmos.DrawWireCube(_area.Center, _area.Scale);
        }
    }
}