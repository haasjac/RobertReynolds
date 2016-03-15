using UnityEngine;
using System.Collections;
using UnityEngine.UI;



public class healthController : MonoBehaviour {

    public GameObject BothHealth;
    public GameObject OneHealth;
    public GameObject TwoHealth;

    public GameObject player1;
    public GameObject player2;

    public StateMachine sm;

	// Use this for initialization
	void Start () {
        sm = new StateMachine();
        sm.ChangeState(new together(this, player1.GetComponent<jakePlayer>(), player2.GetComponent<jakePlayer>()));
    }
	
	// Update is called once per frame
	void Update () {
        sm.Update();
        if (Input.GetKeyDown(KeyCode.Alpha1)) {
            sm.ChangeState(new together(this, player1.GetComponent<jakePlayer>(), player2.GetComponent<jakePlayer>()));
        } else if (Input.GetKeyDown(KeyCode.Alpha2)) {
            sm.ChangeState(new apart(this, player1.GetComponent<jakePlayer>(), player2.GetComponent<jakePlayer>()));
        }
	}
}
