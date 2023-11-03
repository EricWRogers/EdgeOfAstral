using UnityEngine;
using UnityEngine.AI;

public class AIAttackState : MonoBehaviour, IEnemyState
{
    private AIStateMachine stateMachine;
    private NavMeshAgent agent;
    private GameObject target;
    private NavMeshHit lastHit;

    public int attackRange = 10;
    public void Enter(AIStateMachine stateMachine) //First thing the state does.
    {

        Debug.Log("Entering Attack State");
        this.stateMachine = stateMachine;

        agent = gameObject.GetComponent<AIChaseState>().agent;
        target = gameObject.GetComponent<AIChaseState>().target;

        lastHit = gameObject.GetComponent<AIChaseState>().lastHit;
    }

    public void Run() //Good ol update
    {
        agent.SetDestination(target.transform.position);

        if (Vector3.Distance(lastHit.position, target.transform.position) <= attackRange && Vector3.Distance(agent.transform.position, target.transform.position) <= attackRange)
        {
            target.transform.position = gameObject.transform.position;
            stateMachine.SetState(gameObject.GetComponent<AIIdleState>());
        }
        else
        {
            stateMachine.SetState(gameObject.GetComponent<AIChaseState>());
        }
    }
        public void Exit() //Last thing the state does before sending us wherever the user specified in update.
        {
            Debug.Log("Exiting Attack State");
        }
}
