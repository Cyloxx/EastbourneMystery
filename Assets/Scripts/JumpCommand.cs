using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpCommand : ICommand
{
    GameObject character;
    float force;


    public JumpCommand(GameObject character, float force)
    {
        this.character = character;
        this.force = force;
    }

    public void Jump()
    {
        Controller.MakeJump(character,force);
    }

    public void Movement()
    {
        throw new System.NotImplementedException();
    }
}
