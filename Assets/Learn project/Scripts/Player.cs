using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Learnproject
{
    public class Player : MonoBehaviour
    {
        public GameObject ShieldPrefab;
        public Transform spawnPosition;
        private bool _isSpawnShield;
        [HideInInspector] public int level = 1;
        public GameObject Enemy;
        public Transform spawnEnemy;
        public GameObject Bullet;
        public Transform spawnBullet;


        public Vector3 _direction;
        public float speed = 2f;
        public float speedRotate = 20f;




        void Start()
        {
            StartCoroutine(EnemySpawn());

        }


        void Update()
        {
            if (Input.GetMouseButtonDown(0))
                _isSpawnShield = true;
            if (Input.GetMouseButtonDown(1))
                SpawnBullet();

            _direction.x = Input.GetAxis("Horizontal");
            _direction.z = Input.GetAxis("Vertical");


        }



        void FixedUpdate()
        {
            if (_isSpawnShield)
            {
                _isSpawnShield = false;
                SpawnShield();
            }
            Move(Time.fixedDeltaTime);

            transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X")* speedRotate, 0));
        }
         
        private void SpawnShield()
        {
            var shieldObj = Instantiate(ShieldPrefab, spawnPosition.position, spawnPosition.rotation);
            var shield = shieldObj.GetComponent<Shield>();
            shield.Init(10 * level);
            
            shield.transform.SetParent(spawnPosition);
        }

        private void SpawnBullet()
        {
            Instantiate(Bullet,spawnBullet.position, spawnBullet.rotation);
        }


         void Repeat()
        {
            StartCoroutine(EnemySpawn());
        }

        IEnumerator EnemySpawn()
        {
            yield return new WaitForSeconds(3);
            Instantiate(Enemy, spawnEnemy.position, Quaternion.identity);
            Repeat();
        }


        private void Move(float delta)
        {
            var fixedDirection = transform.TransformDirection(_direction.normalized); 
            transform.position += fixedDirection * speed * delta;
        }
           

    }
}