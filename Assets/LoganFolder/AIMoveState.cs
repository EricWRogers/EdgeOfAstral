using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class AIMoveState : MonoBehaviour, IEnemyState
{
    private AIStateMachine stateMachine;
    private NavMeshAgent agent;
    public GameObject target;

    public List<Vector3> points = new List<Vector3>();
    private int destPoint = 0;

    public float radius = 1;

    public AIMoveState(AIStateMachine stateMachine)
    {
        this.stateMachine = stateMachine;
    }

    public void Enter() //First thing the state does.
    {
        Debug.Log("Entering Move State");
        //agent = GetComponentInParent<NavMeshAgent>();
        agent = FindAnyObjectByType<NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("Player");

    }

    public void Run() //Good ol update
    {
        agent.SetDestination(target.transform.position);
        if (Vector3.Distance(agent.transform.position, target.transform.position) <= 2)
        {
            stateMachine.SetState(new AIIdleState(stateMachine)); //Sends us back to idle.

        }

        if (PathValid(target.transform) == false)
        {
            Debug.Log("Can't get there boss.");

            if (GenerateWaypoints() && points.Count > 2) //IF this returns true, execute the patrol.
            {
                Debug.Log("Found a few points off the bat");
                Patrol();
            }
            else //Increase the radius and try again if no waypoints were found.
            {
                Debug.Log("Looking for points 1");
                
                radius += 1;
                GenerateWaypoints();

            }

            if (points.Count > 0)
            {
                Patrol();
            }
        }
       
    }

    public void Exit() //Last thing the state does before sending us wherever the user specified in update.
    {

        Debug.Log("Exiting Move State");

    }

    public void Patrol()
    {
        if (PathValid(target.transform) == true || points.Count < 2)
        {
            Debug.Log("We aint patrollin.");
            agent.autoBraking = true;
            points.Clear();
            return;
        }
        Debug.Log("We are patrolin.");
        agent.autoBraking = false;

        if (!agent.pathPending && agent.remainingDistance < 0.5f && points.Count != 0)
        {
            agent.destination = points[destPoint];
        }
        if (points.Count != 0)
        {
            destPoint = (destPoint + 1) % points.Count;
        }

    }

    public bool GenerateWaypoints()
    {
        int i = 0;
      
        RaycastHit[] hits = FindPoints(radius);

        if (hits.Length >= 2)
        {
            Debug.Log("We got points.");
            foreach (RaycastHit hit in hits)
            {
                i++;
                
                Debug.Log("Hit " + i + " " + hit.point);
                if (!points.Contains(hit.point))
                {
                    points.Add(hit.point);
                    Debug.Log("Added Point" + hit.point);
                    Debug.Log("Point count: " + points.Count);
                }
            }
            return true;
        }

        Debug.Log("No point.");
        return false;

    }

    public RaycastHit[] FindPoints(float _radius)
    {
        Debug.Log("Finding points");
       // Debug.Log("Radius: " + _radius);
        return Physics.SphereCastAll(target.transform.position, 10, Vector3.up, 0, 8)
        .GroupBy(hit => hit.point) // Group hits by their point
        .Select(group => group.First()) // Select the first hit from each group
        .ToArray(); // Convert the result to an array
    }


    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(target.transform.position, 10);
     
    }

    public bool PathValid(Transform _target)
    {
        return agent.CalculatePath(_target.position, agent.path);

    }

}
