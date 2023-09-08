using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;

public class AIMoveState : MonoBehaviour, IEnemyState
{
    private AIStateMachine stateMachine;
    public NavMeshAgent agent;
    public GameObject target;

    public AIMoveState(AIStateMachine stateMachine)
    {
        this.stateMachine = stateMachine;
    }

    public void Enter() //First thing the state does.
    {
        Debug.Log("Entering Move State");
        agent = GetComponentInParent<NavMeshAgent>();
    }

    public void Update() //Good ol update
    {
        agent.SetDestination(target.transform.position);
        if (agent.transform.position == target.transform.position)
        {
            stateMachine.SetState(new AIIdleState(stateMachine)); //Sends us back to idle.
        }
    }

    public void Exit() //Last thing the state does before sending us wherever the user specified.
    {
        Debug.Log("Exiting Move State");
        

    }
}
