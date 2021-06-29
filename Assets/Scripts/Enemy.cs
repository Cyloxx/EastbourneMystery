using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace EastBourne
{
    public class Enemy : MonoBehaviour
    {

        [SerializeField] private Animator anim;
        [SerializeField] private Rigidbody2D enemyRB;
        [SerializeField] private GameObject attackArea1;
        [SerializeField] private GameObject attackArea2;
        [SerializeField] private int health;
        [SerializeField] private int movementSpeed;
        [SerializeField] private int jumpForce;
        private int attackPower;

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

        public void RemoveHealth(int val)
        {
            anim.SetTrigger("takeDamage");
            health -= val;
        }

        public void Attack()
        {
            anim.SetTrigger("isAttacking");
            attackArea1.SetActive(true);
            anim.SetTrigger("isAttacking2");
            attackArea2.SetActive(true);

            StartCoroutine(endAttack());

        }
        IEnumerator endAttack()
        {
            yield return new WaitForSeconds(0.1f);
            attackArea1.SetActive(false);
            attackArea2.SetActive(false);
        }
        public void Move(float side)
        {
            float yAngle = side > 0 ? 0 : 180;

            transform.eulerAngles = new Vector3(0, yAngle, 0);
            anim.SetBool("isRunning", Mathf.Abs(side) > 0);
            enemyRB.velocity = new Vector2(side * movementSpeed * Time.deltaTime, enemyRB.velocity.y);

        }
        public void Idle()
        {
            anim.SetBool("isRunning", false);
        }

        public void Jump(bool isGrounded)
        {
            if (isGrounded)
            {
                anim.SetTrigger("takeOff");
                anim.SetBool("isJumping", true);
                enemyRB.velocity = Vector2.up * jumpForce;

                Debug.Log("regular jump(without command)");
            }

        }

        public void checkGround(bool isGrounded)
        {
            if (isGrounded)
                anim.SetBool("isJumping", false);
            else
                anim.SetBool("isJumping", true);
        }


        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "Attack Area")
            {
                health--;
                if(health==0)
                Destroy(gameObject);
            }
        }
    }
}

