using UnityEditor.Experimental.GraphView;
using UnityEngine;

/// <summary>
/// Parent class of all Seekers, Fleers, Arrivers, etc.
/// Contains all steering force methods that any child class could need
/// </summary>
public abstract class Agent : MonoBehaviour
{
    // --------------------------------------------------------------------------------------------
    //              FIELDS ALL CHILD CLASSES NEED
    // --------------------------------------------------------------------------------------------
   
    // Serialize field to keep it protected from other Agent instances
    [SerializeField]
    private Vector3 velocity;

    // Would be beneficial to change these to private access modifier too.
    public Vector3 acceleration;
    public float maxSpeed;
    public float maxForce;

    // Other agents need to access this for future positions? Write a property!
    public Vector3 Velocity
    {
        get { return velocity; }
    }

    void Start()
    {
        
    }

    /// <summary>
    /// All child classes must implement this method.
    /// This method is intended to calculate a single steering force to allow any child agent
    /// to accomplish its goals.
    /// </summary>
    /// <returns>Steering force to accomplish the child's goals.</returns>
    public abstract Vector3 CalcSteeringForce();

    void Update()
    {
        // Start "fresh" every frame with no previous acceleration
        acceleration = Vector3.zero;

        // Allow the agent to calculate a "direction"
        Vector3 steeringForce = CalcSteeringForce();

        // Scale it to a max force (more or less is applied to agent)
        acceleration += Vector3.ClampMagnitude(steeringForce, maxForce);

        // Apply acceleration to velocity
        velocity += acceleration * Time.deltaTime;  // No Fixed Update, no rigidbody yet

        // Change the agent's position
        transform.position += velocity * Time.deltaTime;

        // ************************************************
        // WEDNESDAY:
        // ************************************************
        // 1) Make camera larger to see more
        // 2) Turn the agent toward its velocity
        // 3) Write overload of Seek
        // 4) Write Flee and overload
        // 5) Write TargetManager script to move the square target upon spacebar press

        // Orient agent to point toward its velocity
        transform.up = velocity.normalized;
    }

    // --------------------------------------------------------------------------------------------
    //              STEERING FORCE METHODS
    // --------------------------------------------------------------------------------------------
    // ************************************************************************
    // This Agent class will contain methods for:
    // Seek, Flee, Path Follow, Arrive, Wander, Stay in Bounds, Obstacle Avoidance, etc.
    // Individual child classes will call those steering methods in their implementations
    //   of CalcSteeringForce().
    // ************************************************************************


    /// <summary>
    /// Seek a GameObject in the scene
    /// </summary>
    /// <param name="target">GameObject this agent seeks</param>
    /// <returns>Steering force to seek that GameObject</returns>
    public Vector3 Seek(GameObject target)
    {
        return Seek(target.transform.position);
    }


    /// <summary>
    /// Seek a position in the scene
    /// </summary>
    /// <param name="targetVector">Position this agent seeks</param>
    /// <returns>Steering force to seek that position</returns>
    public Vector3 Seek(Vector3 targetVector)
    {
        // 1. Calculate a desired velocity from my pos to target's pos
        Vector3 desiredVelocity = targetVector - transform.position;

        // 2. Scale desired to max speed (for a reasonable speed toward target)
        desiredVelocity = desiredVelocity.normalized * maxSpeed;

        // 3. Steering force!
        Vector3 steeringForce = desiredVelocity - velocity;

        // 4. Return the force!
        return steeringForce;
    }

    /// <summary>
    /// Move away from a position in the scene
    /// </summary>
    /// <param name="targetVector">Position in the scene to flee</param>
    /// <returns>Steering force to move away from the specified position</returns>
    public Vector3 Flee(Vector3 targetVector)
    {
        // 1. Calculate a desired velocity from my pos to target's pos (away from the position)
        Vector3 desiredVelocity = transform.position - targetVector;

        // 2. Scale desired to max speed (for a reasonable speed away from target)
        desiredVelocity = desiredVelocity.normalized * maxSpeed;

        // 3. Steering force!
        Vector3 steeringForce = desiredVelocity - velocity;

        // 4. Return the force!
        return steeringForce;
    }

    /// <summary>
    /// Move away from a position in the scene
    /// </summary>
    /// <param name="target">GameObject in the scene to flee</param>
    /// <returns>Steering force to move away from the specified position</returns>
    public Vector3 Flee(GameObject target)
    {
        return Flee(target.transform.position);
    }
}
