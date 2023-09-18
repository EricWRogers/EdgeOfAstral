using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class AIMoveState : MonoBehaviour, IEnemyState
{
    private AIStateMachine stateMachine;
    private NavMeshAgent agent;
    public GameObject target;

    public List<Vector3> points = new List<Vector3>();
    private int destPoint = 0;

    float radius = 0;

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
            Debug.Log("Can't reach the target.");

            if (GenerateWaypoints()) // Try generating waypoints.
            {
                Patrol();
            }
            else
            {
                // Increase the radius and try again if no waypoints were found.
                radius += 1;
                GenerateWaypoints();
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
        if (PathValid(target.transform) == true || points.Count == 0)
        {
            agent.autoBraking = true;
            points.Clear();
            return;
        }

        agent.autoBraking = false;

        if (!agent.pathPending && agent.remainingDistance < 0.5f)
        {
            agent.destination = points[destPoint];
        }

        destPoint = (destPoint + 1) % points.Count;
    }

    public bool GenerateWaypoints()
    {
        float i = 1;

        RaycastHit[] hits = FindPoints(radius);

        if (hits.Length <= 2)
        {
            Debug.Log("Iterator = " + i);
            if (hits.Length >= 2)
            {
                foreach (RaycastHit hit in hits)
                {
                    if (hit.collider.CompareTag("Ground")) // You may need to tag walkable surfaces.
                    {
                        points.Add(hit.point);
                    }
                }
                return true;
            }
        }
        else
        {
            Debug.Log("No suitable points found.");
        }

        return false;
    }

    public RaycastHit[] FindPoints(float _radius)
    {
        return Physics.SphereCastAll(target.transform.position, _radius, Vector3.up, 8, NavMesh.AllAreas);
    }


    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(target.transform.position, radius); 
    }

    public bool PathValid(Transform _target)
    {
        return agent.CalculatePath(_target.position, agent.path);

    }

}
