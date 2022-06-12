using System;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {
    public static bool isDeath;
    public int health = 100;

    private Rigidbody _rb;

    private void Start() {
        _rb = GetComponent<Rigidbody>();
    }

    public void TakeDamage(int damage) {
    health -= damage;
    if (health <= 0 && !isDeath) {
        isDeath = true;
        _rb.constraints = RigidbodyConstraints.None;
        _rb.AddForce(Vector3.up * 250f);
        _rb.AddTorque(Vector3.back * 150f);
    }
    }
}