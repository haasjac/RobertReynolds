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
        Speach s;
        State next;
        int current;
        int size;

        public Play(Speach s, State next = null) {
            this.s = s;
            this.next = next;
        }

        public override void OnStart() {
            Time.timeScale = 0;
            UI.S.stopped = true;
            s.isBeingRead = true;
            Dialogue.S.gameObject.SetActive(true);
            size = s.messages.Count;
            if (size < 1) {
                if (next != null) {
                    state_machine.ChangeState(next);
                } else {
                    ConcludeState();
                }
            }
                if (Input.GetButtonDown("X_1") || Input.GetButtonDown("X_2")) {
                current = -1;
            } else {
                current = 0;
                Dialogue.S.text.text = s.messages[current];
            }
            Dialogue.S.face.sprite = s.person_face;
        }

        public override void OnUpdate(float time_delta_fraction) {

            if (Input.GetButtonDown("X_1") || Input.GetButtonDown("X_2")) {
                current++;
                if (current < size) {
                    Dialogue.S.text.text = s.messages[current];
                } else {
                    if (next != null) {
                        state_machine.ChangeState(next);
                    } else {
                        ConcludeState();
                    }
                }
            }
        }

        public override void OnFinish() {
            if (next == null) {
                Dialogue.S.gameObject.SetActive(false);
                s.isBeingRead = false;
                UI.S.stopped = false;
                Time.timeScale = 1;
            }
        }
    }




    /// <summary>
    /// Players chooses a response.
    /// </summary>
    public class Choose : State {
        NPC s;
        answers ans_1;
        answers ans_2;
        answers a;
        answers b;
        answers y;

        public Choose(NPC s) {
            this.s = s;
        }

        public override void OnStart() {
            int rand = Mathf.CeilToInt(UnityEngine.Random.Range(0.00001f, 6));
            Dialogue.S.buttons.SetActive(true);
            Dialogue.S.textTop.SetActive(true);
            Dialogue.S.textBottom.SetActive(true);
            switch (rand) {
                case 1:
                    Dialogue.S.text.text = s.great_option + "\n" + s.good_option + "\n" + s.bad_option;
                    a = answers.GREAT;
                    b = answers.GOOD;
                    y = answers.BAD;
                    break;
                case 2:
                    Dialogue.S.text.text = s.good_option + "\n" + s.great_option + "\n" + s.bad_option;
                    b = answers.GREAT;
                    a = answers.GOOD;
                    y = answers.BAD;
                    break;
                case 3:
                    Dialogue.S.text.text = s.great_option + "\n" + s.bad_option + "\n" + s.good_option;
                    a = answers.GREAT;
                    y = answers.GOOD;
                    b = answers.BAD;
                    break;
                case 4:
                    Dialogue.S.text.text = s.good_option + "\n" + s.bad_option + "\n" + s.great_option;
                    y = answers.GREAT;
                    a = answers.GOOD;
                    b = answers.BAD;
                    break;
                case 5:
                    Dialogue.S.text.text = s.bad_option + "\n" + s.good_option + "\n" + s.great_option;
                    y = answers.GREAT;
                    b = answers.GOOD;
                    a = answers.BAD;
                    break;
                case 6:
                    Dialogue.S.text.text = s.bad_option + "\n" + s.great_option + "\n" + s.good_option;
                    b = answers.GREAT;
                    y = answers.GOOD;
                    a = answers.BAD;
                    break;
            }
            Dialogue.S.face.sprite = Dialogue.S.question_mark;
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

            //color
            Dialogue.S.textTop.GetComponent<Text>().color = 
                    (ans_1 == answers.INVALID ? Dialogue.S.not_answered : Dialogue.S.answered );
            Dialogue.S.textBottom.GetComponent<Text>().color =
                    (ans_2 == answers.INVALID ? Dialogue.S.not_answered : Dialogue.S.answered);
        }

        public override void OnFinish() {
            Dialogue.S.buttons.SetActive(false);
            Dialogue.S.textTop.SetActive(false);
            Dialogue.S.textBottom.SetActive(false);
        }
    }




    /// <summary>
    /// Player states response.
    /// </summary>
    public class Respond : State {
        NPC s;
        answers ans;
        answers ans_1;
        answers ans_2;

        public Respond(NPC s, answers ans_1, answers ans_2) {
            this.s = s;
            this.ans_1 = ans_1;
            this.ans_2 = ans_2;
        }

        public override void OnStart() {
            Dialogue.S.face.sprite = Dialogue.S.player_face;
            ans = answers.INVALID;
            if (ans_1 == ans_2) {
                ans = ans_1;
                switch (ans) {
                    case answers.GREAT:
                        Dialogue.S.text.text = s.great_option;
                        break;
                    case answers.GOOD:
                        Dialogue.S.text.text = s.good_option;
                        break;
                    case answers.BAD:
                        Dialogue.S.text.text = s.bad_option;
                        break;
                    case answers.INVALID:
                        MonoBehaviour.print("how did this happen?");
                        Dialogue.S.text.text = "players didn't agree, why am i here?";
                        break;
                }
            } else if (ans_1 != answers.GREAT && ans_2 != answers.GREAT) {
                Dialogue.S.text.text = combine(s.good_option, s.bad_option);
            } else if (ans_1 != answers.GOOD && ans_2 != answers.GOOD) {
                Dialogue.S.text.text = combine(s.great_option, s.bad_option);
            } else {
                Dialogue.S.text.text = combine(s.great_option, s.good_option);
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
        NPC s;
        answers ans;

        public React(NPC s, answers ans) {
            this.s = s;
            this.ans = ans;
        }

        public override void OnStart() {
            Dialogue.S.face.sprite = s.person_face;
            switch (ans) {
                case answers.GREAT:
                    Dialogue.S.text.text = s.great_reaction;
                    UI.S.ChangeSuspicion(s.great_amount);
                    if (s.uEvent != null) {
                        s.uEvent.Invoke();
                    }
                    break;
                case answers.GOOD:
                    Dialogue.S.text.text = s.good_reaction;
                    UI.S.ChangeSuspicion(s.good_amount);
                    break;
                case answers.BAD:
                    Dialogue.S.text.text = s.bad_reaction;
                    UI.S.ChangeSuspicion(s.bad_amount);
                    break;
                case answers.INVALID:
                    Dialogue.S.text.text = s.invalid_reaction;
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
            Dialogue.S.gameObject.SetActive(false);
            s.isBeingRead = false;
            UI.S.stopped = false;
            Time.timeScale = 1;
        }
    }


    /// <summary>
    /// Guard Dialogue
    /// </summary>
    public class GuardText : State {
        Guard s;
        bool wait;

        public GuardText(Guard s) {
            this.s = s;
        }

        public override void OnStart() {
            if (UI.S.has_costume[0]) {
                Dialogue.S.text.text = s.pass_statement;
            } else {
                Dialogue.S.text.text = s.fail_statement + "\n";
                if (!UI.S.has_costume[1])
                    Dialogue.S.text.text += UI.S.costume1_go.name + "\t";
                if (!UI.S.has_costume[2])
                    Dialogue.S.text.text += UI.S.costume2_go.name + "\t";
                if (!UI.S.has_costume[3])
                    Dialogue.S.text.text += UI.S.costume3_go.name + "\t";
            }
            Dialogue.S.face.sprite = s.person_face;
            wait = false;
        }

        public override void OnUpdate(float time_delta_fraction) {

            if (wait && Input.GetButtonDown("X_1") || Input.GetButtonDown("X_2")) {
                if (UI.S.has_costume[0]) {
                    s.uEvent.Invoke();
                    s.enabled = false;
                }
                ConcludeState();
            }
            wait = true;
        }

        public override void OnFinish() {
                Dialogue.S.gameObject.SetActive(false);
                s.isBeingRead = false;
                UI.S.stopped = false;
                Time.timeScale = 1;
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