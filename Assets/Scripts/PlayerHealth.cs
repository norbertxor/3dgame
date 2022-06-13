using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {
    public static bool isDeath;
    public float health = 100;
    public RectTransform healthBar;

    private Rigidbody _rb;

    private void Start() {
        _rb = GetComponent<Rigidbody>();
    }

    public void TakeDamage(float damage) {
        if(health <= 0)
            return;
        if (BuhloController.isInvulnerability)
            damage = 0;
        health -= damage;
        SetHealthBar();
        if (health <= 0 && !isDeath) {
            isDeath = true;
            _rb.constraints = RigidbodyConstraints.None;
            _rb.AddForce(Vector3.up * 250f);
            _rb.AddTorque(Vector3.back * 150f);
            Destroy(gameObject, 5f);
        }
    }

    public void SetHealthBar() {
        healthBar.offsetMax = new Vector2(-1 * 160f * (100f - health) / 100f, 5);
    }
}