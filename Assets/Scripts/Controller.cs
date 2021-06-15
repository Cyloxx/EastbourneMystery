using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public GameObject mainCharacter;
    public Rigidbody2D mainCharaicterRB;
    public Animator mainCharacterAnim;
    public float movementSpeed;
    public float jumpForce;
    public float movementInput;

    public bool isGrounded;
    public Transform feetPos;
    public float checkRadius;
    public LayerMask whatIsGround;

    public float attackTimeCounter;
    public float attackTime;
    public bool firstAttack;
    public bool secondAttack;


    void Start()
    {
        mainCharacterAnim = mainCharacter.GetComponent<Animator>();
        attackTime = 1f;
        attackTimeCounter = attackTime;
        firstAttack = true;
        secondAttack = false;
    }

    void Update()
    {
        if (movementInput > 0)
        {
            mainCharacter.transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else if (movementInput < 0)
        {
            mainCharacter.transform.eulerAngles = new Vector3(0, 180, 0);
        }

        if (movementInput == 0)
        {
            mainCharacterAnim.SetBool("isRunning", false);
        }
        else
        {
            mainCharacterAnim.SetBool("isRunning", true);
        }

        isGrounded = Physics2D.OverlapCircle(feetPos.position,checkRadius, whatIsGround);

        if(isGrounded == true && Input.GetKeyDown(KeyCode.Space))
        {
            mainCharacterAnim.SetTrigger("takeOff");
            mainCharaicterRB.velocity = Vector2.up * jumpForce;
        }
        

        if(isGrounded == true)
        {
            mainCharacterAnim.SetBool("isJumping", false);
        }
        else
        {
            mainCharacterAnim.SetBool("isJumping", true);
        }

        if (Input.GetKeyDown(KeyCode.F))
        {

            /* if (attackTimeCounter-1f <= attackTime && firstAttack == true)
             { 
                 mainCharacterAnim.SetTrigger("isAttacking");
                 firstAttack = false;
             }
             else if( 0 <= attackTimeCounter && attackTimeCounter <= 0.5f && secondAttack == true)
             {
                 mainCharacterAnim.SetTrigger("isAttacking2");
                 secondAttack = false;
                 attackTimeCounter += 1f;
             }*/

            mainCharacterAnim.SetTrigger("isAttacking");

          //  if(mainCharacterAnim.HasState())
            mainCharacterAnim.SetTrigger("isAttacking2");

        }
        /*if (attackTimeCounter < 0) // reset attack
        {
            attackTimeCounter = attackTime;
            firstAttack = true;
            secondAttack = false;
        }
        if(attackTimeCounter <= 0.5f )
        {
            secondAttack = true;
        }

        if(firstAttack == false) // attack started
        {
            attackTimeCounter -= Time.deltaTime;
        }*/


        if (Input.GetKeyDown(KeyCode.H))
        {
            ICommand command = new MovementCommand(mainCharacter, -1, movementSpeed);
            CommandInvoker.AddCommand(command);
        }

        if (Input.GetKeyDown(KeyCode.J))
        {
            ICommand command = new JumpCommand(mainCharacter, jumpForce);
            CommandInvoker.AddCommand(command);
        }



    }

    private void FixedUpdate()
    {
        movementInput = Input.GetAxisRaw("Horizontal");
        mainCharaicterRB.velocity = new Vector2(movementInput * movementSpeed, mainCharaicterRB.velocity.y);
    }

    public static void ControlCharacter(GameObject character, float movementInput, float movementSpeed)
    {
        movementInput = Input.GetAxisRaw("Horizontal");
        character.GetComponent<Rigidbody2D>().velocity = new Vector2(movementInput * movementSpeed, character.GetComponent<Rigidbody2D>().velocity.y);

        if (movementInput > 0)
        {
            character.transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else if (movementInput < 0)
        {
            character.transform.eulerAngles = new Vector3(0, 180, 0);
        }
    }

    public static void MakeJump(GameObject character, float force)
    {
        character.GetComponent<Rigidbody2D>().velocity = Vector2.up * force;
    }



}
