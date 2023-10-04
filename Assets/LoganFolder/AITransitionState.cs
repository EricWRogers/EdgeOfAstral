using UnityEngine;
using UnityEngine.AI;

public class AITransitionState : MonoBehaviour, IEnemyState
{
    private AIStateMachine stateMachine;

    GameObject player;
    private NavMeshAgent agent;

    public AITransitionState(AIStateMachine stateMachine)
    {
        this.stateMachine = stateMachine;
    }

    public void Enter()
    {
        agent = FindAnyObjectByType<NavMeshAgent>();
        player = OmnicatLabs.CharacterControllers.CharacterController.Instance.gameObject;
    }


    public void Run()
    {
        Debug.Log("Doin a heckin transition.");
    }


    public void Exit()
    {
      //  stateMachine.SetState(new AIIdleState(stateMachine));
    }

    public void Transition(Transform enterTrans, Transform exitTrans)
    {
        agent.SetDestination(enterTrans.position);

        if (agent.isPathStale)
        {
            agent.transform.position = exitTrans.position;
            stateMachine.SetState(new AIIdleState(stateMachine));
        }
    }
}
