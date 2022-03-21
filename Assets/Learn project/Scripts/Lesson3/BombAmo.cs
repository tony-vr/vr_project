using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Learnproject
{
    public class BombAmo : MonoBehaviour
    {
        private Player_L3 _player;
        //пополение запаса бомб при соприкосновении с объектом
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                _player = FindObjectOfType<Player_L3>();
                _player.bombCount = _player.bombCount + 3;
                Debug.Log(_player.bombCount);
                Destroy(gameObject);//убираю объект
            }
        }
    }
}