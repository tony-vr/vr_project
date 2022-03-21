using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Learnproject
{

    public class Enemy : MonoBehaviour
    {
        [SerializeField] private Player _player;
        [SerializeField] private GameObject _bulletPrefab;
        [SerializeField] private Transform _spawnPosition; 
        private bool dir = true;
        public Transform spawnEnemy;

        void Start()
        {
            _player = FindObjectOfType<Player>();

        }

        private void Update()
        {
           if (Vector3.Distance(transform.position, _player.transform.position) < 6)
            {
                if (Input.GetMouseButtonDown(1))
                    Fire();
            }

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
        
        private void Fire ()
        {
            var bulletObj = Instantiate(_bulletPrefab, _spawnPosition.position, _spawnPosition.rotation);
            var bul = bulletObj.GetComponent<Bullet_Enemy>();
            bul.Init(_player.transform, 10, 0.05f);
        }


    }
}
