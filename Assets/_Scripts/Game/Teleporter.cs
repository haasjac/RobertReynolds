using UnityEngine;
using System.Collections;

public class Teleporter : MonoBehaviour {
    public GameObject teleporter;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}
    void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.collider.tag == "Bottom")
        {
            UI.S.PlaySound("Teleporter");
            Bottom.S.container.transform.position = teleporter.transform.position;
            print("Here");
        }
    }
}
