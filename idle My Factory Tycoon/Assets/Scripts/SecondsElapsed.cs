using System;
using UnityEngine;

public class SecondsElapsed : MonoBehaviour {

    private float startTime;
    [NonSerialized] public int seconds;

    void Start() {
        startTime = Time.time;
    }

    void Update() {
        float t = Time.time - startTime;
        seconds = (int)t;
    }
}
