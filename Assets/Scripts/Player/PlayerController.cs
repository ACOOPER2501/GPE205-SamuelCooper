using UnityEngine;
using System.Collections.Generic;
using System.Collections;

// ParentController is the parent class for PlayerController, which the PlayerController is inheriting from.
// The ParentController in turn is inheriting from MonoBehaviour, which is the base class every Unity script derives from.
public class PlayerController : ParentController
{

    // Reference to the PlayerPawn component
    //public PlayerPawn playerPawn; //Better to have in ParentController.cs?

    // Movement Keys
    public KeyCode moveForwardKey; // Key to move the player forward
    public KeyCode moveBackwardKey; // Key to move the player backward
    public KeyCode moveLeftKey; // Key to move the player left
    public KeyCode moveRightKey; // Key to move the player right

    //public KeyCode fireKey; //Tank Fire Key

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
