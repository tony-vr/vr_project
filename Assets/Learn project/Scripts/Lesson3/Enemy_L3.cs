using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Learnproject
{
    public class Enemy_L3 : MonoBehaviour
    {       
        void FixedUpdate()
        {
            Move();
        }

        void Move()
        {                        
            transform.position += transform.forward * 5 * Time.fixedDeltaTime;            
        }

        //разворот при встрече с кубом, который установлен, как ограничитель движения противника.
        //как сделать, чтобы противник двигался в нужном мне диапазоне, я пока не знаю
        void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("MoveTag"))
            {
                transform.Rotate(0f, 180.0f, 0.0f);                
            }
        }
    }
}