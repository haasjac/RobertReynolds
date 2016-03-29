using UnityEngine;
using System.Collections;

public class FallingTrap : MonoBehaviour {

    public GameObject robot;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Mathf.FloorToInt(robot.transform.position.x) == Mathf.FloorToInt(this.transform.position.x))
            this.GetComponent<FixedJoint2D>().enabled = false;
	}
}
