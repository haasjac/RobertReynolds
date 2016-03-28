using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum playerState { TOGETEHER, APART };

public class playerController : MonoBehaviour {

    public static playerController S;

    public partController topController;
    public partController bottomController;
    public partController fullController;

    //public healthController hc;

    public playerState pState;

    public StateMachine sm;

    public float swtich_dis = 0.05f;

    public List<bool> stars;

    public float max_stealth = 1;
    public float stealth;

    float dis;

    // Use this for initialization
    void Start () {
        S = this;

        sm = new StateMachine();

        sm.ChangeState(new Together(this));
        //hc.sm.ChangeState(new together(hc));


        stars = new List<bool>(4);
        stars.Add(false);
        stars.Add(false);
        stars.Add(false);
        stars.Add(false);
        stealth = 0.5f * max_stealth;
    }
	
	// Update is called once per frame
	void Update () {
        sm.Update();
        dis = Vector3.Distance(topController.part.transform.position, bottomController.part.transform.position);
        if (dis < swtich_dis && (Input.GetButtonDown("RB_1") || Input.GetButtonDown("RB_2"))) {
            change();
        }
        if (Input.GetKeyDown(KeyCode.Alpha1)) {
            stealth -= 0.1f;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2)) {
            stealth += 0.1f;
        }
        
        if (stealth < 0) {
            stealth = 0;
        }
        if (stealth > max_stealth) {
            stealth = max_stealth;
        }
    }

    public void change() {
        if (pState == playerState.TOGETEHER) {
            sm.ChangeState(new Apart(this));
            //hc.sm.ChangeState(new apart(hc));
        } else if (pState == playerState.APART) {
            sm.ChangeState(new Together(this));
            //hc.sm.ChangeState(new together(hc));
        }
    }

    public void dead() {
        //gameObject.SetActive(false);
    }
}
