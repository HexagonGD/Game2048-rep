using UnityEngine;

namespace Game2048
{
    public class General
    {
        private static General _instance;
        public static General Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new General();
                }
                return _instance;
            }
        }

        private General()
        {
            _resources = Resources.Load<GameResources>("GameResources");
        }

        private GameResources _resources;

        public GameResources GameResources => _resources;
    }
}