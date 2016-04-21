using UnityEngine;
using System.Collections;

public class CarryObject : MonoBehaviour {

    public float height = 1f;

    GameObject button;
    GameObject player;
    bool trigger;

	// Use this for initialization
	void Start () {
        player = null;
        trigger = false;
        button = this.transform.FindChild("button_float").gameObject;
        button.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        if (trigger) {
            button.SetActive(true);
            if (Input.GetButtonDown("X_1") || Input.GetButtonDown("X_2")) {
                if (this.transform.parent == null) {
                    //carry the this object at player.pos.y + "height"
                    Vector3 pos = this.transform.position;
                    pos.y += height;
                    this.transform.position = pos;

                    //make this a child of whoever picked it up
                    this.transform.parent = player.transform;
                    this.GetComponent<Rigidbody2D>().isKinematic = true;
                }
                else {
                    //drop the object
                    this.transform.parent = null;
                    this.GetComponent<Rigidbody2D>().isKinematic = false;
                }
            }
        }
	}

    void OnTriggerStay2D(Collider2D coll) {
        if(coll.gameObject.layer == LayerMask.NameToLayer("Player")) {
            trigger = true;
            player = coll.gameObject;
            //button.SetActive(true);
            //if(Input.GetButtonDown("X_1") || Input.GetButtonDown("X_2")) {
            //    if (this.transform.parent == null) {
            //        //carry the this object at player.pos.y + "height"
            //        Vector3 pos = this.transform.position;
            //        pos.y += height;
            //        this.transform.position = pos;

            //        //make this a child of whoever picked it up
            //        this.transform.parent = coll.gameObject.transform;
            //        this.GetComponent<Rigidbody2D>().isKinematic = true;
            //    }
            //    else {
            //        //drop the object
            //        this.transform.parent = null;
            //        this.GetComponent<Rigidbody2D>().isKinematic = false;
            //    }
            //}
        }
    }

    void OnTriggerExit2D(Collider2D coll) {
        trigger = false;
        player = null;
        button.SetActive(false);
    }
}
