using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EastBourne
{
    public class AttackArea2 : MonoBehaviour
    {
        public List<GameObject> ObjectsInAttackArea2 = new List<GameObject>();

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "Enemy" && !collision.isTrigger)
            {
                ObjectsInAttackArea2.Add(collision.gameObject);
            }
        }
        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "Enemy")
            {
                ObjectsInAttackArea2.Remove(collision.gameObject);
            }
        }
    }
}
