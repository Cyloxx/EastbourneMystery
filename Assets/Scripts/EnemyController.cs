using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EastBourne
{
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
            dummyEnemy.checkGround(isGrounded);


            if (Input.GetKeyDown(KeyCode.L))
            {
                // jump command
                dummyEnemy.JumpCmd(isGrounded);
                Debug.Log("Enemy jump command sent by keyboard (command)");
            }
        }
    }
}

