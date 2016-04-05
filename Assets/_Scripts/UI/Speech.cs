using System;
using UnityEngine;
//using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Speech : MonoBehaviour {

    //HIDE IN INSPECTOR
    public StateMachine sm;
    [HideInInspector]
    public bool isBeingRead = false;
    [HideInInspector]
    public bool collided;
    

    //PUBLIC
    public Sprite person_face;
    public List<string> messages;
    public GameObject button;

    //PRIVATE

    // Use this for initialization
    protected virtual void Start() {
        sm = new StateMachine();
        collided = false;
        button.SetActive(false);
    }

    // Update is called once per frame
    protected virtual void Update() {
        sm.Update();
    }

    protected virtual void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Whole")) {
            collided = true;
            button.SetActive(true);
        }
    }

    protected virtual void OnTriggerExit2D(Collider2D other) {
        if (other.CompareTag("Whole")) {
            collided = false;
            button.SetActive(false);
        }
    }
}