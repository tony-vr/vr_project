using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Learnproject
{
    public class BulletAmo : MonoBehaviour
    {
        private Player_L3 _player;
        //При данном коллайдере, пополняетсся запас потронов, а сам объект исчезает
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                _player = FindObjectOfType<Player_L3>();
                _player.bulletCount = _player.bulletCount + 10;
                Destroy(gameObject);
                Debug.Log(_player.bulletCount);                
            }
        }
    }
}