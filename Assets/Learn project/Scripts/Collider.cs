using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Learnproject
{
    public class Collider : MonoBehaviour
    {

        private void OnTriggerEnter(Collider other)
        {
            Debug.Log("collide");
        }
    }
}