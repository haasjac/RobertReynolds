using UnityEngine;
using System.Collections;

public enum playerState { TOGETEHER, APART };

public class playerController : MonoBehaviour {

    public static playerController S;

    public partController topController;
    public partController bottomController;
    public partController fullController;

    public playerState pState;

    public StateMachine sm;

    // Use this for initialization
    void Start () {
        S = this;

        sm = new StateMachine();
        sm.ChangeState(new Apart(this));
	}
	
	// Update is called once per frame
	void Update () {
        sm.Update();
        if (Input.GetButtonDown("RB_1") || Input.GetButtonDown("RB_2")) {
            change();
        }
    }

    public void change() {
        if (pState == playerState.TOGETEHER) {
            sm.ChangeState(new Apart(this));
        } else if (pState == playerState.APART) {
            sm.ChangeState(new Together(this));
        }
    }
}
