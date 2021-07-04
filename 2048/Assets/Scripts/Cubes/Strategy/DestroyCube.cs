﻿using UnityEngine;

namespace Game2048
{
    public class DestroyCubeStrategy : ICubeStrategy
    {
        public const int OffsetIndex = 13;
        public const float DefaultScale = 25f;

        private Cube _cube;
        private bool _canCollision;
        
        bool ICubeStrategy.CanCollision { get => false; set => _canCollision = value; }

        void ICubeStrategy.OnCollision(Collision collision)
        {
            var mergeCube = collision.gameObject.GetComponent<Cube>();
            if (mergeCube != null && mergeCube.Strategy.CanCollision && _canCollision)
            {
                mergeCube.Strategy.CanCollision = false;
                _canCollision = false;

                Object.Destroy(mergeCube.gameObject);
                Object.Destroy(_cube.gameObject);
            }
        }

        void ICubeStrategy.SetSettingsCube(Cube cube, int number, out int offsetIndex)
        {
            _cube = cube;
            cube.number = 5;
            cube.Strategy = this;

            offsetIndex = OffsetIndex;
            cube.transform.localScale = Vector3.one * DefaultScale;
            _canCollision = true;
        }
    }
}