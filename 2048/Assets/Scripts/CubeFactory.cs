using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game2048.Factory
{
    public class CubeFactory
    {
        private readonly Cube _cubePrefab;
        private readonly IReadOnlyList<Vector2> _offsets;

        public CubeFactory()
        {
            _cubePrefab = General.Instance.GameResources.CubePrefab;
            _offsets = General.Instance.GameResources.OffsetConfig.Offsets;
        }

        public Cube Spawn(int number, Vector3 position, ICubeStrategy strategy)
        {
            var cube = Object.Instantiate(_cubePrefab);
            cube.transform.position = position;
            strategy.SetSettingsCube(cube, number, out var offsetIndex);
            cube.ResetScale();
            cube.PlaySpawnEffect();
            cube.GetComponent<MeshRenderer>().material.SetTextureOffset("_MainTex", _offsets[offsetIndex]);
            return cube;
        }

        public Cube NotEffectSpawn(int number, ICubeStrategy strategy)
        {
            var cube = Object.Instantiate(_cubePrefab);
            strategy.SetSettingsCube(cube, number, out var offsetIndex);
            cube.GetComponent<MeshRenderer>().material.SetTextureOffset("_MainTex", _offsets[offsetIndex]);
            return cube;
        }
    }
}