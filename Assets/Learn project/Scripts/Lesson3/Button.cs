using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//данный скрипт описывает работу кнопок, расположенных на полу. Нужно нажать 6 кнопок, чтобы финальная дверь открылась
namespace Learnproject
{
    public class Button : MonoBehaviour
    {
        private FinalDoor _finalDoor;
        bool _isPushed = true;

        void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player") && _isPushed)
            {
                _finalDoor = FindObjectOfType<FinalDoor>();
                _finalDoor.count++;//увеличиваю количество нажатых кнопок в счетчике финальной двери

                transform.position = transform.position + new Vector3(0, -0.15f, 0);//перемещаю немного вниз нажатую кнопку                
                GetComponent<Renderer>().material.color = Color.green;//меняю цвет нажатой кнопки    
                _isPushed = false;//фиксирую кнопку нажатой, чтобы каждый раз не уходила еще ниже
            }
        }
    }
}