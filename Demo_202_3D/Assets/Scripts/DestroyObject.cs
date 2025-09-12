// Erin Cascioli
// 9/10/2025
// Demo: Collisions in Unity 3D

using UnityEngine;

/// <summary>
/// Destroys another GO in the scene.
/// Positioned on the "floor" GO in the scene.
/// </summary>
public class DestroyObject : MonoBehaviour
{
    // ------------------------------------------------------------------------
    // Start and Update don't have any code in them, so I like to minimize them.
    // Alternately, you could actually remove these method definitions from the script.
    // Either way is fine!
    // ------------------------------------------------------------------------
    void Start()
    {
        
    }

    void Update()
    {
        
    }


    // ------------------------------------------------------------------------
    // Collision Methods:
    // 1. Trigger destroys the colliding object
    // 2. Non-trigger changes a value of the colliding object
    // ------------------------------------------------------------------------

    /// <summary>
    /// If the floor is a trigger, destroy the colliding object!
    /// </summary>
    /// <param name="collision">Colliding object</param>
    public void OnTriggerEnter(Collider collision)
    {
        Destroy(collision.gameObject);
    }


    /// <summary>
    /// If the floor is NOT a trigger, change the name of the colliding object!
    /// </summary>
    /// <param name="collision">Colliding object</param>
    public void OnCollisionEnter(Collision collision)
    {
        // First, get access to the script of the colliding object
        SphereInformation script = 
            collision.gameObject.GetComponent<SphereInformation>();

        // Does the GameObject have a SphereInformation component?
        if(script != null)
        {
            // Yes it does!
            // Change something in the script
            script.sphereName = "SOMETHINGELSE";
        }
    }
}
