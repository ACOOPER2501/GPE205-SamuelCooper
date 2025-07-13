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


    public void Awake()
    {
        GameManager.instance.players.Add(this); // Add this PlayerController instance to the GameManager's players list

        // Initialize the PlayerPawn component
        gameObject.name = "Player" + GameManager.instance.players.Count; 
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    // Note: The parent class Update needs to be classified as protected virtual to allow overriding in derived classes.
    protected override void Update()
    {
        base.Update();
    }


    public void OnDestroy()
    {
        GameManager.instance.players.Remove(this); // Remove this PlayerController instance from the GameManager's players list when destroyed
    }

    // This method handles player movement based on input keys
    // override means that this method is overriding the base class method from
    // It overrides the MakeDecisions method from ParentController to implement specific player input handling.
    protected override void MakeDecisions()
    {
        //Defines movementVector as a Vector3 variable to store the player's movement direction
        Vector3 movementVector = Vector3.zero; // Initialize movement vector, starting at zero

        // We define the movementVector based on player input on the keyboard
        // .x is the horizontal axis (left/right), so we are defining movementVector.x based on the horizontal input
        // Input.GetAxis("Horizontal") returns a value between -1 and 1 based on the player's input on the horizontal axis
        movementVector.x = Input.GetAxis("Horizontal"); // Get horizontal input (left/right)

        //We define movementVector.z based on the vertical input
        // Input.GetAxis("Vertical") returns a value between -1 and 1 based on the player's input on the vertical axis
        movementVector.z = Input.GetAxis("Vertical"); // Get vertical input (forward/backward)

        // This checks if the player is pressing the forward or backward key
        // This is done by checking the movementVector based on the z-axis by using .z
        // We call new Vector3 because we want to create a new Vector3 object to pass to the Movement method
        // We set the x & y values to 0 because we only want to move the player along the z-axis
        tankPawn.Movement(new Vector3(0, 0, movementVector.z)); //Forward/backward movement

        // This checks if the player is pressing the left or right key
        // This is done by checking the movementVector based on the x-axis by using .x
        // We call new Vector3 because we want to create a new Vector3 object to pass to the Rotate method
        // We set the y & z values to 0 because we only want to rotate the player along the y-axis
        tankPawn.Rotate(new Vector3(0, movementVector.x, 0)); // Turning left/right movement / rotation

        base.MakeDecisions(); // Call the base class method to ensure any base logic is executed
    }
}
