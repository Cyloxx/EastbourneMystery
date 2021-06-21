using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EastBourne
{
    public class JumpCommand : ICommand
    {
        GameObject chr;
        Rigidbody2D charRB;
        Animator anim;
        float force;
        bool isGrounded;

        public JumpCommand(GameObject objectToJump, float force, bool isGrounded, Animator anim)
        {
            this.chr = objectToJump;
            this.force = force;
            this.isGrounded = isGrounded;
            charRB = chr.GetComponent<Rigidbody2D>();
            this.anim = anim;
        }

        public void JumpExecute()
        {
            if (isGrounded)
            {
                anim.SetTrigger("takeOff");
                anim.SetBool("isJumping", true);
                charRB.velocity = Vector2.up * force;
            }
            
        }
       
    } 
}
