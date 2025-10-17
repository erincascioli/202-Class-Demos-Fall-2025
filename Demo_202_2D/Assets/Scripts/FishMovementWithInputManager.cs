using UnityEngine;
using UnityEngine.InputSystem;


/// <summary>
/// Uses the Legacy Input Manager system
/// </summary>
public class FishMovementWithInputManager : MonoBehaviour
{

    /// <summary>
    /// Object that this script moves with WASD or arrow keys
    /// </summary>
    public GameObject fish;

    /// <summary>
    /// Unit-based movement per frame for the fish
    /// </summary>
    public float fishSpeed;

    /// <summary>
    /// Vector representing the 4 cardinal directions of movement
    /// </summary>
    public Vector3 fishDirection;


    // ------------------------------------------------------------------------
    // Rotate the fish every frame!  
    // how much to rotate - no more than 1 degree per frame
    // cumulative rotation
    public float speedOfRotation;
    public float totalRotation;
    // ------------------------------------------------------------------------


    void Start()
    {
        
    }


    void Update()
    {
        // USEFUL FOR DEBUGGING
        /*
        // Every frame, inspect the mouse's position in screen space
        Debug.Log("Pixels: " + Input.mousePosition);
        Vector3 mousePositionInWorldSpace = 
            Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Debug.Log("Screen space: " + mousePositionInWorldSpace);
        */

        // Start by moving fish independently on X or Y axis using per-frame movement.
        MoveFish();

        // Rotate the fish
        //RotateFish();
    }

    public void RotateFish()
    {
        // Increase the total rotation by the rotation speed
        totalRotation += speedOfRotation;

        Debug.Log(totalRotation);

        // Update the transform's rotation with a quaternion calculated by Unity
        Quaternion newRotation = Quaternion.Euler(0, 0, totalRotation);
        fish.transform.rotation = newRotation;
    }


    /// <summary>
    /// Use Unity's Input Package system to move the fish in 4 cardinal directions
    ///    with WASD.
    /// </summary>
    public void MoveFish()
    {
        // Grab the fish's current position as a locally-declared struct
        // such that it is modifiable.
        Vector3 fishPosition = fish.transform.position;

        // Move the jellyfish!
        // When the A key is pressed, move fish to the left
        if (Input.GetKey(KeyCode.A))				// Left
        {
            // Prove to ourselves that the key presses are working!
            //Debug.Log("Pressing A");

            // Move the object a tiny unit left
            fishPosition.x -= fishSpeed;
        }
        if (Input.GetKey(KeyCode.D))                       // Right
        {
            // Move the object a tiny unit right
            fishPosition.x += fishSpeed;
        }
        if (Input.GetKey(KeyCode.W))                       // Up
        {
            // Move the object a tiny unit left
            fishPosition.y += fishSpeed;
        }
        if (Input.GetKey(KeyCode.S))                       // Down
        {
            // Move the object a tiny unit left
            fishPosition.y -= fishSpeed;
        }

        // Transport the fish to that position
        fish.transform.position = fishPosition;
    }
}
