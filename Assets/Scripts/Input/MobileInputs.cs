using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace EastBourne
{
    public class MobileInputs : PlatformInputs
    {
        [SerializeField] ControlButton jumpButton;
        [SerializeField] ControlButton attackButton;
        [SerializeField] ControlButton rightButton;
        [SerializeField] ControlButton leftButton;

        private bool bIsJumpButtonPressed; 
        private bool bIsAttackButtonPressed; 
        private float movementInput;


        /* public override bool GetEnemyAttack()
         {
             return bISAttackButtonPressed;
         }*/

        private void Start()
        {
            jumpButton.OnContolButtonPointerDown.AddListener((eventData) => bIsJumpButtonPressed = true);
            jumpButton.OnContolButtonPointerUp.AddListener((eventData) => bIsJumpButtonPressed = false);

            attackButton.OnContolButtonPointerDown.AddListener(OnAttackButtonPressed);
            attackButton.OnContolButtonPointerUp.AddListener(OnAttackButtonReleased);

            rightButton.OnContolButtonPointerUp.AddListener((eventData) => SetMovementInput( 0));
            rightButton.OnContolButtonPointerDown.AddListener((eventData) => SetMovementInput(1));
            leftButton.OnContolButtonPointerUp.AddListener((eventData) => SetMovementInput(0));
            leftButton.OnContolButtonPointerDown.AddListener((eventData) => SetMovementInput(-1));
        }

        public override bool GetAttack()
        {
            return bIsAttackButtonPressed;
        }

        public override float GetMove()
        {
            return movementInput;
        }

        public override bool GetJump()
        {
            return bIsJumpButtonPressed;
        }

        private void OnAttackButtonPressed(PointerEventData eventData)
        {
            bIsAttackButtonPressed = true;
        }
        private void OnAttackButtonReleased(PointerEventData eventData)
        {
            bIsAttackButtonPressed = false;
        }

        private void SetMovementInput(float input)
        {
            movementInput = input;
        }
    } 
}
