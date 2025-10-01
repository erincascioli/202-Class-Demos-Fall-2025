using UnityEngine;

public class JumpingBall : MonoBehaviour
{
    public Rigidbody2D rigidbody;
    public Vector3 direction;
    public float jumpForce;
    public Vector3 jumpDirection;


    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        jumpDirection = direction * jumpForce;
        rigidbody.AddForce(jumpDirection);
    }
}
