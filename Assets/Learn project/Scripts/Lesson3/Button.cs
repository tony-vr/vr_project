using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//?????? ?????? ????????? ?????? ??????, ????????????? ?? ????. ????? ?????? 6 ??????, ????? ????????? ????? ?????????
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
                _finalDoor.count++;//?????????? ?????????? ??????? ?????? ? ???????? ????????? ?????

                transform.position = transform.position + new Vector3(0, -0.15f, 0);//????????? ??????? ???? ??????? ??????                
                GetComponent<Renderer>().material.color = Color.green;//????? ???? ??????? ??????    
                _isPushed = false;//???????? ?????? ???????, ????? ?????? ??? ?? ??????? ??? ????
            }
        }
    }
}