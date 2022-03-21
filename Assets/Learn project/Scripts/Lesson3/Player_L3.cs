using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Learnproject
{
    public class Player_L3 : MonoBehaviour
    {
        //���������� ��� ��������
        public Vector3 _direction;
        public float speed = 5f;

        //���������� ��� �����
        public GameObject BombPrefab;
        public Transform spawnBomb;

        //������� ����
        public int bombCount;

        //����
        public GameObject Bullet;
        public Transform spawnBullet;

        //������� ����
        public int bulletCount;

        private void Start()
        {
            bombCount = 3;
            bulletCount = 5;
        }

        void Update()
        {          
            //��������� �����
            if (Input.GetMouseButtonDown(1) && bombCount > 0)
            {
                Instantiate(BombPrefab, spawnBomb.position, spawnBomb.rotation);
                bombCount--;//������� ����� �� �������
                Debug.Log(bombCount);
            }

            //��������
            if (Input.GetMouseButtonDown(0) && bulletCount > 0)
            {
                //������� ��������
                Instantiate(Bullet, spawnBullet.position, spawnBullet.rotation);
                bulletCount--;
                Debug.Log(bulletCount);
            }    
        }

        void FixedUpdate()
        {
            Move(Time.fixedDeltaTime);           
        }

        //����� ��������
        private void Move(float delta)
        {
            var fixedDirection = transform.TransformDirection(_direction.normalized);
            transform.position += fixedDirection * speed * delta;

            //��������
            _direction.x = Input.GetAxis("Horizontal");
            _direction.z = Input.GetAxis("Vertical");
        }        
    }
}