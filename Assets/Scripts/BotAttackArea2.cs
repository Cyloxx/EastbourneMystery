using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EastBourne
{
    public class BotAttackArea2 : MonoBehaviour
    {
        public List<GameObject> ObjectsInAttackArea2 = new List<GameObject>();

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "Player" && !collision.isTrigger)
            {
                ObjectsInAttackArea2.Add(collision.gameObject);
            }
        }
        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "Player")
            {
                ObjectsInAttackArea2.Remove(collision.gameObject);
            }
        }
    }
}
