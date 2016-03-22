using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class State_Dialogue_Play : State {
    Sign s;
    int current;
    int size;

    public State_Dialogue_Play(Sign s) {
        this.s = s;
    }

    public override void OnStart() {
        s.isBeingRead = true;
        s.background_go.gameObject.SetActive(true);
        size = s.messages.Count;
        current = 0;
        s.dialogue_go.text = s.messages[current];
    }

    public override void OnUpdate(float time_delta_fraction) {
        
        /*if (Input.GetButtonDown("X_1") || Input.GetButtonDown("X_2")) {
            current++;
            if (current < size) {
                s.dialogue_go.text = s.messages[current];
                s.face_go.sprite = s.faces[current];
            }
            else {
                ConcludeState();
            }
        }*/
        if (!s.collided) {
            ConcludeState();
        }
    }

    public override void OnFinish() {
        s.background_go.gameObject.SetActive(false);
        s.isBeingRead = false;
    }
}