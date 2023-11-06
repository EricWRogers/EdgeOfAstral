using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIIdleState : MonoBehaviour, IEnemyState //Every state must inherit from here.
{
    private AIStateMachine stateMachine;
    private NavMeshAgent agent;
    private GameObject target;

    public void Enter(AIStateMachine stateMachine) //First thing the state does.
    {
        Debug.Log("Entering Idle State");
        this.stateMachine = stateMachine;
        //Debug.Log("Entering Idle State");
        //agent = GetComponentInParent<NavMeshAgent>();
        agent = FindAnyObjectByType<NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("Player");

    }

    public void Run() //Good ol update
    {
        //Debug.Log("Idling. . ");
       
        if (Vector3.Distance(agent.transform.position, target.transform.position) >= 3)
        {
            stateMachine.SetState(gameObject.GetComponent<AIChaseState>()); //Sends us to .
        }
    }

    public void Exit() //Last thing the state does before sending us wherever the user specified in update.
    {
        Debug.Log("Exiting Idle State");

    }
}
