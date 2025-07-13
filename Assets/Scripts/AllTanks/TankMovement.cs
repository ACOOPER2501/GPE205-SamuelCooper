using UnityEngine;
using System.Collections.Generic;

public class TankMovement : ParentMovement
{
    
    private Rigidbody rb; // Rigidbody component for physics interactions

    private PlayerPawn playerPawn;

    public override void Start()
    {
        // Initialize the Rigidbody component
        // this. is used to refer to the current instance of the class,
        // which is necessary to access the Rigidbody component attached to this specific GameObject.
        // gameObject.GetComponent<Rigidbody>() is used to get the Rigidbody component attached to the GameObject this script is attached to.
        // Then, we will assign it to the rb variable.
        rb = this.gameObject.GetComponent<Rigidbody>();

        if (rb == null) // Check if the Rigidbody component was successfully retrieved
        {
            Debug.LogError("Rigidbody component not found on the GameObject. Please add a Rigidbody component.");
        }

        playerPawn = GetComponent<PlayerPawn>();
    }

    //These functions were generated using the CTRL + . shortcut in Visual Studio to implement the abstract methods from the ParentMovement class.

    //overrides the parent class's abstract method Movement
    // We have the Vector3 movementVector parameter inside the () parentheses to pass the movement vector from the PlayerController script
    public override void Movement(Vector3 movementVector)
    {
        // This method handles the movement of the tank based on the input vector
        // We created a new Vector3 variable to store the new movement vector
        // Then, we set the newMovementVector to zero to start with no movement "Vector3.zero"
        Vector3 newMovementVector = Vector3.zero;

        // We set the newMovementVector to the forward direction of the tank multiplied by the z-axis input
        // We did this by equaling our newMovementVector to the transform.forward vector
        // transform is how we access the GameObject's transform component,which is used to get the position, rotation, and scale of the GameObject.
        // We will use this for movement along the z-axis
        // we use the .forward property to get the forward direction of the tank
        // We then multiply "*" it by the z-axis input from the movementVector we created in the PlayerController script "movementVector.z"
        newMovementVector = transform.forward * movementVector.z; // Forward/backward movement based on the z-axis input


        //What this does is it takes the newMovementVector and multiplies it by the player's move speed
        // This is done to scale the movement vector by the player's speed, so that the tank moves at the desired speed
        newMovementVector = newMovementVector * playerPawn.moveSpeed;

        //We don't want to move every frame, we instead want to move on frame per second
        // We do this by multiplying the newMovementVector by Time.deltaTime, which is the time it took to complete the last frame
        // IMPORTANT: Time.deltaTime is used to make the movement frame rate independent, "This will be used for smooth movement."
        // meaning it will move at the same speed regardless of the frame rate. (We will use this often in Unity scripts)
        newMovementVector = newMovementVector * Time.deltaTime;

        // Move the tank's Rigidbody to the new position based on the movement vector
        // We use rb.MovePosition to move the Rigidbody to the new position
        // This is done by adding the newMovementVector to the current position of the Rigidbody
        //Our newMovementVector was defined above, so we can use it here to move the tank
        rb.MovePosition(rb.position + newMovementVector); 
    }

    //overrides the parent class's abstract method Rotate
    public override void Rotate(Vector3 rotateVector)
    {
        // This stores the rotation amount, starting at zero (0.0f)
        // The f at the end of the number indicates that it is a float type number / integer
        float rotateAmount = 0.0f;

        // We set the rotateAmount to the y-axis of the rotateVector
        rotateAmount = rotateVector.y;

        // We then multiply the rotateAmount by the player's turn speed
        rotateAmount = rotateAmount * playerPawn.turnSpeed; // Scale the rotation by the turn speed

        // We then multiply the rotateAmount by Time.deltaTime to make the rotation frame rate independent
        rotateAmount = rotateAmount * Time.deltaTime;
        //Note: We could also use rotateAmount *= Time.deltaTime; to achieve the same result.

        // Rotate the tank's Rigidbody around the y-axis based on the rotation amount
        transform.Rotate(0, rotateAmount, 0);
    }
}
