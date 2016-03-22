﻿using System;
using UnityEngine;
//using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Sign : MonoBehaviour {

    //HIDE IN INSPECTOR
    public StateMachine sign_state_machine;

    //PUBLIC
    public List<string> messages;
    public List<Sprite> faces;
    public Text dialogue_go;
    public Image background_go;
    public Image face_go;
    public bool isBeingRead = false;
    [HideInInspector] public bool collided;
    public bool needs_input = false;

    //PRIVATE
    //private bool read = false;
    // Use this for initialization
    void Start() {
        sign_state_machine = new StateMachine();
        collided = false;
        background_go.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update() {
        if (collided && (Input.GetButtonDown("X_1") || Input.GetButtonDown("X_2") || !needs_input) && !isBeingRead) {
            isBeingRead = true;
            sign_state_machine.ChangeState(new State_Dialogue_Play(this));
        }
        sign_state_machine.Update();
    }

    void FixedUpdate() {
        
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.transform.parent.CompareTag("Player")) {
            collided = true;
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        if (other.transform.parent.CompareTag("Player")) {
            collided = false;
        }
    }
}