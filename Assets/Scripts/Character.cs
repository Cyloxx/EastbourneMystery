using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace EastBourne
{
    public class Character : MonoBehaviour
    {

        [SerializeField] private Animator anim;
        [SerializeField] private Rigidbody2D charRB;
        [SerializeField] private TMP_Text healthText;
        [SerializeField] private GameObject attackArea1;
        [SerializeField] private GameObject attackArea2;
        [SerializeField] private int health;
        [SerializeField] private float movementSpeed;
        [SerializeField] private float jumpForce;   
        [SerializeField] private bool attackReady;
        [SerializeField] private bool secondAttackReady;

        private int attackPower;
        public void Start()
        {
            attackReady = true;
            secondAttackReady = false;
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

        public bool SetAttack
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
        public bool SetSecondAttack
        {
            get
            {
                return secondAttackReady;
            }
            set
            {
                attackReady = false;
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
            health += val;
            healthText.SetText("Health: " + health);
            anim.SetTrigger("getHeal");
        }
        public void RemoveHealth(int val)
        {
            anim.SetTrigger("takeDamage");
            health -= val;
            healthText.SetText("Health: " + health);
        }

        public void Attack()
        {
            if (attackReady)
            {
                 StartCoroutine(performAttack());
            }
            if(secondAttackReady && attackArea2!=null)
                 StartCoroutine(performSecondAttack());

        }
        IEnumerator performAttack()
        {
            anim.SetTrigger("isAttacking");
            attackArea1.SetActive(true);
            attackReady = false;
            yield return new WaitForSeconds(0.3f);
            attackArea1.SetActive(false);
            secondAttackReady = true;
            yield return new WaitForSeconds(0.2f);
            attackReady = true;
            secondAttackReady = false;
        }
        IEnumerator performSecondAttack()
        {
            anim.SetTrigger("isAttacking2");
            attackArea2.SetActive(true);
            secondAttackReady = false;
            yield return new WaitForSeconds(0.2f);
            attackArea2.SetActive(false);
        }

        public void Move(float side)
        {
            float yAngle = side > 0 ? 0 : 180;

            transform.eulerAngles = new Vector3(0, yAngle, 0);
            anim.SetBool("isRunning", Mathf.Abs(side) > 0);
            charRB.velocity = new Vector2(side * movementSpeed * Time.timeScale, charRB.velocity.y);

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
                charRB.velocity = Vector2.up * jumpForce;
            }
        }

        public void checkGround(bool isGrounded)
        {
            if (isGrounded)
                anim.SetBool("isJumping", false);
            else
                anim.SetBool("isJumping", true);
        }
    }
}

/*
    1. Characterin geri kalan kisimlarini doldurma
    2. Input icin command pattern kullanarak farkli input configurasyonlarini implemente etme(touch, joystick, gamepad)

 */