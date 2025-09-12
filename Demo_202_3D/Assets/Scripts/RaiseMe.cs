// Erin Cascioli
// 9/5/2025
// Demo: Scripting with Unity 3D

using UnityEngine;

/// <summary>
/// "Raise" an object (increase its y value) continually
/// </summary>
public class RaiseMe : MonoBehaviour
{
    /// <summary>
    /// Distance to modify the Y value, PER FRAME
    /// </summary>
    public float speed;

    void Start()
    {
        
    }

    void Update()
    {
        // --------------------------------------------------------------------
        // Raise this object along the Y axis by increasing the Y value.
        // --------------------------------------------------------------------

        // ** A Vector is a struct, and a REFERENCED struct (from the position property)
        //    cannot be modified. 
        //transform.position.y += speed;   NO! Doesn't work.
        // ** So how can you change the position of a game object from the Transform property?
        // ** Remember: C-A-R  (copy-alter-replace!)
        Vector3 positionCopy = transform.position;
        positionCopy.y += speed;
        transform.position = positionCopy;

        // ** Alternately, could reset the Vector this way:
        //transform.position = new Vector3(
        //    transform.position.x, 
        //    transform.position.y + speed, 
        //    transform.position.z);
    }
}
