using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementCommand : ICommand
{
    GameObject character;
    float movementInput;
    float movementSpeed;

    public MovementCommand(GameObject character, float movementInput, float movementSpeed)
    {
        this.character = character;
        this.movementInput = movementInput;
        this.movementSpeed = movementSpeed;
    }

    public void Jump()
    {
        throw new System.NotImplementedException();
    }

    public void Movement()
    {
        Controller.ControlCharacter(character, movementInput, movementSpeed);
    }
}
