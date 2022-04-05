using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//скрипт для пули игрока
namespace Learnproject
{
    public class Bullet : MonoBehaviour
    {
        private Rigidbody _rigidbody;
        [SerializeField] private float _force = 3;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }
        //void FixedUpdate()
        //{
        //    transform.Translate(new Vector3(0, 0, 0.1f));
        //    Destroy(gameObject, 5f);

        public void Init(Transform target)
        {
            _rigidbody.AddForce(transform.forward * _force);
        }
    }

    
}
