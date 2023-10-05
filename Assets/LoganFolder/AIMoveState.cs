using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class AIMoveState : MonoBehaviour, IEnemyState
{
    private AIStateMachine stateMachine;
    private NavMeshAgent agent;
    public GameObject target;

    public bool checkPoint;

    private int currentPatrolIndex = 0;

    public AIMoveState(AIStateMachine stateMachine)
    {
        this.stateMachine = stateMachine;
    }

    public void Enter() //First thing the state does.
    {
        //agent = GetComponentInParent<NavMeshAgent>();
        agent = FindAnyObjectByType<NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("Player");



    }

    public void Run() //Good ol update
    {
        Debug.Log("Path Valid is: " + PathValid(target.transform));

       

        MoveAgent(target.transform);
        /*
        if (Vector3.Distance(agent.transform.position, target.transform.position) <= 2)
        {
            stateMachine.SetState(new AIIdleState(stateMachine)); //Sends us back to idle.

        }

        if (!PathValid(target.transform) && OmnicatLabs.CharacterControllers.CharacterController.Instance.isGrounded )
        {
            Patrol();
            
            
        }

        if(!PathValid(target.transform) && checkPoint == true)
        {
            Transition();
        }
        */

    }

    public void Exit() //Last thing the state does before sending us wherever the user specified in update.
    {
       // stateMachine.SetState(new AIIdleState(stateMachine));

    }

    public void Patrol()
    {
        GameObject[] patrolRoutes = GameObject.FindGameObjectsWithTag("PatrolRoute");

        if (patrolRoutes.Length > 0)
        {
            GameObject closestPatrolRoute = null;
            float closestDistance = float.MaxValue;

            foreach (GameObject route in patrolRoutes)
            {
                float distanceToRoute = Vector3.Distance(target.transform.position, route.transform.position);

                if (distanceToRoute < closestDistance)
                {
                    closestDistance = distanceToRoute;
                    closestPatrolRoute = route;
                }
            }

            if (closestPatrolRoute != null)
            {
                Transform[] patrolPoints = closestPatrolRoute.GetComponentsInChildren<Transform>();


                List<Transform> validPatrolPoints = patrolPoints.Where(point => point != closestPatrolRoute.transform).ToList();

                if (validPatrolPoints.Count > 0)
                {
                    if (Vector3.Distance(agent.transform.position, validPatrolPoints[currentPatrolIndex].position) <= 2)
                    {
                        currentPatrolIndex = (currentPatrolIndex + 1) % validPatrolPoints.Count;
                    }

                    agent.SetDestination(validPatrolPoints[currentPatrolIndex].position);
                }
                else
                {
                    Debug.LogError("No valid patrol points found.");
                }
            }
            else
            {
                Debug.LogError("No valid patrol route found.");
            }
        }
        else
        {
            Debug.LogError("No patrol routes found in the scene.");
        }
    }

    public void Transition()
    {
        GameObject[] transitions = GameObject.FindGameObjectsWithTag("Transition");

        if (transitions.Length > 0)
        {
            GameObject closestTrans = null;
            float closestDistance = float.MaxValue;

            foreach (GameObject trans in transitions)
            {
                float distanceToTrans = Vector3.Distance(target.transform.position, trans.transform.position);

                if (distanceToTrans < closestDistance)
                {
                    closestDistance = distanceToTrans;
                    closestTrans = trans;
                }
            }

            if (closestTrans != null)
            {
                MoveAgent(closestTrans.transform);
                if (agent.isPathStale)
                {
                    Debug.Log("Stale");
                    stateMachine.SetState(new AIIdleState(stateMachine));
                }
            }
        }

    }

    public bool PathValid(Transform _target)
    {
        //Debug.Log("Path is: " + agent.CalculatePath(_target.position, agent.path));
       
        NavMeshPath path = new NavMeshPath();
        agent.CalculatePath(_target.position, path);

        if(!agent.CalculatePath(_target.position, path) || path.status == NavMeshPathStatus.PathPartial || path.status == NavMeshPathStatus.PathInvalid)
        {
            return false;
        }

        if (agent.CalculatePath(_target.position, path) || path.status == NavMeshPathStatus.PathComplete)
        {
            return true;
        }

        else
        {
            Debug.Log("PathValid Failed");
            return false;
        }
    }

    public void MoveAgent(Transform destination)
    {
        if (!agent.hasPath)
        {
            Debug.Log("No Path");
            //Validate the path
            NavMeshPath path = new NavMeshPath();
            agent.CalculatePath(destination.position, path);
           
            if (path.status == NavMeshPathStatus.PathComplete)
            {
                Debug.Log("Path Set");
                agent.SetPath(path);
            }
            else
            {
                Debug.Log("Bad Path.");
            }
        }
        else
        {
            Debug.Log("No need for a path.");
            return;
        }
    }

}
