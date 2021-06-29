using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PcInputs : PlatformInputs
{
    public override bool GetAttack()
    {
        return Input.GetKeyDown(KeyCode.F);
    }

    public override float GetMove()
    {
        return Input.GetAxisRaw("Horizontal");
    }

    public override bool GetJump()
    {
        return Input.GetKeyDown(KeyCode.Space);
    }


}
