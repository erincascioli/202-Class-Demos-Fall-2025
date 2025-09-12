// Erin Cascioli
// 9/5/2025
// Demo: Scripting with Unity 3D

// ----------------------------------------------------------------------------
// ** Note: Notice how this using statement was auto-entered into this script?
// ** WATCH FOR THESE! They can mess with your script. (Particularly the Drawing package!)
using Unity.VisualScripting;
// ----------------------------------------------------------------------------

using UnityEngine;


/// <summary>
/// Destroy this GameObject after a number of seconds.
/// </summary>
public class BlowMeUp : MonoBehaviour
{
    void Start()
    {
        // After the scene starts, destroy this object at the 2 second mark.
        Destroy(gameObject, 2);
    }

    // Update is called once per frame
    void Update()
    {
    }
}
