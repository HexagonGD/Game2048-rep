using UnityEngine;

namespace Game2048
{
    public interface ICubeStrategy
    {
        bool CanCollision { get; set; }
        void OnCollision(Collision collision);
        void SetSettingsCube(Cube cube, int number, out int offsetIndex);
    }
}