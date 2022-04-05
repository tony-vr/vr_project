using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Learnproject
{
    public class Player_L3 : MonoBehaviour
    {
        //���������� ��� ��������
        public Vector3 _direction;
        public float speed = 5f;
        public float speedRotate = 20f;



        //���������� ��� ������
        [SerializeField] private float _jumpForce = 10f;


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
            bombCount = 20;
            bulletCount = 50;

        }

        void Update()
        {                    
            //��������� �����
            if (Input.GetMouseButtonDown(1) && bombCount > 0)
            {
                Instantiate(BombPrefab, spawnBomb.position, spawnBomb.rotation);
                bombCount--;//������� ����� �� �������                
            }

            
            //��������
            if (Input.GetMouseButtonDown(0) && bulletCount > 0)
            {
                //������� ��������
                Fire();
                bulletCount--;
            }

            //������
            if (Input.GetKeyDown(KeyCode.Space))
                GetComponent<Rigidbody>().AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);

            //�������� �����
            if (Input.GetKeyDown(KeyCode.F))
            {
                ExplosionDamage();
            }            
        }

        //�������� �����
        void ExplosionDamage()
        {
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, 3);
            foreach (var hitCollider in hitColliders)
            {
                Rigidbody rb = hitCollider.GetComponent<Rigidbody>();
                if (rb != null)
                {                  
                    rb.AddForce((hitCollider.transform.position - transform.position) * 500);
                }

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
            _direction.z = Input.GetAxis("Vertical");
            _direction.x = Input.GetAxis("Horizontal");
            transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X") * speedRotate, 0));

            //�������
            //transform.Rotate(Vector3.up, Input.GetAxis("Horizontal") * _speed_rotate * Time.deltaTime);
        }

        private void Fire()
        {
            var bulletObj = Instantiate(Bullet, spawnBullet.position, Quaternion.Euler(-45,0,0));
            var bullet = bulletObj.GetComponent<Bullet>();
            bullet.Init(spawnBullet);
        }    
    }
}