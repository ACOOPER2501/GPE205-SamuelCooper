using UnityEngine;


// We make this an abstract class so that it can be inherited by other classes
public abstract class Death : MonoBehaviour
{

    public abstract void Die(); // Abstract method to be implemented by derived classes for death logic

}
