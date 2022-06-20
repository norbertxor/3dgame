using System;
using UnityEngine;

public class RayShooter : MonoBehaviour {
    private Animator _animator;
    private Camera _camera;

    private void Start() {
        _animator = GetComponent<Animator>();
        _camera = Camera.main;
    }

    private void Update() {
        if (Input.GetMouseButtonUp(0)) {
            _animator.SetTrigger("Shoot");
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit, 30f, LayerMask.GetMask("Enemies")))
                hit.transform.GetComponent<EnemyHealth>().TakeDamage(20f);
        }
    }
}
