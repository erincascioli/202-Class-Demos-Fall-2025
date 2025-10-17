using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// Script placed on the Jellyfish GO.
/// Demonstrates how to use Gizmos for debugging.
/// Different combinations of options are all included in this script:
///   - Colliding with just a boolean variable
///   - Colliding with a reference to a single obstacle
///   - Colliding with references to multiple obstacles
///   ^ Clearly wouldn't need ALL of these in the same script every time...  
///     use what is needed for the scenario. :)
/// </summary>
public class FishCollisionWithObstacles : MonoBehaviour
{
    /// <summary>
    /// Has a collision occurred during this frame?
    /// </summary>
    [SerializeField]
    private bool collidingThisFrame = false;

    /// <summary>
    /// Reference to the obstacle collided with
    /// </summary>
    [SerializeField]
    private Collider2D collidingObstacle;

    /// <summary>
    /// Reference to multiple colliding obstacles
    /// </summary>
    [SerializeField]
    private List<Collider2D> collidingObstacles;


    void Start()
    {
        
    }

    void Update()
    {
        //DrawDebugLines();
    }

    /// <summary>
    /// Once a collision with an obstacle occurs, save a reference to the colliding object
    /// so other methods can refer to the obstacle.
    /// </summary>
    /// <param name="collision">Colliding triangle obstacle</param>
    public void OnTriggerEnter2D(Collider2D collision)
    {
        // Add this to the list upon initial frame collision
        collidingObstacles.Add(collision);
        collidingObstacle = collision;

        // Save the boolean for use with a single colliding object
        collidingThisFrame = true;

        // Console debugging
        Debug.Log("Colliding with an object!");
    }

    /// <summary>
    /// Every frame, as long as there is still a collision occurring, keep the bool
    /// variable true.
    /// </summary>
    /// <param name="collision">Colliding triangle obstacle</param>
    public void OnTriggerStay2D(Collider2D collision)
    {
        collidingThisFrame = true;
        Debug.Log("Continuous collision!");
    }

    /// <summary>
    /// Once the fish exits the collider of an obstacle, remove all references
    /// to a single or multiple obstacles.
    /// </summary>
    /// <param name="collision">Colliding triangle obstacle</param>
    public void OnTriggerExit2D(Collider2D collision)
    {
        // Set needed values for fields of the class when there is a single obstacle.
        collidingThisFrame = false;
        collidingObstacle = null;

        // Remove obstacle from the list upon final exit
        collidingObstacles.Remove(collision);

        // Console debugging
        Debug.Log("Exited collision!");
    }

    /// <summary>
    /// Draws gizmos for assistance with debugging.
    /// </summary>
    private void OnDrawGizmos()
    {
        // --------------------------------------------------------------------
        // Set the Gizmo colors for this fish -->
        // Green: Not colliding with any obstacle
        // Red:   Colliding with an obstacle
        // --------------------------------------------------------------------
        
        if (collidingThisFrame)                     // Single obstacle
        //if (collidingObstacles.Count > 0)         // Multiple obstacles
        {
            Gizmos.color = Color.red;
        }
        else
        {
            Gizmos.color = Color.green;
        }


        // --------------------------------------------------------------------
        // Draw a Gizmo representing this fish -->
        // WireSphere: An outline around the fish
        // Cube:       Tinted cube covering the fish
        // Sphere:     Tinted sphere covering the fish
        // --------------------------------------------------------------------
        //Gizmos.DrawWireSphere(transform.position, transform.localScale.x/2);
        //Gizmos.DrawCube(transform.position, transform.localScale);
        Gizmos.DrawSphere(transform.position, transform.localScale.x/2);


        // --------------------------------------------------------------------
        // Draw a Gizmo representing relationship to the colliding obstacle -->
        // DrawLine: Line drawn from one position to the other
        // --------------------------------------------------------------------

        // Set the Gizmo color to yellow from now on
        Gizmos.color = Color.yellow;

        // For a single colliding obstacle:
        if (collidingObstacle != null)
        {
            Gizmos.DrawLine(transform.position, collidingObstacle.transform.position);
        }

        // For multiple colliding obstacles:
        foreach (Collider2D collision in collidingObstacles)
        {
            Gizmos.DrawLine(transform.position, collision.transform.position);
        }
    }

    /// <summary>
    /// Draw simnple Debug lines that appear in gameplay.
    /// </summary>
    public void DrawDebugLines()
    {
        SpriteRenderer spriteRend = GetComponentInChildren<SpriteRenderer>();

        if (collidingThisFrame)                     // Single obstacle
        //if (collidingObstacles.Count > 0)         // Multiple obstacles
        {
            spriteRend.color = Color.red;
        }
        else
        {
            spriteRend.color = Color.white;
        }

        // For a single colliding obstacle:
        if (collidingObstacle != null)
        {
            Debug.DrawLine(transform.position, collidingObstacle.transform.position, Color.magenta);
        }

        // For multiple colliding obstacles:
        foreach (Collider2D collision in collidingObstacles)
        {
            Debug.DrawLine(transform.position, collision.transform.position, Color.magenta);
        }
    }
}
