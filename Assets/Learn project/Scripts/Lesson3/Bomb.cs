using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Learnproject
{

    //скрипт для бомбы, которую оставляет игрок для уничтожения движущегося противника
    public class Bomb : MonoBehaviour
    {

        void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Enemy"))
            {
                Debug.Log("Bomb");
                ExplosionDamage();
            }
        }


        void ExplosionDamage()
        {
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, 4);
            foreach (var hitCollider in hitColliders)
            {
                Rigidbody rb = hitCollider.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    Debug.Log(hitCollider);
                    //hitCollider.GetComponent<Rigidbody>().AddForce(transform.position - hitCollider.transform.position);
                    rb.AddForce((hitCollider.transform.position - transform.position) * 1000);
                    Destroy(gameObject);
                }
            }
        }
    }
}