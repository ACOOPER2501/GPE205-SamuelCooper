using UnityEngine;
using System.Collections.Generic;
using System.Collections;

// ParentPawn is the parent class for PlayerPawn, which the PlayerPawn is inheriting from.
// The ParentPawn in turn is inheriting from MonoBehaviour, which is the base class every Unity script derives from.
public class PlayerPawn : ParentPawn
{
    private TankMovement tankMovement; // Reference to the TankMovement script for handling tank movement


    public void Awake()
    {
        GameManager.instance.playerPawns.Add(this); // Add this PlayerPawn instance to the GameManager's playerPawns list

        gameObject.name = "PlayerPawn" + GameManager.instance.playerPawns.Count; // Rename the GameObject to reflect the current count of player pawns
    }

    public override void Movement(Vector3 movementVector)
    {
        tankMovement.Movement(movementVector); // Call the Movement method from TankMovement to handle tank movement
    }

    public override void Rotate(Vector3 rotateVector)
    {
        tankMovement.Rotate(rotateVector); // Call the Rotate method from TankMovement to handle tank rotation
    }

    protected override void Start()
    {
        tankMovement = GetComponent<TankMovement>();
    }

    protected override void Update()
    {
        
    }

    public void OnDestroy()
    {
        GameManager.instance.playerPawns.Remove(this); // Remove this PlayerPawn instance from the GameManager's playerPawns list when destroyed

    }
}
