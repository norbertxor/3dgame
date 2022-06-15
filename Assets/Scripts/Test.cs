using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public enum SoundsTypes {
    jump,
    walk,
    idle

}




public class Test : MonoBehaviour {
    public Dictionary<SoundsTypes, AudioSource> Sounds;

}