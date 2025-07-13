using UnityEngine;
using System.Collections.Generic;

//We made this abstract class so that it can be inherited by other classes, such as PlayerMovement or EnemyMovement.
// This also means that we will NEVER have one of these by itself in the game, but rather it will be used as a base class for other movement classes.
// Note: abstract classes cannot be instantiated directly, but they can be inherited by other classes.
// In other words, we cannot add this script to a GameObject directly in Unity as a component,
// but we can create other scripts that inherit from this class and add those scripts to GameObjects.
public abstract class ParentMovement : MonoBehaviour
{
    
    public abstract void Start(); // Abstract method for initialization, to be implemented by derived classes
     
    // Note: Abstract can NEVER exist by itself, it is used as a base class for other classes to inherit from.
    public abstract void Movement(Vector3 movementVector); // Abstract method for movement, to be implemented by derived classes

    public abstract void Rotate(Vector3 rotateVector); // Abstract method for rotation, to be implemented by derived classes


}
