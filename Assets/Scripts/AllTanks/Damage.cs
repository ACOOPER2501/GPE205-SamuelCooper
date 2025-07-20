using UnityEngine;

public class Damage : MonoBehaviour
{

    public float damageDealtOnHit;

    // OnTriggerEnter is called when another collider enters the trigger collider attached to the object this script is attached to
    // The Collider parameter 'other' represents the other collider that entered the trigger
    public void OnTriggerEnter(Collider other)
    {
        Health otherHealth = other.GetComponent<Health>(); // Get the Health component from the other GameObject

        if (otherHealth != null) // Check if the Health component exists on the other GameObject
        {
            // Call the TakeDamage method on the other Health component with a damage value of 10
            otherHealth.TakeDamage(damageDealtOnHit); // You can change the damage value as needed
        }
        else
        {
            Debug.LogWarning("No Health component found on " + other.gameObject.name); // Log a warning if no Health component is found
        }

        // This is to destroy the GameObject (Bullet) after it has hit something
        Destroy(gameObject);
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
