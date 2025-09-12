// Erin Cascioli
// 9/10/2025
// Demo: Collisions in Unity 3D

using UnityEngine;

/// <summary>
/// Collection of information about a sphere.
/// Component of the BallPrefab
/// Demonstrates how another script (DestroyObject) can access information in this script
/// </summary>
public class SphereInformation : MonoBehaviour
{
    // ------------------------------------------------------------------------
    // Fields of this class can be publicly accessible to other scripts.
    // Public --> other script can freely change this string
    // ALTERNATELY we could use a property here!  
    // ------------------------------------------------------------------------
    
    /// <summary>
    /// Name of this sphere.
    /// Initial value set in Inspector as "MyCircle"
    /// </summary>
    public string sphereName;

    // ------------------------------------------------------------------------
    // Private fields are NOT accessible to any other scripts
    // SerializeField allows visibility in Inspector
    // ------------------------------------------------------------------------

    /// <summary>
    /// Used to control whether a Debug statement is printed
    /// </summary>
    [SerializeField]
    private bool trackName;


    // ------------------------------------------------------------------------
    // Start and Update don't require XML comments UNLESS there's something
    //   specific that needs to be pointed out.
    // ------------------------------------------------------------------------
    void Start()
    {
        // All spheres start with the name "MyCircle"
        // This value is also set in the Inspector.
        //sphereName = "My Circle";
    }

    void Update()
    {
        // Print this sphere's name if I want to track it
        if(trackName)
        {
            Debug.Log("My name is " + sphereName);
        }
    }
}
