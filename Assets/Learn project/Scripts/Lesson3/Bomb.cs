using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//скрипт для бомбы, которую оставляет игрок для уничтожения движущегося противника
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
