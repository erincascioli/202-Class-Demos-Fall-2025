using UnityEditor.Experimental.GraphView;
using UnityEngine;

public abstract class Agent : MonoBehaviour
{

    public Vector3 velocity;
    public Vector3 acceleration;
    public float maxSpeed;
    public float maxForce;

    void Start()
    {
        
    }

    public abstract Vector3 CalcSteeringForce();

    // Update is called once per frame
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
    }

    public Vector3 Seek(GameObject target)
    {
        // 1. Calculate a desired velocity from my pos to target's pos
        Vector3 desiredVelocity = target.transform.position - transform.position;

        // 2. Scale desired to max speed (for a reasonable speed toward target)
        desiredVelocity = desiredVelocity.normalized * maxSpeed;

        // 3. Steering force!
        Vector3 steeringForce = desiredVelocity - velocity;

        // 4. Return the force!
        return steeringForce;
    }
}
