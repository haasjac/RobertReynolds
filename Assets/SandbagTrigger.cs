using UnityEngine;
using System.Collections;

public class SandbagTrigger : MonoBehaviour {

    GameObject button;
    bool trigger;

	// Use this for initialization
	void Start () {
        trigger = false;
        button = this.transform.parent.gameObject.transform.FindChild("button_float").gameObject;
        //button = this.transform.FindChild("button_float").gameObject;
        if (button == null) {
            print("boop");
            return;
        }
        button.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        if (trigger) {
            button.SetActive(true);
            if (Input.GetButtonDown("X_1") || Input.GetButtonDown("X_2")) {
                //drop the sandbag
                this.GetComponent<FixedJoint2D>().enabled = false;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D coll) {
        if (coll.gameObject.layer == LayerMask.NameToLayer("Player")) {
            trigger = true;
            //button.SetActive(true);
            //print("blah");
            //if (Input.GetButtonDown("X_1") || Input.GetButtonDown("X_2")) {
            //    print("sup");
            //    //drop the sandbag
            //    this.GetComponent<FixedJoint2D>().enabled = false;
            //}
        }
    }

    void OnTriggerExit2D(Collider2D coll) {
        trigger = false;
        button.SetActive(false);
    }

    void OnCollisionEnter2D(Collision2D coll) {
        if (coll.gameObject.layer == LayerMask.NameToLayer("Anti_Collision")) {
            //play fallover animation
            coll.gameObject.GetComponent<Animation>().Play();
        }
    }
}
