using System;
using System.Collections;
using UnityEngine;

namespace Game2048
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(BoxCollider))]
    public class Cube : MonoBehaviour, ISave, ILoad
    {
        public Action<Cube> Destroy;

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

        private void OnCollisionEnter(Collision collision)
        {
            _strategy?.OnCollision(collision);
        }

        public void SetStrategy(ICubeStrategy strategy)
        {
            _strategy = strategy;
        }

        public void PlaySpawnEffect()
        {
            _strategy?.PlaySpawnEffect();
        }

        public void ResetScale()
        {
            StartCoroutine(ScaleResize());
        }

        private void OnDestroy()
        {
            Destroy?.Invoke(this);
        }

        void ISave.Save(SaveStream stream)
        {
            stream.Write(number);
            stream.Write(transform.position);
            stream.Write(transform.rotation);
        }

        private IEnumerator ScaleResize()
        {
            var finalScale = transform.localScale;
            transform.localScale = Vector3.one;

            while(finalScale.magnitude - transform.localScale.magnitude > 0.1f)
            {
                transform.localScale = Vector3.Lerp(transform.localScale, finalScale, Time.deltaTime * 5f);
                Debug.Log(transform.localScale);
                yield return null;
            }
        }

        void ILoad.Load(LoadStream stream)
        {
            var position = stream.ReadVector3();
            var rotation = stream.ReadQuaternion();

            transform.position = position;
            transform.rotation = rotation;
        }
    }
}