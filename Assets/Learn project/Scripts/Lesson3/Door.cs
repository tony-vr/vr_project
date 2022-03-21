using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private Transform rotatePoint;
    private bool _isStopped;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !_isStopped)
        {
            rotatePoint.Rotate(Vector3.down, 90);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && !_isStopped)
        {
            rotatePoint.Rotate(Vector3.up, 90);
        }
    }
}
