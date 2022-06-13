using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class EnemuAttack : MonoBehaviour {
    
    public float damage = 5;
    private Coroutine dmg;
    
    private NavMeshAgent _agent;
    private Animator _animator;
    
    private void Start() {
        _agent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
    }

    private void OnTriggerStay(Collider other) {
        if (other.CompareTag("Player"))
            if(_agent.enabled)
                _agent.SetDestination(other.transform.parent.gameObject.transform.position);
        
        if(other.CompareTag("Attack"))
            if (dmg == null && !PlayerHealth.isDeath) {
                dmg = StartCoroutine(SetDamage(other));
                _animator.SetBool("isAttack", true);
            }
        
        if(other.CompareTag("Attack") && PlayerHealth.isDeath)
            StopCoroutine(dmg);

    }

    private void OnTriggerExit(Collider other) {
        if (other.CompareTag("Player"))
            GetComponent<MooveAgents>().SetNewPath();
        if (other.CompareTag("Attack")) {
            StopCoroutine(dmg);
            dmg = null;
            _animator.SetBool("isAttack", false);
        }
    }
    
    IEnumerator SetDamage(Collider other) {
        while (true) {
            if(_agent.enabled)
                other.transform.parent.gameObject.GetComponent<PlayerHealth>().TakeDamage(damage);
            yield return new WaitForSeconds(1f);
        }
    }
}