using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.Linq;
using OmnicatLabs.CharacterControllers;

public class AIMoveState : MonoBehaviour, IEnemyState
{
    public bool checkPoint = true;

    private AIStateMachine stateMachine;
    private NavMeshAgent agent;
    public GameObject target;

    private int currentPatrolIndex = 0;

    private GameObject[] patrolRoutes;
    private GameObject[] transitions;

    public OmnicatLabs.CharacterControllers.CharacterController characterController;

    public void Enter(AIStateMachine stateMachine) //First thing the state does.
    {
        this.stateMachine = stateMachine;
        agent = FindAnyObjectByType<NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("Player");

        patrolRoutes = GameObject.FindGameObjectsWithTag("PatrolRoute");
        transitions = GameObject.FindGameObjectsWithTag("Transition");

        characterController = target.GetComponent<OmnicatLabs.CharacterControllers.CharacterController>();
    }

    public void Run() //Good ol update
    {
        if (ValidatePath(target))
        {
            agent.SetDestination(target.transform.position);
        }
        else if (checkPoint == true)
        {
            Transition();
        }
        else if (characterController.isGrounded == true) //Prevent the AI from randomly patrolling while I am b hopping thru da club
        {
            Patrol();
        }

    }

    public void Exit() //Last thing the state does before sending us wherever the user specified in update.
    {


    }

    public void Patrol()
    {
        Debug.Log("Patroling. .");


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
                agent.SetDestination(closestTrans.transform.position);
                //MoveAgent(closestTrans.transform);
                if (agent.isPathStale)
                {
                    //Debug.Log("Stale");
                    stateMachine.SetState(gameObject.GetComponent<AIIdleState>());
                }
            }
        }

    }

    public bool ValidatePath(GameObject _target)
    {
        if (agent.hasPath == true && agent.path.corners.Last() == _target.transform.position)
        {
            return true;
        }

        NavMeshPath path = new NavMeshPath();
        agent.CalculatePath(_target.transform.position, path);

        if (path.status == NavMeshPathStatus.PathComplete)
        {
            agent.SetPath(path);
            Debug.Log("Path is good.");
            return true;
        }
        else
        {
            Debug.Log("Path is bad.");
            // agent.ResetPath();
            return false;
        }
    }

    /* public void MoveAgent(Transform destination)
     {
         if (!agent.hasPath)
         {
             //Debug.Log("No Path");
             //Validate the path
             NavMeshPath path = new NavMeshPath();
             agent.CalculatePath(destination.position, path);

             if (path.status == NavMeshPathStatus.PathComplete)
             {
                 //Debug.Log("Path Set");
                 agent.SetPath(path);
             }
             else
             {
                 agent.ResetPath();
                 // Debug.Log("Bad Path.");
             }
         }
         else
         {
             // Debug.Log("No need for a path.");
             return;
         }
     } */


}
