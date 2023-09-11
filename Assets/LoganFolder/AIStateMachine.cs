using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public interface IEnemyState //Make the states inherit from this. Basically will force that script to have these functions. If it dont it dont work.
{
    void Enter();
    void Run();
    void Exit();
}

public class AIStateMachine : MonoBehaviour //Dont touch this script.
{
    private IEnemyState currentState;

    private void Start()
    {
        SetState(new AIIdleState(this));
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
        currentState.Enter();
    }

}
