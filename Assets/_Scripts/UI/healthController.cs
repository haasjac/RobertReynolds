﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;



public class healthController : MonoBehaviour {

    public GameObject FullHealth;
    public GameObject TopHealth;
    public GameObject BottomHealth;

    public partController top;
    public partController bottom;
    public partController full;

    public StateMachine sm;

	// Use this for initialization
	void Awake () {
        sm = new StateMachine();
    }
	
	// Update is called once per frame
	void Update () {
        sm.Update();
	}
}