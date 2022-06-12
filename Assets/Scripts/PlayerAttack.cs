using System;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {

    private int _damage = 10;
    private bool _isAttack;
    private Collider _monster;
    private Animator _animator;

    private void Start() {
        _animator = transform.parent.GetComponent<Animator>();
    }


    private void Update() {
        if (Input.GetMouseButtonDown(0) && _isAttack && _monster != null && !PlayerHealth.isDeath) {
            _monster.GetComponent<EnemyHealth>().TakeDamage(_damage);
            _animator.SetTrigger("Attack");
        }
    }

    private void OnTriggerStay(Collider other) {
        if (other.CompareTag("Enemy")) {
            _isAttack = true;
            _monster = other;
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.CompareTag("Enemy")) {
            _isAttack = false;
            _monster = null;
        }
    }
}