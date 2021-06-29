using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MobileInputs : PlatformInputs
{
    [SerializeField] Button jumpButton;
    [SerializeField] Button attackButton;
    [SerializeField] Button rightButton;
    [SerializeField] Button leftButton;

    private bool bIsJumpButtonPressed;
    private bool bISAttackButtonPressed;
    private float moveInput;


    public override bool GetAttack()
    {
        return bISAttackButtonPressed;
    }

    public override float GetMove()
    {
        return moveInput;
    }

    public override bool GetJump()
    {
        return bIsJumpButtonPressed;
    }

    public void OnJumpButtonStateChanged(bool state)
    {
        bIsJumpButtonPressed = state;
    }

    public void OnAttackButtonStateChanged(bool state)
    {
        bISAttackButtonPressed = state;
    }

    public void OnMoveInputButtonPresses(float val)
    {
        moveInput = val;
    }

    public void OnMoveInputButtonReleased(float val)
    {
        moveInput = val;
    }

}
