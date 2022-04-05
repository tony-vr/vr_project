using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//скрипт, описывающий открытие финальной двери.
namespace Learnproject
{
    public class FinalDoor : MonoBehaviour        
    {       
        [SerializeField] private Transform rotatePoint;
        public int count = 0;
        private bool _isOpen = false;

        //счетчик нажатых кнопок
        public Text buttonsText;

        //когда нажаты 6 кнопок, то дверь открывается
        private void Update()
        {            
            if (count == 6 && _isOpen is false)
            {
                OpenDoor();                
            }

            buttonsText.text = count.ToString();
        }

        public void OpenDoor()
        {
            if (!_isOpen)
            {
                rotatePoint.Rotate(Vector3.down, 90);
                _isOpen = true;
            }            
        }
    }
}