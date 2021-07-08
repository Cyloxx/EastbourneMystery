using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EastBourne
{
    public class BotAttackArea3 : MonoBehaviour
    {
        public List<GameObject> ObjectsInAttackArea3 = new List<GameObject>();

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "Player" && !collision.isTrigger)
            {
                ObjectsInAttackArea3.Add(collision.gameObject);
            }
        }
        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "Player")
            {
                ObjectsInAttackArea3.Remove(collision.gameObject);
            }
        }
    }
}
