using UnityEngine;


/// <summary>
/// Child of Agent class
/// Only goal is to flee from a specified GameObject
/// </summary>
public class FleeingAgent : Agent
{
    public GameObject target;

    /// <summary>
    /// Overridden CalcSteeringForce calls any of the steering methods from the base Agent class.
    /// This FleeingAgent's only goal is to flee from a target GameObject.
    /// </summary>
    /// <returns>Steering force to flee from the target</returns>
    public override Vector3 CalcSteeringForce()
    {
        Vector3 fleeForce = Flee(target);
        return fleeForce;
    }
}
