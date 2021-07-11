using System.IO;

namespace Game2048
{
    public static class Starter
    {
        public static void StartGame()
        {
            var handler = new CubeHandler();
            var shotter = new Shotting(handler);
            if (File.Exists("save"))
            {
                using (var reader = new BinaryReader(File.Open("save", FileMode.Open)))
                {
                    handler.Load(new LoadStream(reader));
                }
            }
        }
    }
}