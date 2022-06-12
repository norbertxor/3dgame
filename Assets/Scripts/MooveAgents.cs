using System;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class MooveAgents : MonoBehaviour {

    public Transform[] positions;

    private NavMeshAgent _agent;
    private Transform _nowPlace;

    private void Start() {
        _agent = GetComponent<NavMeshAgent>();
        SetNewPath();
    }

    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("pathDots"))
            SetNewPath();
    }

    public void SetNewPath() {
        Transform moveTo = positions[Random.Range(0, positions.Length)];
        if (_nowPlace != null && _nowPlace.position == moveTo.position) {
            SetNewPath();
            return;
        }

        _nowPlace = moveTo;
        if(_agent.enabled)
            _agent.SetDestination(moveTo.position);
    }
}
