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
	void Awake () {
        sm = new StateMachine();
    }
	
	// Update is called once per frame
	void Update () {
        sm.Update();
	}
}
