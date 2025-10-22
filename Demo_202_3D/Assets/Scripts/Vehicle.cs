using UnityEngine;


/// <summary>
/// Vehicle script will be inherited by the Agent class and the "Car/Truck" class
/// Base code for vector-based movement of objects that locomote.
/// </summary>
public class Vehicle : MonoBehaviour
{
    // Part of “movement formula” we've studied thus far
    [SerializeField]
    private Vector3 velocity;
    [SerializeField]
    private Vector3 acceleration;

    // Capturing user input to move vehicle along its transform
    [SerializeField]
    private Vector3 movementDirection;

    // Handling smallest and largest speeds
    [SerializeField]
    private float maxSpeed;
    [SerializeField]
    private float minSpeed;

    // Rates of acceleration and deceleration
    [SerializeField]
    private float accelerationRate;
    [SerializeField]
    private float decelerationRate;

    // Steering the vehicle 
    [SerializeField]
    private float turnSpeed;            // Scalar of velocity
    [SerializeField]
    private Quaternion turning;	        // Rotation


    void Start()
    {
        
    }

    void Update()
    {
        Move();
    }

    public void FixedUpdate()
    {
    }

    public void Move()
    {
        // Velocity is speed times a direction, normalized.
        velocity = maxSpeed * movementDirection.normalized * Time.deltaTime;
        transform.position += velocity;

        // Draw a blue line along this object's forward vector
        Debug.DrawLine(transform.position, transform.position + transform.forward * 4, Color.blue);
    }

}
