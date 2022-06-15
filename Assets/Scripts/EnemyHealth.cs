using System;
using UnityEngine;
using UnityEngine.AI;

public class EnemyHealth : MonoBehaviour {
    public float health = 100;
    public GameObject healthBar;
    public Color deathColor;
    public GameObject[] mummyParts;
    [NonSerialized] public bool isDeath, canHeal;
    
    
    private Rigidbody _rb;
    private AudioSource _dieSound;
    private ZoimbieSound _zoimbieSound;
    private Coroutine _zombieSoundsCoroutine;
    private float _fullHp;
    
    private void Start() {
        _rb = GetComponent<Rigidbody>();
        _dieSound = GetComponent<AudioSource>();
        _zoimbieSound = GetComponentInChildren<ZoimbieSound>();
        _fullHp = health;
        canHeal = true;
       _zombieSoundsCoroutine = StartCoroutine(_zoimbieSound.SpawnAudio());
    }

    public void TakeDamage(float damage) {
        health -= damage;
        if(healthBar != null)
            healthBar.transform.localScale = new Vector3(Mathf.Clamp01(health/_fullHp),0.1f,0.1f);
        if (health <= 0 && !isDeath) {
            isDeath = true;
            _dieSound.Play();
            Destroy(healthBar);
            SetNewColor(deathColor);
            GetComponent<Animator>().enabled = false;
            GetComponent<NavMeshAgent>().enabled = false;
            _rb.constraints = RigidbodyConstraints.None;
            _rb.AddForce(Vector3.up * 250f);
            _rb.AddTorque(Vector3.back * 150f);
            StopCoroutine(_zombieSoundsCoroutine);
            Destroy(gameObject, 5f);
        }
    }

    public void SetNewColor(Color color) {
        foreach (GameObject obj in mummyParts)
            obj.GetComponent<SkinnedMeshRenderer>().material.color = color;
    }
}