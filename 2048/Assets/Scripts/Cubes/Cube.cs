using System;
using UnityEngine;

namespace Game2048
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(BoxCollider))]
    public class Cube : MonoBehaviour
    {
        public static Vector3 GetTotalVelocity(Rigidbody rigidbodyA, Rigidbody rigidbodyB)
        {
            return rigidbodyA.velocity + rigidbodyB.velocity;
        }

        public int number;

        public ICubeStrategy Strategy { get; set; }
        public Rigidbody Rigidbody { get; private set; }

        private void Awake()
        {
            Rigidbody = GetComponent<Rigidbody>();
        }

        private void OnCollisionEnter(Collision collision)
        {
            Strategy?.OnCollision(collision);
        }
    }
}