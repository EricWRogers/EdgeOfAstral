using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class AIMoveState : MonoBehaviour, IEnemyState
{
    private AIStateMachine stateMachine;
    private NavMeshAgent agent;
    public GameObject target;

    public List<Transform> points = new List<Transform>();
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
            Debug.Log("Cant reach em boss.");

            GenereateWaypoints();

            Patrol();

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
            agent.destination = points[destPoint].position;
        }

        destPoint = (destPoint + 1) % points.Count;


    }
    public bool PathValid(Transform _target)
    {
        return agent.CalculatePath(_target.position, agent.path);

    }

    public void GenereateWaypoints()
    {
        float i = 1;

        if(FindPoints(i).Length <= 2)
        {
            Debug.Log("Iterator = " + i);
            if(FindPoints(i++).Length >= 2)
            {
                foreach(RaycastHit hit in FindPoints(i))
                {
                    points.Add(hit.transform);
                }
                return;
            }
        }
        else
        {
            Debug.Log("Idk man");
        }
        
    }

    public RaycastHit[] FindPoints(float _radius)
    {
        radius = _radius;
        Debug.Log("Thing = " + Physics.SphereCastAll(target.transform.position, _radius, transform.forward, 8));
        return Physics.SphereCastAll(target.transform.position, _radius, transform.forward, 8);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(target.transform.position, radius);
    }

}
