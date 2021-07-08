using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace EastBourne
{
    public class Character : MonoBehaviour
    {

        [SerializeField] protected Animator anim;
        [SerializeField] protected Rigidbody2D charRB;
        [SerializeField] protected TMP_Text healthText;
        [SerializeField] protected GameObject attackArea1;
        [SerializeField] protected GameObject attackArea2;
        [SerializeField] protected int health;
        [SerializeField] protected float movementSpeed;
        [SerializeField] protected float jumpForce;
        [SerializeField] protected bool attackReady;
        [SerializeField] protected bool secondAttackReady;
        [SerializeField] protected bool doubleJumpReady;
        [SerializeField] protected bool controllable;
        [SerializeField] protected int randomizer;

        protected Coroutine attackRoutine;

        private int attackPower;
        protected virtual void Start()
        {
            controllable = true;
            attackReady = true;
            secondAttackReady = false;
            doubleJumpReady = false;

        }
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

        public bool AttackReady
        {
            get
            {
                return attackReady;
            }
            set
            {
                attackReady = value;
            }
        }
        public bool SecondAttackReady
        {
            get
            {
                return secondAttackReady;
            }
            set
            {
                secondAttackReady = false;
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

        public void AddHealth(int val)
        {
            if (controllable)
            {
                health += val;
                healthText.SetText("Health: " + health);
                anim.SetTrigger("getHeal");
            }
            
        }
        public void RemoveHealth(int val)
        {
            anim.SetTrigger("takeDamage");
            health -= val;
            if(healthText!=null)
                healthText.SetText("Health: " + health);
        }

        public void Attack()
        {
            if (controllable)
            {
                if (attackReady)
                {
                    PerformAttack();
                }
                if (secondAttackReady && attackArea2 != null)
                    PerformSecondAttack();
            }

        }

        public virtual void PerformAttack()
        {

        }

        public virtual void PerformSecondAttack()
        {

        }

        public void TakeDamage()
        {
            anim.SetTrigger("takeDamage");
            RemoveHealth(1);
            if(GetHealth() == 0)
            {
                Died();
            }
        }


        public  virtual void Died()
        {
            
        }

        public void Move(float side)
        {
            if (controllable)
            {
                float yAngle = side > 0 ? 0 : 180;

                transform.eulerAngles = new Vector3(0, yAngle, 0);
                anim.SetBool("isRunning", Mathf.Abs(side) > 0);
                charRB.velocity = new Vector2(side * movementSpeed * Time.timeScale, charRB.velocity.y); 
            }

        }
        public void Idle()
        {
            if (controllable)
            {
                anim.SetBool("isRunning", false); 
            }
        }

        public void Jump(bool isGrounded)
        {
            if (controllable)
            {
                if (isGrounded)
                {
                    anim.SetTrigger("takeOff");
                    anim.SetBool("isJumping", true);
                    charRB.velocity = Vector2.up * jumpForce;
                    StartCoroutine(doubleJumpCounter());

                }
                else if (!isGrounded && doubleJumpReady)
                {
                    anim.SetBool("isJumping", true);
                    charRB.velocity = Vector2.up * jumpForce;
                    doubleJumpReady = false;
                } 
            }
        }
        IEnumerator doubleJumpCounter()
        {
            yield return new WaitForSeconds(0.1f);
            doubleJumpReady = true;
        }
        public void checkGround(bool isGrounded)
        {
            if (isGrounded) {
                anim.SetBool("isJumping", false);
                doubleJumpReady = false;
            }
                
            else
                anim.SetBool("isJumping", true);
        }
    }
}

/*
    1. Characterin geri kalan kisimlarini doldurma
    2. Input icin command pattern kullanarak farkli input configurasyonlarini implemente etme(touch, joystick, gamepad)

 */