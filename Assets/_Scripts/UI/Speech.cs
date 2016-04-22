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
    [HideInInspector]
    public int rand;
    

    //PUBLIC
    public Sprite person_face;
    [TextArea(3, 10)]
    public List<string> messages;
    public GameObject button;

    //PRIVATE

    // Use this for initialization
    protected virtual void Start() {
        sm = new StateMachine();
        collided = false;
        if(button)
        {
            button.SetActive(false);
        }
        rand = Mathf.CeilToInt(UnityEngine.Random.Range(0.00001f, 6));
    }

    // Update is called once per frame
    protected virtual void Update() {
        sm.Update();
    }

    protected virtual void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Whole") || other.CompareTag("Top")) {
            collided = true;
            if (button)
            {
                button.SetActive(true);
            }
        }
    }

    protected virtual void OnTriggerExit2D(Collider2D other) {
        if (other.CompareTag("Whole") || other.CompareTag("Top")) {
            collided = false;
            if(button)
            {
                button.SetActive(false);
            }
        }
    }
}