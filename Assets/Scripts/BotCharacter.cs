using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace EastBourne
{
    public class BotCharacter : Character
    {
        public Transform target1;
        public Transform target2;
        public int currentTarget;
        public GameObject player;
        public float waitTime;
        public float waitTimeCap;
        public float attackTime;
        public float attackTimeCap;
        public float attackTimeRandomizer;

        protected override void Start()
        {
            base.Start();
            
            waitTime = 1f;
            waitTimeCap = 1f;
            movementSpeed = 1;  
            currentTarget = 1;
            attackTime = 1;
            attackTimeCap = 1;
        }
        private void Update()
        {
            if (currentTarget == 1 && Vector2.Distance(transform.position, target1.position) > 0.2f)
            {
                gameObject.transform.position = Vector2.MoveTowards(transform.position, target1.position, movementSpeed * Time.deltaTime);
                transform.eulerAngles = new Vector3(0, 180, 0);
                anim.SetBool("isRunning", true);
            }  
            else if (currentTarget == 1 && Vector2.Distance(transform.position, target1.position) < 0.2f)
            {
                if(waitTime <= 0)
                {
                    currentTarget = 2;
                    waitTime = waitTimeCap;
                }
                else
                {
                    anim.SetBool("isRunning", false);
                    waitTime -= Time.deltaTime;
                }
            }
            else if(currentTarget == 2 && Vector2.Distance(transform.position, target2.position) > 0.2f)
            {
                gameObject.transform.position = Vector2.MoveTowards(transform.position, target2.position, movementSpeed * Time.deltaTime);
                transform.eulerAngles = new Vector3(0, 0, 0);
                anim.SetBool("isRunning", true);
            }
            else if (currentTarget == 2 && Vector2.Distance(transform.position, target2.position) < 0.2f)
            {
                if (waitTime <= 0)
                {
                    attackTimeRandomizer = Random.Range(1, 2);
                    currentTarget = 1;
                    waitTime = attackTimeRandomizer;
                }
                else
                {
                    anim.SetBool("isRunning", false);
                    waitTime -= Time.deltaTime;
                }
            }
            else if(currentTarget == -1 && Vector2.Distance(transform.position,player.transform.position) > 1f)
            {
                gameObject.transform.position = Vector2.MoveTowards(transform.position, player.transform.position, movementSpeed * Time.deltaTime);
                if(player.transform.position.x >= transform.position.x)
                {
                    transform.eulerAngles = new Vector3(0, 0, 0);
                }
                else
                {
                    transform.eulerAngles = new Vector3(0, 180, 0);
                }

                anim.SetBool("isRunning", false);
            }

            if(currentTarget == -1)
            {
                if (attackTime <= 0)
                {
                    PerformAttack();
                    attackTime = attackTimeCap;
                }
                else
                {
                    attackTime -= Time.deltaTime;
                }
            }
        }
        public override void PerformAttack()
        {
            Debug.Log("override bot attack");
            base.PerformAttack();
            attackRoutine = StartCoroutine(PerformAttackRoutine());
        }

        IEnumerator PerformAttackRoutine()
        {
            if (attackArea1 != null)
            {
                foreach (var x in attackArea1.GetComponent<BotAttackArea1>().ObjectsInAttackArea1)
                {
                    x.GetComponent<MainCharacter>().TakeDamage();
                }
            }

            anim.SetTrigger("isAttacking");
            Debug.Log("bot attack anim");
            attackReady = false;
            yield return new WaitForSeconds(0.3f);
            yield return new WaitForSeconds(0.2f);
            attackReady = true;
        }

        public override void Died()
        {
            Debug.Log("bot died");
            Destroy(gameObject);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            /*if (collision.gameObject.tag == "Attack Area")
            {
                Debug.Log("bot took damage");
                RemoveHealth(1);
                if (GetHealth() == 0)
                {
                    Destroy(gameObject);
                }
            }*/
            if(collision.gameObject.tag== "Player")
            {
                currentTarget = -1;
            }
        }
        private void OnTriggerExit2D(Collider2D collision)
        {
            if(collision.gameObject.tag == "Player")
            {
                currentTarget = 1;
            }
        }

        
    }

}