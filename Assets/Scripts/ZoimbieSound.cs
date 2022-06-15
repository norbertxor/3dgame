using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ZoimbieSound : MonoBehaviour {

    public AudioClip[] zombieSounds;
    
    private AudioSource _audioSource;
    

    private void Start() {
        _audioSource = GetComponent<AudioSource>();
    }

    public IEnumerator SpawnAudio() {
        while (true) {
            yield return new WaitForSeconds(4f);
            _audioSource.clip = zombieSounds[Random.Range(0, zombieSounds.Length)];
            _audioSource.Play();
        }
    }
}