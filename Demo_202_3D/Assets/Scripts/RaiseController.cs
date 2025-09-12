// Erin Cascioli
// 9/5/2025
// Demo: Scripting with Unity 3D

using UnityEngine;

/// <summary>
/// Attach this to a "manager" GO to control the Y movement of several
/// GO's in the scene.
/// </summary>
public class RaiseController : MonoBehaviour
{
    /// <summary>
    /// How fast these objects will move PER FRAME
    /// </summary>
    public float speed;

    // ------------------------------------------------------------------------
    // We could have separate references to single objects...
    // ** That could get messy when many objects are needed.
    // ------------------------------------------------------------------------

    /// <summary>
    /// The first box that will "raise" in the scene.
    /// </summary>
    public GameObject box1;

    /// <summary>
    /// The second box that will "raise" in the scene.
    /// </summary>
    public GameObject box2;

    // ------------------------------------------------------------------------
    // Or we could combine all necessary GOs in a data structure!
    // ------------------------------------------------------------------------

    /// <summary>
    /// Array of 3 Box objects that will "rise up".
    /// Size of 3 is set in the Inspector.
    /// All 3 references to boxes are also set in the Inspector.
    /// </summary>
    public GameObject[] boxes;


    void Start()
    {
        // Remove all of the boxes in the array 2 seconds after this script starts.
        for (int i = 0; i < boxes.Length; i++)
        {
            Destroy(boxes[i], 2);
        }
    }

    void Update()
    {
        // ------------------------------------------------------------------------
        // Raise all the boxes!
        // ------------------------------------------------------------------------

        // Raise the first box
        // ** Remember: Vectors are STRUCTS and cannot be modified when REFERENCED
        //    via a property or method.
        // The LOCAL STRUCT positionCopy CAN be modified!
        Vector3 positionCopy = box1.transform.position;
        positionCopy.y += speed;
        box1.transform.position = positionCopy;

        // Raise the second box
        positionCopy = box2.transform.position;
        positionCopy.y += speed;
        box2.transform.position = positionCopy;

        // Raise all GameObjects in the boxes array
        for(int i = 0; i < boxes.Length; i++)
        {
            // Check that the array exists and the GameObject has been set properly 
            //   in the Inspector.
            if (boxes[i] != null)
            {
                positionCopy = boxes[i].transform.position;
                positionCopy.y += speed;
                boxes[i].transform.position = positionCopy;
            }
        }
    }
}
