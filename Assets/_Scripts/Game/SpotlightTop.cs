using UnityEngine;
using System.Collections;

public class SpotlightTop : MonoBehaviour {

    Transform ray;
    Spotlight rayScript;
	// Use this for initialization
	void Start () {
        ray = transform.FindChild("Spotlight Ray");
        rayScript = ray.GetComponent<Spotlight>();
        rayScript.going = false;
    }
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerEnter2D(Collider2D coll)
    {
        rayScript.going = true;
    }
    void OnTriggerExit2D(Collider2D coll)
    {
        rayScript.going = false;
    }
}
