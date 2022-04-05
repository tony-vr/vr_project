using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

namespace Learnproject
{
    public class Enemy_L3 : MonoBehaviour
    {
        private NavMeshAgent _agent;
        public float speed = 6f;

        //��� ������
        public Transform[] waypoints;//������ � ������� ������
        int m_CurrentWayPointIndex;//������� ����� ������         

        //��� �������������
        [SerializeField] public Player_L3 _player; //�� ��� ����� ��������� ������
        public Transform Target;//������� ������, ������� ����� ������������ ������
        [Range(0, 360)] public float ViewAngle = 90f;
        public Transform EnemyEye;
        public float ViewDistance = 15f;       
        private bool _isDetected = false;//��������, ��� ��������� ���������� ������ � ������ ������
        [SerializeField] private GameObject _bulletPrefab;

        //����
        public GameObject Bullet;
        public Transform spawnBullet;


        void Awake()
        {
            _agent = GetComponent<NavMeshAgent>();//��������� ���������
            _player = FindObjectOfType<Player_L3>();//������� ������
            _agent.speed = speed;
        }

        private void Start()
        {
            _agent.SetDestination(waypoints[0].position);//����� ��������� ���������� � ������ ����� ������            
        }

        //����� ����������� ������ � ���� ���������
        private bool IsInView() // true ���� ���� �����
        {            
            float realAngle = Vector3.Angle(EnemyEye.forward, Target.position - EnemyEye.position);
            
                if (realAngle < ViewAngle / 2f && Vector3.Distance(EnemyEye.position, Target.position) <= ViewDistance)
                {
                return true;                   
                }
            
            return false;
        }

        void Update()
        {
            if (_isDetected is false)//���� ��������� �� ����� ������, �� �� ���� �� ������
            {
                Waypoint();
            }
            
            if (IsInView() is true)
            {
                _isDetected = true;
                Debug.Log("detected");
                MoveToTarget();
                Fire();
            }

            //���� ����� ����� �� ���� ���������
            if ( !IsInView() && _isDetected is true)
            {
                Debug.Log("undetected");
                StartCoroutine(Stop());
                
            }
            DrawViewState();
            Debug.DrawRay(EnemyEye.position, EnemyEye.forward * ViewDistance, Color.blue);

        }

        
        private void MoveToTarget() 
        {
            _agent.SetDestination(Target.position);            
        }

        private void Waypoint()
        {
            if (_agent.remainingDistance <= _agent.stoppingDistance)
            {
                m_CurrentWayPointIndex = (m_CurrentWayPointIndex + 1) % waypoints.Length;
                _agent.SetDestination(waypoints[m_CurrentWayPointIndex].position);
            }
        }

        private IEnumerator Stop()
        {
            {
                _agent.SetDestination(transform.position);
                yield return new WaitForSeconds(5);
                _isDetected = false;
            }
        }

        private void DrawViewState()
        {
            Vector3 left = EnemyEye.position + Quaternion.Euler(new Vector3(0, ViewAngle / 2f, 0)) * (EnemyEye.forward * ViewDistance);
            Vector3 right = EnemyEye.position + Quaternion.Euler(-new Vector3(0, ViewAngle / 2f, 0)) * (EnemyEye.forward * ViewDistance);
            Debug.DrawLine(EnemyEye.position, left, Color.yellow);
            Debug.DrawLine(EnemyEye.position, right, Color.yellow);
        }

        private void Fire()
        {
            var bulletObj = Instantiate(Bullet, spawnBullet.position, Quaternion.Euler(-10, 0, 0));
            var bullet = bulletObj.GetComponent<Bullet>();
            bullet.Init(spawnBullet);
        }
    }
}