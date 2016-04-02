using UnityEngine;
using System.Collections;

public class NPC_No_Response : Speach {

    bool done = false;
	
	// Update is called once per frame
	protected override void Update () {
        if (UI.S.together && (Input.GetButtonDown("X_1") || Input.GetButtonDown("X_2")) && collided && !isBeingRead && !done) {
            button.SetActive(false);
            done = true;
            isBeingRead = true;
            sm.ChangeState(new Dialogue_States.Play(this));
        }
        sm.Update();
        if (done && sm.IsFinished() && GetComponent<NPC>() != null) {
            GetComponent<NPC>().enabled = true;
            this.enabled = false;
        }
    }
}
