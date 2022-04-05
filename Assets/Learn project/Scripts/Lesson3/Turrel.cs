using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Learnproject
{
    public class Turrel : MonoBehaviour
    {
        [SerializeField] private Player_L3 _player;
        [SerializeField] private float speedRotation;

        [SerializeField] private GameObject _bulletPrefab;
        [SerializeField] private Transform _spawnPosition;

        private float timeBwShots;
        public float startTimeBwShots;
        private bool _isfire = true;


        void Start()
        {            
            _player = FindObjectOfType<Player_L3>();
            timeBwShots = startTimeBwShots;
        }

        
        void Update()
        {
            Ray ray = new Ray(_spawnPosition.position, transform.forward);
            Debug.DrawRay(_spawnPosition.position, transform.forward * 6, Color.blue);

            if (Vector3.Distance(transform.position, _player.transform.position) < 10)
            {
                var direction = _player.transform.position - transform.position;
                var stepRotate = Vector3.RotateTowards(transform.forward, direction, speedRotation * Time.deltaTime, 0f);
                transform.rotation = Quaternion.LookRotation(stepRotate);                
            }

            if (Vector3.Distance(transform.position, _player.transform.position) < 6 && timeBwShots <= 0)
            {
                //Начинаю стрельбу
                //var bulletObj = Instantiate(_bulletPrefab, _spawnPosition.position, _spawnPosition.rotation);
                //var bul = bulletObj.GetComponent<Bullet_Enemy>();
                //bul.Init(_player.transform, 10, 0.05f);
                //timeBwShots = startTimeBwShots;

                if (_isfire)
                    Repeat_Fire();
            }
            else
            {
                timeBwShots -= Time.deltaTime;
            }
        }

        private IEnumerator Fire()
        {
            Debug.Log("Fire");

            

            var bulletObj = Instantiate(_bulletPrefab, _spawnPosition.position, _spawnPosition.rotation);
            var bullet = bulletObj.GetComponent<Bullet>();
            bullet.Init(_player.transform);
            yield return new WaitForSeconds(1f);
            _isfire = true;

        }

        private void Repeat_Fire()
        {
            _isfire = false;
            StartCoroutine(Fire());
        }
    }
}