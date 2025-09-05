using UnityEngine;

public class Instantiator : MonoBehaviour
{
    // Fields                               // Values for testing/init

    [SerializeField]
    private int number = 500;               // 500



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    // Think of this like a constructor
    void Start()
    {
        Debug.Log("Number is " + number);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
