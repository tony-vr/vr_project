using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//данный скрипт описывает работу кнопок, расположенных на полу. Ќужно нажать 6 кнопок, чтобы финальна€ дверь открылась
namespace Learnproject
{
    public class Button : MonoBehaviour
    {
        private FinalDoor _finalDoor;
        //bool _isPushed = false;

        void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Button_Cube"))
            {
                _finalDoor = FindObjectOfType<FinalDoor>();
                _finalDoor.count++;//увеличиваю количество нажатых кнопок в счетчике финальной двери

                transform.position = transform.position + new Vector3(0, -0.15f, 0);//перемещаю немного вниз нажатую кнопку                
                GetComponent<Renderer>().material.color = Color.green;//мен€ю цвет нажатой кнопки    
                other.GetComponent<Renderer>().material.color = Color.green;
                //_isPushed = true;//фиксирую кнопку нажатой, чтобы каждый раз не уходила еще ниже
            }
        }
        void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Button_Cube"))
            {
                _finalDoor = FindObjectOfType<FinalDoor>();
                _finalDoor.count--;//увеличиваю количество нажатых кнопок в счетчике финальной двери

                transform.position = transform.position + new Vector3(0, 0.15f, 0);//перемещаю немного вниз нажатую кнопку                
                GetComponent<Renderer>().material.color = Color.white;//мен€ю цвет нажатой кнопки    
                other.GetComponent<Renderer>().material.color = Color.white;
                //_isPushed = false;//фиксирую кнопку нажатой, чтобы каждый раз не уходила еще ниже
            }
        }
    }
}