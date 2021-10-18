using UnityEngine;
using UnityEngine.AI;

public class ActionsEnemy : MonoBehaviour
{
    private Transform _player;
    private NavMeshAgent _agent;

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").transform;
        _agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (_agent.enabled)
            _agent.SetDestination(_player.position);
    }
}
