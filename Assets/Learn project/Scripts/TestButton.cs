using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Learnproject
{
    public class TestButton : MonoBehaviour
    {        
        private FinalDoor _finalDoor;
        bool _isPushed = true;

        void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player") && _isPushed)
            {
                _finalDoor = FindObjectOfType<FinalDoor>();
                _finalDoor.count++;
                transform.position = transform.position + new Vector3(0, -0.15f, 0);//перемещаю немного вниз нажатую кнопку
                _isPushed = false;//фиксирую кнопку нажатой, чтобы каждый раз не уходила еще ниже
                GetComponent<Renderer>().material.color = Color.green;//мен€ю цвет нажатой кнопки    
            }
        }        
    }
}