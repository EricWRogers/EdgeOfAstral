using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.Linq;
using OmnicatLabs.CharacterControllers;
using Unity.VisualScripting;
using OmnicatLabs.Extensions;

public class AIMoveState : MonoBehaviour, IEnemyState
{
    [SerializeField]
    private bool checkPoint = true;

    private AIStateMachine stateMachine;
    private NavMeshAgent agent;
    public GameObject target;

    public int attackRange = 10;

    private int currentPatrolIndex = 0;

    private GameObject[] patrolRoutes;
    private GameObject[] transitions;

    public OmnicatLabs.CharacterControllers.CharacterController characterController;

    public void Enter(AIStateMachine stateMachine) //First thing the state does.
    {
        this.stateMachine = stateMachine;
        agent = FindAnyObjectByType<NavMeshAgent>();
       target = GameObject.FindAnyObjectByType<OmnicatLabs.CharacterControllers.CharacterController>().gameObject;

        patrolRoutes = GameObject.FindGameObjectsWithTag("PatrolRoute");
        transitions = GameObject.FindGameObjectsWithTag("Transition");
        Debug.Log(target);
        characterController = target.GetComponent<OmnicatLabs.CharacterControllers.CharacterController>();
    }

    public void Run() //Good ol update
    {
        NavMeshHit hit;
        if (ValidatePath(target))
        {
            agent.SetDestination(target.transform.position);
        }
       
        else if(NavMesh.FindClosestEdge(target.transform.position, out hit, NavMesh.AllAreas))
        {
            Debug.Log("We hit : " + hit);
            if(Vector3.Distance(hit.position, target.transform.position) <= attackRange)
            {
                Debug.Log("Test");
                agent.SetDestination(target.transform.position);

                if(Vector3.Distance(agent.transform.position, target.transform.position) <= attackRange)
                {
                    target.transform.position = agent.transform.position;
                }
            }
               
        }
        
        else if (characterController.isGrounded == true) //Prevent the AI from randomly patrolling while I am b hopping thru da club
        {
            Patrol();
        }

        

        /*if (Vector3.Distance(agent.transform.position, target.transform.position) >= 100)
        {
            checkPoint = true;

        }*/

        ResetAI(agent.gameObject, target);
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

        Debug.Log("Path: " + path.status);
        if (path.status == NavMeshPathStatus.PathComplete)
        {
            //agent.SetPath(path);
            //Debug.Log("Path is good.");
            return true;
        }
        else
        {
            //Debug.Log("Path is bad.");
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

   
    public void ResetAI(GameObject _ai, GameObject _player)
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
                NavMeshHit ai, player, closestTransHit;
                NavMesh.SamplePosition(_player.transform.position, out player, 10.0f, NavMesh.AllAreas);
                NavMesh.SamplePosition(_ai.transform.position, out ai, 10.0f, NavMesh.AllAreas);
                NavMesh.SamplePosition(closestTrans.transform.position, out closestTransHit, 10.0f, NavMesh.AllAreas);

                int currentAreaPlayer = player.mask;
                int currentAreaAI = ai.mask;
                int closestTransHitAreaHit = closestTransHit.mask;

                if (currentAreaAI != currentAreaPlayer && closestTransHitAreaHit == currentAreaPlayer)
                {
                    _ai.GetComponent<NavMeshAgent>().Warp(closestTrans.transform.position);
                }
            }
        }

    }

}
