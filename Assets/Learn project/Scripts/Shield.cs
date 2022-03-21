using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Learnproject
{
    public class Shield : MonoBehaviour, ITakeDamage
    {
        [SerializeField] private float _durability = 60f;
        // Start is called before the first frame update
        public void Init(float durability)
        {

            _durability = durability;
            Destroy(gameObject, 10f);
        }

        public void Hit(float damage)
        {
            _durability -= damage;
            if (_durability <= 0)
                Destroy(gameObject);
        }

    }
}