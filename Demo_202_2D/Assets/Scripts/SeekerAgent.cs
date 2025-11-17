using UnityEngine;
using UnityEngine.UIElements;


/// <summary>
/// Child of Agent class
/// Only goal is to seek a specified GameObject
/// </summary>
public class SeekerAgent : Agent
{
    // 2 types of targets for this Seeker agent:
    // One to go toward
    // One to steer away from
    public GameObject seekingTarget;
    public GameObject fleeingTarget;
    public float fleeRadius;
    public float seekWeight;
    public float fleeWeight;


    /// <summary>
    /// Overridden CalcSteeringForce calls any of the steering methods from the base Agent class.
    /// This SeekerAgent's only goal is to seek a target GameObject.
    /// </summary>
    /// <returns>Steering force to seek the target</returns>
    public override Vector3 CalcSteeringForce()
    {
        // Calc dist between flee target and agent
        // Sq mag
        // Compare against square radius

        //float distanceToFleeTarget = 
        //    Vector3.Distance(fleeingTarget.transform.position, transform.position);
        // Pythag theorem

        // Use SquareMag property of the Vector3 class:  Vector3.SqrMagnitude
        Vector3 vecFromAgentToTarget = 
            fleeingTarget.transform.position - transform.position;
        float squaredDistance = vecFromAgentToTarget.sqrMagnitude;

        Vector3 ultimateForce = Vector3.zero;

        if (squaredDistance > fleeRadius * fleeRadius)
        {
            seekWeight = 1;
            fleeWeight = 0;
        }
        else
        {
            seekWeight = 1;
            fleeWeight = 1;
        }

        ultimateForce += Seek(seekingTarget) * seekWeight;
        ultimateForce += Flee(fleeingTarget) * fleeWeight;
        return ultimateForce;
    }
}
