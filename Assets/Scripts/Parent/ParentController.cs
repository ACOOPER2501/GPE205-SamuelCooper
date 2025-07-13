using UnityEngine; //This calls the UnityEngine library, which is necessary for Unity scripts to function properly.
using System.Collections; // This allows the use of collections like ArrayLists, which can be useful for managing groups of objects dynamically.
using System.Collections.Generic;

// Note: abstract classes cannot be instantiated directly, but they can be inherited by other classes.
// abstract means that it will be overridden by derived classes,
// which is useful for creating a base class that provides common functionality or properties for other classes to use.
public abstract class ParentController : MonoBehaviour 
{
    // Reference to the ParentPawn component
    public ParentPawn tankPawn;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        // every frame, we call the MakeDecisions method to handle decision-making logic
        // The reason for calling MakeDecisions here is that we want to check for player input and other game logic every frame.
        MakeDecisions();
    }

    // This method can be overridden by derived classes to implement specific decision-making logic.
    // It is marked as virtual, allowing derived classes to provide their own implementation.
    // For example, PlayerController can override this method to handle player input and movement decisions.
    // virtual means that it can be overridden by derived / child classes.
    // protected means that it can only be accessed by this class and its derived / child classes.
    protected virtual void MakeDecisions() 
    {
        
    }
}
