using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//скрипт для пули противника
namespace Learnproject
{
    public class Bullet_Enemy : MonoBehaviour
    {
        [SerializeField] private float _damage = 3; 
        Transform _target;
        private float _speed;
        public void Init(Transform target, float lifetime, float speed)
        {
            _target = target;
            _speed = speed;
            Destroy(gameObject, lifetime);
        }


        void FixedUpdate()
        {
            //transform.position = Vector3.MoveTowards(transform.position, _target.position, _speed);
            transform.position += transform.forward * 5 * Time.fixedDeltaTime;
        }

        private void OnCollisionEnter(Collision collision)
        {

            if (collision.gameObject.TryGetComponent(out ITakeDamage takeDamage))
            {
                Debug.Log("Hit");
                takeDamage.Hit(_damage);
            }


        }
    }
}