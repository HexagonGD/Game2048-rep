using UnityEngine;

namespace Game2048
{
    public static class Starter
    {
        public static void StartGame()
        {
            var handler = new CubeHandler();
            var shotter = new Shotting(handler);
            var area = General.Instance.GameResources.GameArea;

            for(var x = area.Center.x - area.Scale.x / 2 + 1; x < area.Center.x + area.Scale.x / 2 - 1; x++)
            {
                for(var z = area.Center.z - area.Scale.z / 2 + 0.3f; z < area.Center.z + area.Scale.z / 2 - 0.3f; z++)
                {
                    var position = new Vector3(x, 0.5f, z);
                    handler.Spawn(2, position, new SimpleCubeStrategy());
                }
            }
        }
    }
}