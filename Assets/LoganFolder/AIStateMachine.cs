using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public interface IEnemyState
{
    void Enter();
    void Run();
    void Exit();
}

public class AIStateMachine : MonoBehaviour
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
