using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Debug.Log(other.gameObject);
            Destroy(gameObject);
            Destroy(other.gameObject,1);//удаляем объект через секунду после "взрыва"
        }
    }
}
