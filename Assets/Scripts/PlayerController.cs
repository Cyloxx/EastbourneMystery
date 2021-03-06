using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EastBourne
{
    public class PlayerController : CharacterController
    {
        [SerializeField] private GameInputs gameInputs;

        public float movementInput;
        public bool isGrounded;
        public bool invulnerable;
        private float checkRadius = 0.1f;
        public LayerMask whatIsGround;
        public Transform feetTransform;
        

        void Start()
        {
            ownedCharacter = GetComponent<Character>();
            ownedCharacter.AttackPower = 5;
            ownedCharacter.AttackReady = true;
            ownedCharacter.SecondAttackReady = false;
            invulnerable = false;
        }
        
        void Update()
        {
            if (Mathf.Abs(gameInputs.GetMove()) != 0)
                ownedCharacter.Move(movementInput);
            else
                ownedCharacter.Idle();

            if (gameInputs.GetJump())
                ownedCharacter.Jump(isGrounded);

            if (gameInputs.GetAttack())
                ownedCharacter.Attack();

            ownedCharacter.checkGround(isGrounded);
        }

        private void FixedUpdate()
        {
            movementInput = gameInputs.GetMove();
            isGrounded = Physics2D.OverlapCircle(feetTransform.position, checkRadius, whatIsGround);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "Enemy" && invulnerable == false)
            {
                invulnerable = true;
                ownedCharacter.TakeDamage();
                StartCoroutine(invulnerableCounter());
            }
            if (collision.gameObject.tag == "Death")
            {
                ownedCharacter.Died();
            }

            
        }
        IEnumerator invulnerableCounter()
        {
            yield return new WaitForSeconds(0.5f);
            invulnerable = false;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.gameObject.tag == "Health")
            {
                Destroy(collision.gameObject);
                ownedCharacter.AddHealth(1);
            }
        }
      /*  void OnTriggerStay2D(Collider2D col)
        {
            if (col.gameObject.layer == LayerMask.NameToLayer("Ground"))
            {
                if (isRightSensor)
                    character.AddForce(new Vector2(-bounceForce, 0));
                else
                    character.AddForce(new Vector2(bounceForce, 0));
            }

        }*/


    }
}