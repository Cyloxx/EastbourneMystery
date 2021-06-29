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
        public GameObject wallCheck;
        

        void Start()
        {
            ownedCharacter.AttackPower = 5;
            ownedCharacter.SetAttack = true;
            ownedCharacter.SetSecondAttack = false;
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
                ownedCharacter.RemoveHealth(1);
                StartCoroutine(invulnerableCounter());
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

    }
}