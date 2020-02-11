using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MovementSettings", menuName = "Movement Settings", order = 51)]
public class MovementSettings : ScriptableObject
{
    public float Speed;
    public float JumpForce;
}
