using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;

public class AIIdleState : MonoBehaviour, IEnemyState
{
    private AIStateMachine stateMachine;
    public NavMeshAgent agent;
    public GameObject target;
    public AIIdleState(AIStateMachine stateMachine)
    {
        this.stateMachine = stateMachine;
    }

    public void Enter()
    {
        Debug.Log("Entering Idle State");
        agent = GetComponentInParent<NavMeshAgent>();
    }

    public void Update()
    {
        Debug.Log("Idling. . ");
        if (agent.transform.position != target.transform.position)
        {
            stateMachine.SetState(new AIMoveState(stateMachine)); //Sends us back to idle.
        }
    }

    public void Exit()
    {
        Debug.Log("Exiting Idle State");

    }
}
