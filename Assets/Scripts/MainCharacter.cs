using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EastBourne
{
    public class MainCharacter : Character
    {
        protected override void Start()
        {
            base.Start();
        }

        public override void Died()
        {
            base.Died();
            SetHealth(0);
            controllable = false;
            anim.SetTrigger("died");
            Debug.Log("character died");
            this.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            this.gameObject.GetComponent<PolygonCollider2D>().enabled = false;
        }

        public override void PerformAttack()
        {
            Debug.Log("mainchar attack");
            base.PerformAttack();

            if (attackRoutine == null)
                attackRoutine = StartCoroutine(PerformAttackRoutine());
        }

        IEnumerator PerformAttackRoutine()
        {
            if(attackArea1 != null)
            {
                foreach (var x in attackArea1.GetComponent<AttackArea>().ObjectsInAttackArea)
                {
                    if(x.gameObject.name == "BossBody")
                    {
                        x.GetComponent<BotBossCharacter>().TakeDamage();
                    }
                    else
                    {
                        x.GetComponent<BotCharacter>().TakeDamage();
                    }
                }
            }   
            
            anim.SetTrigger("isAttacking");
            attackReady = false;
            yield return new WaitForSeconds(0.3f);
            secondAttackReady = true;
            yield return new WaitForSeconds(0.2f);
            attackReady = true;
            secondAttackReady = false;
            attackRoutine = null;
        }

        public override void PerformSecondAttack()
        {
            base.PerformSecondAttack();
            attackRoutine = StartCoroutine(PerformSecondAttackRoutine());
        }

        IEnumerator PerformSecondAttackRoutine()
        {

            if (attackArea2 != null)
            {
                foreach (var x in attackArea2.GetComponent<AttackArea2>().ObjectsInAttackArea2)
                {
                    if (x.gameObject.name == "BossBody")
                    {
                        x.GetComponent<BotBossCharacter>().TakeDamage();
                    }
                    else
                    {
                        x.GetComponent<BotCharacter>().TakeDamage();
                    }
                }
            }
            anim.SetTrigger("isAttacking2");
            secondAttackReady = false;
            yield return new WaitForSeconds(0.2f);
        }
    }
}
