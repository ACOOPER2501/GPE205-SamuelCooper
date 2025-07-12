using UnityEngine; //This calls the UnityEngine library, which is necessary for Unity scripts to function properly.
using System.Collections; // This allows the use of collections like ArrayLists, which can be useful for managing groups of objects dynamically.
using System.Collections.Generic;

// Note: abstract classes cannot be instantiated directly, but they can be inherited by other classes.
// abstract means that it will be overridden by derived classes,
// which is useful for creating a base class that provides common functionality or properties for other classes to use.
public abstract class ParentController : MonoBehaviour 
{
    // Reference to the PlayerPawn component
    public PlayerPawn playerPawn;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
