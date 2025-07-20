using UnityEngine;

// DeathDestroy is a class that inherits from the abstract Death class
public class DeathDestroy : Death
{
    // this overrides the abstract method Die from the Death class
    public override void Die()
    {
        Destroy(gameObject); // Destroy the GameObject this script is attached to upon death
    }

}
