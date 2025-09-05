using UnityEngine;

/// <summary>
/// Attach this to a "manager" GO to control the Y movement of several
/// GO's in the scene.
/// </summary>
public class RaiseController : MonoBehaviour
{
    // References and fields?????
    public float speed;
    public GameObject box1;
    public GameObject box2;

    // Combine all necessary GOs in a D.S. 
    public GameObject[] boxes;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Raise the first box
        Vector3 positionCopy = box1.transform.position;
        positionCopy.y += speed;
        box1.transform.position = positionCopy;

        // Raise the second box
        positionCopy = box2.transform.position;
        positionCopy.y += speed;
        box2.transform.position = positionCopy;

        // Raise all GO's in the boxes array
        for(int i = 0; i < boxes.Length; i++)
        {
            positionCopy = boxes[i].transform.position;
            positionCopy.y += speed;
            boxes[i].transform.position = positionCopy;
        }
    }
}
