using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EastBourne
{
    public abstract class CharacterController : MonoBehaviour
    {
        [SerializeField] protected Character ownedCharacter;
        [SerializeField] protected Enemy dummyEnemy;
    } 
}
