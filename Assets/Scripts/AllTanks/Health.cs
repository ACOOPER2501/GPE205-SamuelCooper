using UnityEngine;

public class Health : MonoBehaviour
{
    //Note: Remember to spell with lowercase letter first as per coding standards
    public float maxHealth; // Maximum health of the tank

    public float currentHealth; // Current health of the tank

    // made private so that it can only be accessed within this script
    private Death death; // Reference to the Death script for handling death logic

    void Start()
    {
        // Get Death component
        death = GetComponent<Death>();

        // At startup, set current health to maximum health
        currentHealth = maxHealth;
    }

    void Update()
    {
        // Test code to take damage when the P key is pressed
        // Delete this after testing
        if (Input.GetKeyDown(KeyCode.P))
        {
            // Call the TakeDamage method with a damage value of 10
            TakeDamage(10f);
        }
    }

    // the float damage inside the parentheses is the amount of damage to be taken
    // damage is defined as a float type variable, which means it can hold decimal value
    public void TakeDamage(float damage)
    {
        // Subtract from health when taking damage
        currentHealth -= damage;
        // currentHealth = currentHealth - damage is the same as the above line

        // Mathf is a class that provides various mathematical functions and constants
        // Mathf.Clamp is a function that restricts a value to be within a specified range
        // In this case, it ensures that currentHealth does not go below 0 or above maxHealth
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth); // Ensure health does not go below 0 or above maxHealth

        if (currentHealth <= 0)
        {
            // If health is less than or equal to 0, call the Die method from the Death script
            Die(); //calls the Die function
        }
    }

    public void Die()
    {
        // call Die method from the Death script
        death.Die();
    }

}
