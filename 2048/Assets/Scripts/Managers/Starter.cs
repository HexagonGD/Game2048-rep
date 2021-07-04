using UnityEngine;

namespace Game2048
{
    public static class Starter
    {
        public static Area spawnArea = new Area(-3f, 5f, -1.5f, 1.5f);

        public static void StartGame()
        {
            var handler = new CubeHandler();
            var shotter = new Shotting(handler);

            for (var x = spawnArea.x1; x < spawnArea.x2; x++)
            {
                for (var z = spawnArea.y1; z <= spawnArea.y2; z++)
                {
                    var position = new Vector3(x, 1, z);
                    handler.Spawn(2, position, Vector3.zero, new SimpleCubeStrategy());
                }
            }
        }
    }
}