using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Enemy : MonoBehaviour
{
    Transform _target;
    private float _speed;
    public void Init(Transform target,float lifetime, float speed)
    {
        _target = target;
        _speed = speed;
        Destroy(gameObject, lifetime);
    }

    
    void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, _target.position, _speed);
    }
}
