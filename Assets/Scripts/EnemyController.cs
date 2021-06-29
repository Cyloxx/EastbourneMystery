using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EastBourne
{
     //AI works here
    public class EnemyController : CharacterController
    {

        public bool isGrounded;
        private float checkRadius = 0.1f;
        public LayerMask whatIsGround;
        public Transform feetPos;

        void Start()
        {

        }
        void Update()
        {
            ownedCharacter.checkGround(isGrounded);


            //if (Input.GetKeyDown(KeyCode.L))
            //{
            //    // jump command
            //    //ownedCharacter.JumpCmd(isGrounded);
            //    Debug.Log("Enemy jump command sent by keyboard (command)");
            //}

            //patrolling state:
            //  move to next patrolling position
        }

        private void FixedUpdate()
        {
            isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);
        }


    }
}

