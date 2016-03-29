using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// 
/// </summary>
public class Dialogue_States {

    /// VARIABLES

    public enum answers { GREAT, GOOD, BAD, INVALID };




    /// STATES


    /// <summary>
    /// Starts the dialogue.
    /// </summary>
    public class Play : State {
        Sign s;
        int current;
        int size;

        public Play(Sign s) {
            this.s = s;
        }

        public override void OnStart() {
            UI.S.stopped = true;
            s.isBeingRead = true;
            s.dialogue_go.gameObject.SetActive(true);
            size = s.messages.Count;
            current = -1;
            s.face.sprite = s.person_face;
        }

        public override void OnUpdate(float time_delta_fraction) {

            if (Input.GetButtonDown("X_1") || Input.GetButtonDown("X_2")) {
                current++;
                if (current < size) {
                    s.dialogue.text = s.messages[current];
                } else {
                    if (s.player_response) {
                        state_machine.ChangeState(new Choose(s));
                    } else {
                        ConcludeState();
                    }
                }
            }
        }

        public override void OnFinish() {
            if (!s.player_response) {
                s.dialogue_go.gameObject.SetActive(false);
                s.isBeingRead = false;
                UI.S.stopped = false;
            }
        }
    }




    /// <summary>
    /// Players chooses a response.
    /// </summary>
    public class Choose : State {
        Sign s;
        answers ans_1;
        answers ans_2;
        answers a;
        answers b;
        answers y;

        public Choose(Sign s) {
            this.s = s;
        }

        public override void OnStart() {
            int rand = Mathf.CeilToInt(UnityEngine.Random.Range(0.00001f, 6));
            switch (rand) {
                case 1:
                    s.dialogue.text = "A: " + s.great_option + "\nB: " + s.good_option + "\nY: " + s.bad_option;
                    a = answers.GREAT;
                    b = answers.GOOD;
                    y = answers.BAD;
                    break;
                case 2:
                    s.dialogue.text = "A: " + s.good_option + "\nB: " + s.great_option + "\nY: " + s.bad_option;
                    b = answers.GREAT;
                    a = answers.GOOD;
                    y = answers.BAD;
                    break;
                case 3:
                    s.dialogue.text = "A: " + s.great_option + "\nB: " + s.bad_option + "\nY: " + s.good_option;
                    a = answers.GREAT;
                    y = answers.GOOD;
                    b = answers.BAD;
                    break;
                case 4:
                    s.dialogue.text = "A: " + s.good_option + "\nB: " + s.bad_option + "\nY: " + s.great_option;
                    y = answers.GREAT;
                    a = answers.GOOD;
                    b = answers.BAD;
                    break;
                case 5:
                    s.dialogue.text = "A: " + s.bad_option + "\nB: " + s.good_option + "\nY: " + s.great_option;
                    y = answers.GREAT;
                    b = answers.GOOD;
                    a = answers.BAD;
                    break;
                case 6:
                    s.dialogue.text = "A: " + s.bad_option + "\nB: " + s.great_option + "\nY: " + s.good_option;
                    b = answers.GREAT;
                    y = answers.GOOD;
                    a = answers.BAD;
                    break;
            }
            s.face.sprite = s.question_mark;
            ans_1 = answers.INVALID;
            ans_2 = answers.INVALID;
        }

        public override void OnUpdate(float time_delta_fraction) {
            //player1
            if (Input.GetButtonDown("A_1")) {
                ans_1 = a;
            }
            if (Input.GetButtonDown("B_1")) {
                ans_1 = b;
            }
            if (Input.GetButtonDown("Y_1")) {
                ans_1 = y;
            }
            //player2
            if (Input.GetButtonDown("A_2")) {
                ans_2 = a;
            }
            if (Input.GetButtonDown("B_2")) {
                ans_2 = b;
            }
            if (Input.GetButtonDown("Y_2")) {
                ans_2 = y;
            }
            //both
            if (ans_1 != answers.INVALID && ans_2 != answers.INVALID) {
                state_machine.ChangeState(new Respond(s, ans_1, ans_2));
            }
        }

        public override void OnFinish() {
        }
    }




    /// <summary>
    /// Player states response.
    /// </summary>
    public class Respond : State {
        Sign s;
        answers ans;
        answers ans_1;
        answers ans_2;

        public Respond(Sign s, answers ans_1, answers ans_2) {
            this.s = s;
            this.ans_1 = ans_1;
            this.ans_2 = ans_2;
        }

        public override void OnStart() {
            s.face.sprite = s.player_face;
            ans = answers.INVALID;
            if (ans_1 == ans_2) {
                ans = ans_1;
                switch (ans) {
                    case answers.GREAT:
                        s.dialogue.text = s.great_option;
                        break;
                    case answers.GOOD:
                        s.dialogue.text = s.good_option;
                        break;
                    case answers.BAD:
                        s.dialogue.text = s.bad_option;
                        break;
                    case answers.INVALID:
                        MonoBehaviour.print("how did this happen?");
                        s.dialogue.text = "players didn't agree, why am i here?";
                        break;
                }
            } else if (ans_1 != answers.GREAT && ans_2 != answers.GREAT) {
                s.dialogue.text = combine(s.good_option, s.bad_option);
            } else if (ans_1 != answers.GOOD && ans_2 != answers.GOOD) {
                s.dialogue.text = combine(s.great_option, s.bad_option);
            } else {
                s.dialogue.text = combine(s.great_option, s.good_option);
            }
        }

        public override void OnUpdate(float time_delta_fraction) {

            if (Input.GetButtonDown("X_1") || Input.GetButtonDown("X_2")) {
                state_machine.ChangeState(new React(s, ans));
            }
        }

        public override void OnFinish() {
        }

    }




    /// <summary>
    /// Person reacts to players response.
    /// </summary>
    public class React : State {
        Sign s;
        answers ans;

        public React(Sign s, answers ans) {
            this.s = s;
            this.ans = ans;
        }

        public override void OnStart() {
            s.face.sprite = s.person_face;
            switch (ans) {
                case answers.GREAT:
                    s.dialogue.text = s.great_reaction;
                    UI.S.ChangeSuspicion(s.great_amount);
                    break;
                case answers.GOOD:
                    s.dialogue.text = s.good_reaction;
                    UI.S.ChangeSuspicion(s.good_amount);
                    break;
                case answers.BAD:
                    s.dialogue.text = s.bad_reaction;
                    UI.S.ChangeSuspicion(s.bad_amount);
                    break;
                case answers.INVALID:
                    s.dialogue.text = s.invalid_reaction;
                    UI.S.ChangeSuspicion(s.invalid_amount);
                    break;
            }
        }

        public override void OnUpdate(float time_delta_fraction) {

            if (Input.GetButtonDown("X_1") || Input.GetButtonDown("X_2")) {
                ConcludeState();
            }
        }

        public override void OnFinish() {
            s.dialogue_go.gameObject.SetActive(false);
            s.isBeingRead = false;
            UI.S.stopped = false;
        }
    }

    


    /// FUNCTIONS
    
    
    
    /// <summary>
    /// Takes two strings and randomly selects letters from each to form a new string.
    /// </summary>
    static string combine(string a, string b) {
        string r = "";
        int size = Mathf.Max(a.Length, b.Length);
        for (int i = 0; i < size; i++) {
            if (Mathf.RoundToInt(UnityEngine.Random.value) > 0) {
                if (a.Length > i) {
                    r += a[i];
                } else {
                    r += " ";
                }
            } else {
                if (b.Length > i) {
                    r += b[i];
                } else {
                    r += " ";
                }
            }
        }
        return r;
    }
}