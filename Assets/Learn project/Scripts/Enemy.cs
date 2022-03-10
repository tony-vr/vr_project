using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Learnproject
{

    public class Enemy : MonoBehaviour
    {
        private Player _player;
        [SerializeField] private GameObject _bulletPrefab;
        [SerializeField] private Transform spawnPosition; 
        private bool dir = true;
        public Transform spawnEnemy;

        private void Update()
        {
           
        }

                
        void FixedUpdate()
        {

            Move();
        }

        void OnTriggerEnter(Collider other)
        {
            print(other.gameObject.name);
            dir = !dir;
        }

        void Move()
        {           
                transform.Translate(new Vector3(0, 0, 0.1f));
                Destroy(gameObject, 6f);
        }
        
        

    }
}
