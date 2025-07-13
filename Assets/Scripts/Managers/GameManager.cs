using UnityEngine;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    // Singleton instance of GameManager
    // This allows us to access the GameManager from other scripts without needing to find it in the scene
    // The instance variable is static, meaning it belongs to the class itself rather than any specific instance of the class.
    // A singleton means that there will only ever be one instance of this class in the game.
    public static GameManager instance;

    // This is a list of all the player prefabs that can be spawned in the game
    // The Header attribute is used to organize the inspector in Unity, making it easier to find related variables
    [Header("Prefabs")] 
    public GameObject playerPawnPrefab;
    public GameObject playerControllerPrefab;

    [Header("Lists")] 
    public List<PlayerController> players;
    public List<PlayerPawn> playerPawns;


    // Awake is called when the script instance is being loaded
    // Note: When a new scene is loaded, Unity destroys all GameObjects in the previous scene and loads the new scene.
    // However, we can use DontDestroyOnLoad to keep this GameObject alive across scene loads.
    // Awake is called before Start, and is used for initialization that needs to happen before the first frame update.
    private void Awake()
    {
        // Check if an instance of GameManager already exists
        if (instance == null)
        {
            // If not, set this instance as the singleton instance
            instance = this;
            // Don't destroy this GameObject when loading a new scene
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // If an instance already exists, destroy this one to enforce the singleton pattern
            Destroy(gameObject);
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnPlayer(Vector3.zero);// Spawn the player at the origin (0, 0, 0)
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // This method spawns a player pawn in the game
    //putting Vector3 spawnPosition inside the parentheses () allows us to pass a Vector3 variable to this method
    //This will be used to set the spawn position of the player pawn
    void SpawnPlayer(Vector3 spawnPosition)
    {
        // Instantiate the player pawn prefab and get the PlayerPawn component from it
        //This creates a new instance of the player pawn prefab in the scene
        GameObject tempPlayerControllerObject = Instantiate<GameObject>(playerControllerPrefab);

        // Set the position of the player pawn to the origin (0, 0, 0)
        tempPlayerControllerObject.transform.position = Vector3.zero; // Set the position of the player controller to the origin (0, 0, 0)

        // Get the PlayerController component from the instantiated player pawn
        PlayerController tempPlayerController = tempPlayerControllerObject.GetComponent<PlayerController>();

        // Instantiate the player pawn prefab in the scene
        GameObject tempPlayerPawnObject = Instantiate<GameObject>(playerPawnPrefab); 

        // Get the PlayerPawn component from the instantiated player pawn
        PlayerPawn tempPlayerPawn = tempPlayerPawnObject.GetComponent<PlayerPawn>();

        //This sets the position of the player pawn to the spawn position passed to this method
        tempPlayerPawnObject.transform.position = spawnPosition;

        //Note: the tankPawn variable is defined in the PlayerController class, which is inherited from ParentController
        // So, the tankPawn is reference to the ParentPawn component, just to avoid confusion
        tempPlayerController.tankPawn = tempPlayerPawn; // Set the PlayerController's tankPawn to the instantiated PlayerPawn

        /*
        // Add the PlayerController to the players list
        players.Add(tempPlayerController);
        // Add the PlayerPawn to the playerPawns list
        playerPawns.Add(tempPlayerPawn);
        */
    }
}
