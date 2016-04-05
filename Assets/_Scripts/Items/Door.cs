using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {

    public GameObject button_icon;

	// Use this for initialization
	void Start () {
        button_icon.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionStay2D(Collision2D coll) {
        button_icon.SetActive(true);
        if(UI.S.together && (Input.GetButtonDown("X_1") || Input.GetButtonDown("X_2"))) {
            this.gameObject.SetActive(false);
        }
    }

    void OnCollisionExit2D(Collision2D coll) {
        button_icon.SetActive(false);
    }
}
