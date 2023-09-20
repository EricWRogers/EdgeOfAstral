using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class AIMoveState : MonoBehaviour, IEnemyState
{
    private AIStateMachine stateMachine;
    private NavMeshAgent agent;
    public GameObject target;


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

            GetPatrolPoints();
            Patrol();
        }
       
    }

    public void Exit() //Last thing the state does before sending us wherever the user specified in update.
    {

        Debug.Log("Exiting Move State");

    }

    public void Patrol()
    {
        

    }

    public void GetPatrolPoints()
    {
      
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
