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
        private bool _isSprint;



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

            _isSprint = Input.GetButton("Sprint");
        }



        void FixedUpdate()
        {
            if (_isSpawnShield)
            {
                _isSpawnShield = false;
                SpawnShield();
            }
            Move(Time.fixedDeltaTime);
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
            Instantiate(Enemy, spawnEnemy.position, spawnEnemy.rotation);
            Repeat();
        }


        private void Move(float delta)
        {
            transform.position += _direction.normalized * (_isSprint ? speed * 20 : speed) * delta;
        }
           

    }
}