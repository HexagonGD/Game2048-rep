using Game2048.Factory;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace Game2048
{
    public class CubeHandler : ISave, ILoad
    {
        private readonly CubeFactory _cubeFactory;
        private List<Cube> _cubes = new List<Cube>();

        public CubeHandler()
        {
            _cubeFactory = new CubeFactory();
            EventSystem.AddListener<CubeMergeEvent>(this, OnCubeMergeEvent);
            EventSystem.AddListener<LoseGameEvent>(this, OnLoseGame);
        }

        private void OnLoseGame(LoseGameEvent eventArg)
        {
            EventSystem.RemoveListener<CubeMergeEvent>(this);
            EventSystem.RemoveListener<LoseGameEvent>(this);
        }

        public Cube Spawn(int number, Vector3 position, ICubeStrategy strategy)
        {
            var cube = _cubeFactory.Spawn(number, position, strategy);
            _cubes.Add(cube);
            cube.Destroy += OnCubeDestroy;
            return cube;
        }

        private void OnCubeMergeEvent(CubeMergeEvent eventArg)
        {
            SoundController.Instance.Blup();
            Spawn(eventArg.number, eventArg.position, eventArg.strategy);
        }

        public void Save(SaveStream stream)
        {
            stream.Write(0);
            stream.Write(_cubes.Count);
            foreach(var cube in _cubes)
            {
                (cube as ISave).Save(stream);
            }
        }

        public void Load(LoadStream stream)
        {
            var score = stream.ReadInt();
            var count = stream.ReadInt();
            for(var i = 0; i < count; i++)
            {
                var number = stream.ReadInt();

                ICubeStrategy strategy;
                switch(number)
                {
                    case 1:
                        strategy = new BonusCubeStrategy();
                        break;
                    case 3:
                        strategy = new EmptyCubeStrategy();
                        break;
                    case 5:
                        strategy = new DestroyCubeStrategy();
                        break;
                    default:
                        strategy = new SimpleCubeStrategy();
                        break;
                }
                var cube = _cubeFactory.NotEffectSpawn(number, strategy);

                (cube as ILoad).Load(stream);
                _cubes.Add(cube);
                cube.Destroy += OnCubeDestroy;
            }
        }

        private void OnCubeDestroy(Cube cube)
        {
            _cubes.Remove(cube);
            cube.Destroy -= OnCubeDestroy;
        }
    }
}