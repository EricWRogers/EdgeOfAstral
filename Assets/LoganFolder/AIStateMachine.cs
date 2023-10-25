using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.AI;

public interface IEnemyState //Make the states inherit from this. Basically will force that script to have these functions. If it dont it dont work.
{
    void Enter(AIStateMachine stateMachine);
    void Run();
    void Exit();
}


public class AIStateMachine : MonoBehaviour //Dont touch this script.
{
    private NavMeshAgent agent;

    [HideInInspector]
    public IEnemyState currentState; //DONT TOUCH 

    private void Start()
    {
        SetState(gameObject.GetComponent<AIIdleState>());

        agent = FindAnyObjectByType<NavMeshAgent>();
    }

    private void Update()
    {
        currentState.Run();
    }

    public void SetState(IEnemyState newState)
    {
        if (currentState != null)
        {
            currentState.Exit();
        }

        currentState = newState;
        currentState.Enter(this);
    }

    public void ResetAI()
    {
        Debug.Log("Test");
    }

}
