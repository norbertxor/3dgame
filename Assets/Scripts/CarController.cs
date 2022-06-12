using System;
using UnityEngine;
using System.Collections;
using Unity.VisualScripting;

public class CarController : MonoBehaviour {

    public GameObject player;
    public float speed = 30.0f;
    public float turnSpeed = 55.0f;
    
    private Rigidbody _rb;
    private Player _player;
    private float _moveDirection;
    private float _timer = 0.2f;

    void Start() { 
        _rb = GetComponent<Rigidbody>();
        _player = player.GetComponent<Player>();
    }

    void Update() {
        if (Player.inCar) {
            _timer = Mathf.Clamp01(_timer - Time.deltaTime);
            _moveDirection = Input.GetAxis("Vertical") * -speed * Time.deltaTime;
            _rb.MovePosition(transform.position + transform.forward * _moveDirection);
            float turn = Input.GetAxis("Horizontal");
            if (_moveDirection > 0)
                turn *= -1;
            transform.Rotate(0, turn * turnSpeed * Time.deltaTime, 0);

            if (Input.GetKeyDown(KeyCode.E) && _timer == 0) {
                _player.ExitCar();
                _timer = 0.2f;
            }
        }
    }
}

