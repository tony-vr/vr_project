using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//скрипт для пули игрока
namespace Learnproject
{
    public class Bullet : MonoBehaviour
    {
        void FixedUpdate()
        {
            transform.Translate(new Vector3(0, 0, 0.1f));
            Destroy(gameObject, 5f);
        }
    }
}