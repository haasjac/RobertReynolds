﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public enum playerState { TOGETEHER, APART };

public class healthController : MonoBehaviour {

    public GameObject BothHealth;
    public GameObject OneHealth;
    public GameObject TwoHealth;

    public GameObject player1;
    public GameObject player2;

    public playerState pState;

    public StateMachine sm;

	// Use this for initialization
	void Start () {
        sm = new StateMachine();
        sm.ChangeState(new together(this, player1.GetComponent<jakePlayer>(), player2.GetComponent<jakePlayer>()));
    }
	
	// Update is called once per frame
	void Update () {
        sm.Update();
        if (Input.GetKeyDown(KeyCode.Space)) {
            sm.ChangeState(new together(this, player1.GetComponent<jakePlayer>(), player2.GetComponent<jakePlayer>()));
        } else if (Input.GetKeyDown(KeyCode.Space)) {
            sm.ChangeState(new apart(this, player1.GetComponent<jakePlayer>(), player2.GetComponent<jakePlayer>()));
        }
	}
}
