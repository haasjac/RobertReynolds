using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class Guard : Speach {

    public string fail_statement = "I can't let you pass without:";
    public string pass_statement = "Right this way sir.";
    public UnityEvent uEvent;

    // Update is called once per frame
    protected override void Update () {
        if (UI.S.together && (Input.GetButtonDown("X_1") || Input.GetButtonDown("X_2")) && collided && !isBeingRead) {
            button.SetActive(false);
            isBeingRead = true;
            sm.ChangeState(new Dialogue_States.Play(this, new Dialogue_States.GuardText(this)));
        }
        sm.Update();
    }
}
