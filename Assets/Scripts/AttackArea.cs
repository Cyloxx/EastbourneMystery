using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EastBourne
{
    public class AttackArea : MonoBehaviour
    {
        public List<GameObject> ObjectsInAttackArea = new List<GameObject>();

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "Enemy" && !collision.isTrigger)
            {
                ObjectsInAttackArea.Add(collision.gameObject);
            }
        }
        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "Enemy")
            {
                ObjectsInAttackArea.Remove(collision.gameObject);
            }
        }
    } 
}
