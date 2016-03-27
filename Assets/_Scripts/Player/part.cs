using UnityEngine;
using System.Collections;

public class part : MonoBehaviour {

    PartController pc;

	// Use this for initialization
	void Start () {
        pc = GetComponentInParent<PartController>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter2D(Collision2D coll) {
        switch (coll.gameObject.tag) {
            case "Ground":
                pc.grounded = true;
                break;
            case "Projectile":
                Destroy(coll.gameObject);
                pc.health -= coll.gameObject.GetComponent<Projectile>().damage;
                break;
        } 
    }
}
