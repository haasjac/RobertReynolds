using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class NPC : Speech {

    [TextArea(3, 10)]
    public string great_option = "";
    [TextArea(3, 10)]
    public string good_option = "";
    [TextArea(3, 10)]
    public string bad_option = "";
    [TextArea(3, 10)]
    public string great_reaction = "";
    [TextArea(3, 10)]
    public string good_reaction = "";
    [TextArea(3, 10)]
    public string bad_reaction = "";
    [TextArea(3, 10)]
    public string invalid_reaction = "";
    public float great_amount = 0.3f;
    public float good_amount = 0.1f;
    public float bad_amount = -0.1f;
    public float invalid_amount = -0.3f;
    public UnityEvent uEvent;

    // Update is called once per frame
    protected override void Update () {
        if (UI.S.together && collided && (Input.GetButtonDown("X_1") || Input.GetButtonDown("X_2")) && !isBeingRead) {
            button.SetActive(false);
            isBeingRead = true;
            sm.ChangeState(new Dialogue_States.Play(this, new Dialogue_States.Choose(this)));
        }
        sm.Update();
    }
}
