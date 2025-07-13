using UnityEngine;

public class MainCamera : MonoBehaviour
{

    [SerializeField] //This allows you to set the target in the Unity Inspector, even though it's private
    private Transform target; // The target to follow, which will be our Player Pawn (Tank).

    [SerializeField] // This allows you to set the offset in the Unity Inspector, even though it's private
    private Vector3 offset = new Vector3(0, 2, -10); // The offset from the target position. (Above the target and behind it)

    // This method is called when the script instance is being loaded
    void LateUpdate() // LateUpdate is called after all Update methods have been called, ensuring the camera follows the target after it has moved
    {
        //This method is called every frame to update the camera's position and rotation
        //So the camera will move at the same time as the target with no delay.
        if (target != null)
        {

            // Set the camera's position to the target's position plus the offset
            transform.position = target.TransformPoint(offset);

            // Set the camera's rotation to match the target's rotation
            transform.rotation = target.rotation;

        }
    }

    public void SetTarget(Transform newTarget)
    {
        target = newTarget; // Set the target to the new Transform passed in
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
