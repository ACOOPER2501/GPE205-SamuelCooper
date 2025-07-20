using UnityEngine;
using System.Collections.Generic;

public class Shooter : ParentShooter
{
    //We will place the prefab for the bullet to be instantiated in the inspector
    public GameObject bulletPrefab; // Prefab for the bullet to be instantiated

    // We will place the position from where the bullet will be fired in the inspector
    public GameObject shootPosition; // Position from where the bullet will be fired from

    public float shootForce; // Force applied to the bullet when shot

    public override void Shoot()
    {
        // We use GameObject bulletObject to instantiate the bulletPrefab at the shootPosition
        // To Instantiate means to create a new instance of the bulletPrefab in the scene
        // So, we will create a new GameObject called bulletObject every time the Shoot method is called
        GameObject bulletObject = Instantiate<GameObject>(bulletPrefab, transform);


        Damage damage = bulletObject.GetComponent<Damage>(); // Get the Damage component from the instantiated bullet


        Rigidbody bulletRB = bulletObject.GetComponent<Rigidbody>(); // Get the Rigidbody component from the instantiated bullet

        // We defined our bulletRB variable above, so we can use it here to apply force to the bullet
        // We use bulletRB.AddForce to apply a force to the bullet in the forward direction of the shootPosition
        // We multiply the shootPosition's forward direction by the shootForce to apply the force
        // Forward is used to indicate the direction in which the bullet is shot
        // This terminology is used in Unity 3D, it is defined in Vector3 as the direction of the positive z-axis
        bulletRB.AddForce(bulletObject.transform.forward * shootForce);

        // Note: In Unity 3D Vector3, the forward direction is represented by the vector (0, 0, 1),
        // Backward is (0, 0, -1), Left is (-1, 0, 0), and Right is (1, 0, 0).
        // up is (0, 1, 0) and down is (0, -1, 0).
    }

}
