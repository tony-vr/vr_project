using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Learnproject
{
    public class Player_L3 : MonoBehaviour
    {
        //переменные для движения
        public Vector3 _direction;
        public float speed = 5f;

        //переменные для бомбы
        public GameObject BombPrefab;
        public Transform spawnBomb;

        //счетчик бомб
        public int bombCount;

        //пули
        public GameObject Bullet;
        public Transform spawnBullet;

        //счетчик пуль
        public int bulletCount;

        private void Start()
        {
            bombCount = 3;
            bulletCount = 5;
        }

        void Update()
        {          
            //установка бомбы
            if (Input.GetMouseButtonDown(1) && bombCount > 0)
            {
                Instantiate(BombPrefab, spawnBomb.position, spawnBomb.rotation);
                bombCount--;//убавляю бомбу из запасов
                Debug.Log(bombCount);
            }

            //стрельба
            if (Input.GetMouseButtonDown(0) && bulletCount > 0)
            {
                //Начинаю стрельбу
                Instantiate(Bullet, spawnBullet.position, spawnBullet.rotation);
                bulletCount--;
                Debug.Log(bulletCount);
            }    
        }

        void FixedUpdate()
        {
            Move(Time.fixedDeltaTime);           
        }

        //Метод движения
        private void Move(float delta)
        {
            var fixedDirection = transform.TransformDirection(_direction.normalized);
            transform.position += fixedDirection * speed * delta;

            //движение
            _direction.x = Input.GetAxis("Horizontal");
            _direction.z = Input.GetAxis("Vertical");
        }        
    }
}