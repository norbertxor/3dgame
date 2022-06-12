using System;
using UnityEngine;
using UnityEngine.AI;

public class EnemyHealth : MonoBehaviour {
    public int health = 100;
    public GameObject healthBar;

    private Rigidbody _rb;
    private int _fullHp;
    
    private void Start() {
        _rb = GetComponent<Rigidbody>();
        _fullHp = health;
    }

    public void TakeDamage(int damage) {
        health -= damage;
        if(healthBar != null)
            healthBar.transform.localScale = new Vector3((float)health/_fullHp,0.1f,0.1f);
        if (health <= 0) {
            Destroy(healthBar);
            GetComponent<Animator>().enabled = false;
            GetComponent<NavMeshAgent>().enabled = false;
            _rb.constraints = RigidbodyConstraints.None;
            _rb.AddForce(Vector3.up * 250f);
            _rb.AddTorque(Vector3.back * 150f);
            Destroy(gameObject, 5f);
        }
    }
}