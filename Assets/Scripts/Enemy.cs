using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace EastBourne
{
    public class Enemy : MonoBehaviour
    {
        
        [SerializeField] private int health;
        [SerializeField] private int attackPower;

        public int AttackPower
        {
            get
            {
                return attackPower;
            }
            set
            {
                attackPower = value;
            }
        }

        public int GetHealth()
        {
            return health;
        }

        public void SetHealth(int val)
        {
            health = val;
        }


        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.gameObject.tag=="Attack Area")
            {
                Destroy(gameObject);
            }
        }
    }
}

