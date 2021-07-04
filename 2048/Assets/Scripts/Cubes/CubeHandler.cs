using System.Collections.Generic;
using UnityEngine;

namespace Game2048
{
    public class CubeHandler
    {
        private Cube _cubePrefab;
        private IReadOnlyList<Vector2> _offsets;

        public CubeHandler()
        {
            _cubePrefab = General.Instance.GameResources.CubePrefab;
            _offsets = General.Instance.GameResources.OffsetConfig.Offsets;
            EventSystem.AddListener<CubeMergeEvent>(this, OnCubeMergeEvent);
            EventSystem.AddListener<LoseGameEvent>(this, OnLoseGame);
        }

        private void OnLoseGame(LoseGameEvent eventArg)
        {
            EventSystem.RemoveListener<CubeMergeEvent>(this);
            EventSystem.RemoveListener<LoseGameEvent>(this);
        }

        public Cube Spawn(int number, Vector3 position, Vector3 velocity, ICubeStrategy strategy)
        {
            var cube = Object.Instantiate(_cubePrefab);
            cube.transform.position = position;
            cube.Rigidbody.velocity = velocity;

            strategy.SetSettingsCube(cube, number, out var offsetIndex);
            cube.GetComponent<MeshRenderer>().material.SetTextureOffset("_MainTex", _offsets[offsetIndex]);

            return cube;
        }

        private void OnCubeMergeEvent(CubeMergeEvent eventArg)
        {
            SoundController.Instance.Blup();
            Spawn(eventArg.number, eventArg.position, eventArg.totalVelocity, eventArg.strategy);
        }
    }
}