using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Apple;
using static UnityEngine.GraphicsBuffer;

public class AIMoveState : MonoBehaviour, IEnemyState
{
    private AIStateMachine stateMachine;
    private NavMeshAgent agent;
    private GameObject target;

  

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

        if(PathValid() == false)
        {
            Debug.Log("Cant reach em boss.");

            return;
           
        }
    }

    public void Exit() //Last thing the state does before sending us wherever the user specified in update.
    {
        
        Debug.Log("Exiting Move State");
        
    }

    public void Patrol()
    {
        if (PathValid() == true)
        {
            return;
        }

        
    }
    public bool PathValid()
    {
        return agent.CalculatePath(target.transform.position, agent.path);

    }


}
