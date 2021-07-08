using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EastBourne
{
    public class BotAttackArea1 : MonoBehaviour
    {
        public List<GameObject> ObjectsInAttackArea1 = new List<GameObject>();

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "Player" && !collision.isTrigger)
            {
                ObjectsInAttackArea1.Add(collision.gameObject);
            }
        }
        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "Player")
            {
                ObjectsInAttackArea1.Remove(collision.gameObject);
            }
        }
    }
}
