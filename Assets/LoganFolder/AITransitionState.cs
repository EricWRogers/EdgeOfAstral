using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;

public class AITransitionState : MonoBehaviour, IEnemyState //Every state must inherit from here.
{
    private AIStateMachine stateMachine;
    private NavMeshAgent agent;
    private GameObject target;

    public Transform exitTrans;

    public void Enter(AIStateMachine stateMachine) //First thing the state does.
    {
        this.stateMachine = stateMachine;
        //Debug.Log("Entering Idle State");
        //agent = GetComponentInParent<NavMeshAgent>();
        agent = FindAnyObjectByType<NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("Player");


    }

    public void Run() //Good ol update
    {
       
    }

    public void Exit() //Last thing the state does before sending us wherever the user specified in update.
    {
        //Debug.Log("Exiting Idle State");

    }

    public void TransitionAI()
    {
       
            Debug.Log("Crossed");
            // GameObject temp = GetComponentInParent<NavMeshAgent>().gameObject;

            agent.gameObject.SetActive(false);
            agent.transform.position = exitTrans.position;
            agent.gameObject.SetActive(true);
            agent.GetComponentInChildren<AIMoveState>().checkPoint = false;
        
    }
}
