using UnityEngine;
using System.Collections;

public class scifi : MonoBehaviour {

    public GameObject platform;
    public FemaleStar female;

	// Use this for initialization
	void Start () {
        platform.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void platform_enable() {
        platform.SetActive(true);
    }

    void OnTriggerEnter2D(Collider2D coll) {
        if (coll.tag == "Whole") {
            coll.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            female.startWalk();
        }
    }
}
