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

        void Start()
        {            
            _player = FindObjectOfType<Player_L3>();
            timeBwShots = startTimeBwShots;
        }

        
        void Update()
        {
            if (Vector3.Distance(transform.position, _player.transform.position) < 10)
            {
                var direction = _player.transform.position - transform.position;
                var stepRotate = Vector3.RotateTowards(transform.forward, direction, speedRotation * Time.deltaTime, 0f);
                transform.rotation = Quaternion.LookRotation(stepRotate);                
            }

            if (Vector3.Distance(transform.position, _player.transform.position) < 6 && timeBwShots <= 0)
            {
                //Начинаю стрельбу
                var bulletObj = Instantiate(_bulletPrefab, _spawnPosition.position, _spawnPosition.rotation);
                var bul = bulletObj.GetComponent<Bullet_Enemy>();
                bul.Init(_player.transform, 10, 0.05f);
                timeBwShots = startTimeBwShots;
            }
            else
            {
                timeBwShots -= Time.deltaTime;
            }
        }        
    }
}