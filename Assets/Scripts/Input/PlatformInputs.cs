using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlatformInputs : MonoBehaviour
{
    public abstract bool GetJump();
    public abstract bool GetAttack();
    public abstract float GetMove();
}
