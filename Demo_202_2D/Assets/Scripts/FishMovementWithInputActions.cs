using UnityEngine;
using UnityEngine.InputSystem;


/// <summary>
/// Uses the new Input Package System
/// </summary>
public class FishMovementWithInputActions : MonoBehaviour
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


    void Start()
    {

    }


    void Update()
    {
        // Moving fish along X or Y axis using per-frame movement.
        MoveFish();

        // Every frame, inspect the mouse's position in screen space
        Debug.Log("Pixels: " + Mouse.current.position.ReadValue());
        Vector3 mousePositionInWorldSpace =
            Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        Debug.Log("Screen space: " + mousePositionInWorldSpace);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        // Input directions are read in as 2D vectors
        Vector2 playerDirection2D = context.ReadValue<Vector2>();

        // But I want a 3D vector for my fish!
        Vector3 playerDirection3D = new Vector3(playerDirection2D.x, playerDirection2D.y, 0);

        // Visualize what the direction is:
        Debug.Log(playerDirection3D);

        // Set the fish's direction
        fishDirection = playerDirection3D;
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

        // Move the fish in its direction
        fishPosition += fishDirection * fishSpeed;

        // Transport the fish to that position
        fish.transform.position = fishPosition;
    }
}
