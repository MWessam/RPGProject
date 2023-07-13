using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MovementComponent : MonoBehaviour, IMovementComponent
{
    public abstract float Speed { get; set; }

    public abstract void Move();
}
