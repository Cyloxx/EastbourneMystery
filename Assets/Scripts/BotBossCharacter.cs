using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EastBourne
{
    public class BotBossCharacter : Character
    {
        [SerializeField] protected GameObject attackArea3;

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
                if(transform.position.x > target1.position.x)
                {
                    transform.eulerAngles = new Vector3(0, 180, 0);
                }
                else
                {
                    transform.eulerAngles = new Vector3(0, 0, 0);
                }
                anim.SetBool("isRunning", true);
            }
            else if (currentTarget == 1 && Vector2.Distance(transform.position, target1.position) < 0.2f)
            {
                if (waitTime <= 0)
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
            else if (currentTarget == 2 && Vector2.Distance(transform.position, target2.position) > 0.2f)
            {
                gameObject.transform.position = Vector2.MoveTowards(transform.position, target2.position, movementSpeed * Time.deltaTime);
                if (transform.position.x > target2.position.x)
                {
                    transform.eulerAngles = new Vector3(0, 180, 0);
                }
                else
                {
                    transform.eulerAngles = new Vector3(0, 0, 0);
                }
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
            else if (currentTarget == -1 && Vector2.Distance(transform.position, player.transform.position) > 1f)
            {
                gameObject.transform.position = Vector2.MoveTowards(transform.position, player.transform.position, movementSpeed * Time.deltaTime);
                if (transform.position.x > player.transform.position.x)
                {
                    transform.eulerAngles = new Vector3(0, 180, 0);
                }
                else
                {
                    transform.eulerAngles = new Vector3(0, 0, 0);
                }

                anim.SetBool("isRunning", true);
            }

            if (currentTarget == -1)
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
            base.PerformAttack();
            Debug.Log("override boss attack");
            base.PerformAttack();
            attackRoutine = StartCoroutine(PerformAttackRoutine());
        }
        
        IEnumerator PerformAttackRoutine()
        {
            randomizer = Random.Range(0, 3);
            switch (randomizer)
            {
                case 0:
                    anim.SetTrigger("isAttacking");
                    attackReady = false;
                    if (attackArea1 != null)
                    {
                        foreach (var x in attackArea1.GetComponent<BotAttackArea1>().ObjectsInAttackArea1)
                        {
                            Debug.Log("attac 1 dmg");
                            x.GetComponent<MainCharacter>().TakeDamage();
                        }
                    }

                    break;
                case 1:
                    anim.SetTrigger("isAttacking2");
                    attackReady = false;
                    if (attackArea2 != null)
                    {
                        foreach (var x in attackArea2.GetComponent<BotAttackArea2>().ObjectsInAttackArea2)
                        {
                            Debug.Log("attac 2 dmg");
                            x.GetComponent<MainCharacter>().TakeDamage();
                        }
                    }
                    break;
                case 2:
                    anim.SetTrigger("isAttacking3");
                    attackReady = false;
                    if (attackArea3 != null)
                    {
                        foreach (var x in attackArea3.GetComponent<BotAttackArea3>().ObjectsInAttackArea3)
                        {
                            Debug.Log("attac 3 dmg");
                            x.GetComponent<MainCharacter>().TakeDamage();
                        }
                    }
                    break;
            }

            yield return new WaitForSeconds(0.5f);
            attackReady = true;
        }

        public override void Died()
        {
            Debug.Log("boss died");
            Destroy(gameObject);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
          
            if (collision.gameObject.tag == "Player")
            {
                currentTarget = -1;
            }
        }
        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "Player")
            {
                currentTarget = 1;
            }
        }
    }

} 
