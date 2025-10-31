using UnityEngine;

public class SeekerAgent : Agent
{
    public GameObject target;

    public override Vector3 CalcSteeringForce()
    {
        Vector3 seekForce = Seek(target);
        Debug.Log(seekForce);
        return seekForce;
    }
}
