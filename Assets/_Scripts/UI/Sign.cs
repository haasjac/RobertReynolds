using System;
using UnityEngine;
//using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Sign : MonoBehaviour {

    //HIDE IN INSPECTOR
    public StateMachine sign_state_machine;
    [HideInInspector]
    public bool isBeingRead = false;
    [HideInInspector]
    public bool collided;

    //PUBLIC
    public Image dialogue_go;
    public Sprite player_face;
    public Sprite person_face;
    public Sprite question_mark;
    public List<string> messages;
    public bool player_response = false;
    public string great_option = "";
    public string good_option = "";
    public string bad_option = "";
    public string great_reaction = "";
    public string good_reaction = "";
    public string bad_reaction = "";
    public string invalid_reaction = "";
    public float great_amount = 0.3f;
    public float good_amount = 0.1f;
    public float bad_amount = -0.1f;
    public float invalid_amount = -0.3f;

    //PRIVATE
    [HideInInspector]
    public Text dialogue;
    [HideInInspector]
    public Image face;

    // Use this for initialization
    void Start() {
        dialogue = dialogue_go.GetComponentInChildren<Text>();
        face = dialogue_go.GetComponentsInChildren<Image>()[1];

        sign_state_machine = new StateMachine();
        collided = false;
        dialogue_go.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update() {
        if (UI.S.together && collided && (Input.GetButtonDown("X_1") || Input.GetButtonDown("X_2")) && !isBeingRead) {
            isBeingRead = true;
            sign_state_machine.ChangeState(new Dialogue_States.Play(this));
        }
        sign_state_machine.Update();
    }

    void FixedUpdate() {
        
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Whole")) {
            collided = true;
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        if (other.CompareTag("Whole")) {
            collided = false;
        }
    }
}