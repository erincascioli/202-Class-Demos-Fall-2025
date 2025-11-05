using UnityEngine;

public class TargetManager : MonoBehaviour
{
    public GameObject singleTarget;

    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            float xPosition = Random.Range(-15f, 15f);
            float yPosition = Random.Range(-8f, 8f);
            singleTarget.transform.position = new Vector3(xPosition, yPosition, 0);
        }
    }
}
