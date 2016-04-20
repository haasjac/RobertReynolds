﻿using UnityEngine;
using System.Collections;

public class Oscillate : MonoBehaviour {
    public float speed = .001f;
    Vector3 startPos;
	// Update is called once per frame
    void Start()
    {
        startPos = transform.position;
    }
	void Update ()
    {
        transform.position = startPos - (new Vector3(0, Mathf.Cos(2 * Mathf.PI * Time.timeSinceLevelLoad) * speed, 0f));
    }
}
