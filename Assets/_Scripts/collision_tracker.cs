using UnityEngine;
using System.Collections;

public class collision_tracker : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter2D(Collision2D coll) {
        print(coll.gameObject.tag);
        print(coll.gameObject.name);
    }
}
