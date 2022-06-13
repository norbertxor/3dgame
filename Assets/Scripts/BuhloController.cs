using System;
using UnityEngine;

public class BuhloController : MonoBehaviour {
    
    [NonSerialized] public static bool isInvulnerability;
    private float _slowdownTimer, _invulnerabilityTimer;

    private void Update() {
        if (_slowdownTimer > 0) {
            Time.timeScale = Mathf.Clamp(Time.timeScale - Time.deltaTime, 0.5f, 1f);
            _slowdownTimer -= Time.deltaTime;
        }
        else if (_slowdownTimer < 0) {
            Time.timeScale = 1f;
            _slowdownTimer = 0;
            
        }

        if (_invulnerabilityTimer > 0) {
            isInvulnerability = true;
            _invulnerabilityTimer -= Time.deltaTime;
        } else if (_invulnerabilityTimer < 0) {
            _invulnerabilityTimer = 0;
            isInvulnerability = false;
        }
    }

    public void SetSlowDown() {
        _slowdownTimer = 2.5f;
    }

    public void SetInvulnerability() {
        _invulnerabilityTimer = 5f;
    }
}