using UnityEngine;
using System.Collections.Generic;
using System.Collections;

// Note: abstract classes cannot be instantiated directly, but they can be inherited by other classes.
// abstract means that it will be overridden by derived classes,
// which is useful for creating a base class that provides common functionality or properties for other classes to use.
public abstract class ParentPawn : MonoBehaviour
{
    // This represents the speed at which the player moves.
    public float moveSpeed;
    // This represents the speed at which the player turns.
    public float turnSpeed;

    /*
    public abstract void MoveForward();
    public abstract void MoveBackward();
    public abstract void TurnRight();
    public abstract void TurnLeft();
    */

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected abstract void Start();

    // Update is called once per frame
    protected abstract void Update();
    

    public abstract void Movement(Vector3 movementVector);



    public abstract void Rotate(Vector3 rotateVector);

}
