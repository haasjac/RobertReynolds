﻿using UnityEngine;
using System.Collections;

public class Navi : Speech {

    bool done = false;
	
	// Update is called once per frame
	protected override void Update () {
        if (collided && !isBeingRead && !done)
        {
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
