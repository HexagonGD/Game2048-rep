using System;
using UnityEngine;

namespace Game2048
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(BoxCollider))]
    public class Cube : MonoBehaviour
    {
        public static Cube MainCube;

        private Vector3 _finalScale;

        public static Vector3 GetTotalVelocity(Rigidbody rigidbodyA, Rigidbody rigidbodyB)
        {
            return rigidbodyA.velocity + rigidbodyB.velocity;
        }

        public int number;

        private ICubeStrategy _strategy;
        private Rigidbody _rigidbody;

        public Rigidbody Rigidbody => _rigidbody;

        public bool CanCollision => _strategy == null ? false : _strategy.CanCollision;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            transform.localScale = Vector3.Lerp(transform.localScale, _finalScale, Time.deltaTime * 5f);
        }

        private void OnCollisionEnter(Collision collision)
        {
            _strategy?.OnCollision(collision);
        }

        public void SetStrategy(ICubeStrategy strategy)
        {
            _strategy = strategy;
            _finalScale = transform.localScale;
            transform.localScale = Vector3.one;
        }
    }
}