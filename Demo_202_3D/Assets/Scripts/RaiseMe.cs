using UnityEngine;


/// <summary>
/// "Raise" an object (increase its y value) continually
/// </summary>
public class RaiseMe : MonoBehaviour
{
    // References and other fields!!!
    // how far to move the object/speed
    // how often to apply transform
    // position (Transform) X

    public float speed;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Increase Y value by the speed to "raise" the object in my scene
        //transform.position.y += speed;   NO!!!!!!!!!!!!!!!!!!!!
        Vector3 positionCopy = transform.position;
        positionCopy.y += speed;
        transform.position = positionCopy;

        /*
        transform.position = new Vector3(
            transform.position.x, 
            transform.position.y + speed, 
            transform.position.z);
        */
    }
}
