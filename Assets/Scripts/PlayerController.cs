using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EastBourne
{
    public class PlayerController : CharacterController
    {
        public float movementInput;
        public bool isGrounded;
        private float checkRadius = 0.1f;
        public LayerMask whatIsGround;
        public Transform feetPos;

        void Start()
        {
            ownedCharacter.AttackPower = 5;
        }
        
        void Update()
        {
            if (Mathf.Abs(movementInput) != 0)
                ownedCharacter.Move(movementInput);
            else
                ownedCharacter.Idle();

            if (Input.GetKeyDown(KeyCode.Space))
                ownedCharacter.Jump(isGrounded);

            if (Input.GetKeyDown(KeyCode.F))
                ownedCharacter.Attack();

            if (Input.GetKeyDown(KeyCode.X))
            {
                // jump command
                ownedCharacter.JumpCmd(isGrounded);
                Debug.Log("jump command sent by keyboard (command)");
            }
              
            ownedCharacter.checkGround(isGrounded);
        }

        public void JumpButton()
        {
            ownedCharacter.JumpTouchPad(isGrounded);
            Debug.Log("jump command sent by touch screen (command)");
        }

        private void FixedUpdate()
        {
            movementInput = Input.GetAxisRaw("Horizontal");
            isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "Enemy")
                ownedCharacter.RemoveHealth(1);
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