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
            charRB.velocity = new Vector2(side * movementSpeed * Time.deltaTime, charRB.velocity.y);

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

                Debug.Log("regular jump(without command)");
            }
          
        }

        public void JumpCmd(bool isGrounded)
        {
            ICommand command = new JumpCommand(gameObject, jumpForce, isGrounded, anim);
            CommandInvoker.AddCommand(command);
        }

        public void JumpTouchPad(bool isGrounded)
        {
            ICommand command = new JumpCommand(gameObject, jumpForce, isGrounded, anim);
            CommandInvoker.AddCommand(command);
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