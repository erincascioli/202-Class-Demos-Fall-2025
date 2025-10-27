
using UnityEngine;
using UnityEngine.InputSystem;


/// <summary>
/// Vehicle script will be inherited by the Agent class and the "Car/Truck" class
/// Base code for vector-based movement of objects that locomote.
/// </summary>
public class Vehicle : MonoBehaviour
{
    // Rigidbody we can manipulate
    public Rigidbody rBody;

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
        // END OF CLASS ON WEDNESDAY:
        //Move();
    }

    public void FixedUpdate()
    {
        Move();
    }

    public void Move()
    {
        // --------------------------------------------------------------------
        // End of class on Wednesday:
        // --------------------------------------------------------------------
        /*
        // Velocity is speed times a direction, normalized.
        velocity = maxSpeed * movementDirection.normalized * Time.deltaTime;
        transform.position += velocity;

        // Draw a blue line along this object's forward vector
        Debug.DrawLine(transform.position, transform.position + transform.forward * 4, Color.blue);
        */


        // --------------------------------------------------------------------
        // Changes for Friday's class:
        // --------------------------------------------------------------------
        // Notes from Erin regarding scene setup:
        // 1. Ensure the little vehicle you've designed is positionally accurate. 
        //    i.e. its centered around (0, 0, 0)
        // 2. Let's give the scene a floor to "drive" on
        // 3. Move camera up, angle camera down

        // Things to mention:
        // - Vehicle pointing down the positive Z axis (its forward), facing away from camera.  
        //   - Just like in real life - a camera behind ourselves would not see the front of the car.

        // Notes from Erin regarding where to go from here:
        // 1. Swap to MovePosition instead of updating the transform.
        // 2. Swap to FixedUpdate instead of Update.
        // 3. Get direction from input
        // 4. Set forward to point in the correct direction
        /*
        // Velocity is speed times a direction, normalized.
        velocity = maxSpeed * movementDirection.normalized * Time.fixedDeltaTime;
        rBody.MovePosition(transform.position + velocity);

        // This is an initial way to point the vehicle toward its direction... 
        // it's choppy, but it'll work for now.
        transform.forward = movementDirection;

        // Draw a blue line along this object's forward vector
        Debug.DrawLine(transform.position, transform.position + transform.forward * 4, Color.blue);
        */


        // --------------------------------------------------------------------
        // Now, bring in acceleration!
        // --------------------------------------------------------------------
        // Then, let's change to utilize acceleration of the vehicle
        // 0. Only change direction when user presses a different WASD key
        // 1. Set acceleration vector
        // 2. Add acceleration to velocity

        /*
        // Acceleration is the accumulation of force over time
        // Mag != 0 when user presses a WASD key, 0 otherwise
        acceleration = accelerationRate * movementDirection.normalized * Time.fixedDeltaTime;

        // Apply the acceleration to the vehicle's velocity
        velocity += acceleration;

        // Make sure it doesn't exceed the max speed!
        velocity = Vector3.ClampMagnitude(velocity, maxSpeed);

        rBody.MovePosition(transform.position + velocity);
        */
        // Only change facing direction when player presses a different WASD key
        //if (movementDirection != Vector3.zero)
        //{
        //    transform.forward = movementDirection;
        //}
        

        // --------------------------------------------------------------------
        // Deceleration!
        // --------------------------------------------------------------------
        // 1. Try deceleration for your own exercise!

        
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        // See what value is being retrieved from WASD
        Vector2 retrievedDirection = context.ReadValue<Vector2>();
        //Debug.Log(retrievedDirection);

        // Read the direction in from WASD
        // The direction's Y value is being retrieved while the Vehicle moves along the Z axis.
        movementDirection = new Vector3(retrievedDirection.x, 0, retrievedDirection.y);
    }
}
