using System;
using UnityEngine;

public class PauseScript : MonoBehaviour {

    public GameObject pauseMenu;

    private bool _isPaused;
    private void Update() {
        if (Input.GetKeyUp(KeyCode.Escape)) {
            if (!_isPaused) {
                Time.timeScale = 0f;
                pauseMenu.SetActive(true);
            }

            else {
                Time.timeScale = 1f;
                pauseMenu.SetActive(false);
            }

            _isPaused = !_isPaused;
        }
    }
}