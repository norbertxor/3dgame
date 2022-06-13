using System;
using UnityEngine;

public class HealPlayer : MonoBehaviour {

    private PlayerHealth _playerHealth;

    private void Start() {
        _playerHealth = transform.parent.GetComponent<PlayerHealth>();
    }

    private void OnTriggerStay(Collider other) {
        
        
        if (other.CompareTag("Enemy")) {
            EnemyHealth enemyHealth = other.GetComponent<EnemyHealth>();
            if (enemyHealth.canHeal && enemyHealth.isDeath && Input.GetKeyUp(KeyCode.F)) {
                enemyHealth.canHeal = false;
                enemyHealth.SetNewColor(Color.gray);
                _playerHealth.health += 10f;
                if (_playerHealth.health > 100f)
                    _playerHealth.health = 100f;
                _playerHealth.SetHealthBar();
            }
        }
    }
}