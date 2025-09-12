// Erin Cascioli
// 9/8/2025
// Demo: Instantiation in Unity 3D

using UnityEngine;

/// <summary>
/// Instantiates a provided number of instances of a provided prefab.
/// Prefab instances are at random locations on the X, Y and Z axes.
/// </summary>
public class Instantiator : MonoBehaviour
{
    /// <summary>
    /// How many instances are desired?
    /// </summary>
    [SerializeField]
    private int numberOfInstances;

    /// <summary>
    /// Prefab to instantiate
    /// </summary>
    [SerializeField]
    private GameObject prefabGO;


    // ------------------------------------------------------------------------
    // Think of the Start method like a constructor
    // ------------------------------------------------------------------------
    void Start()
    {
        // Instantiate the prefab at a random location in the scene.
        for(int i = 0; i < numberOfInstances; i++)
        {
            // Generate a random position within these literal ranges
            // ** Note: Any or all of these ranges could be fields of the class, to allow
            //    for further customization and reuse of this script!
            float xPosition = Random.Range(-3f, 4f);
            float yPosition = Random.Range(0f, 4f);
            float zPosition = Random.Range(-10f, 11f);

            // Once these instances are created, there's no reference to them anymore...
            // ** FRIDAY: How can we fix that? What does Instantiate return? **
            Instantiate(
                prefabGO,                                           // Which prefab?
                new Vector3(xPosition, yPosition, zPosition),       // Position in global space
                Quaternion.identity);                               // No rotation
        }        
    }

    void Update()
    {
        
    }
}
