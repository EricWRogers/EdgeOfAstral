using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public interface IEnemyState
{
    void Enter();
    void Update();
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
        currentState.Update();
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
