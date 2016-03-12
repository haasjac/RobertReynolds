using UnityEngine;
using System.Collections;

public class jakePlayer : MonoBehaviour {

    public float health;

	// Use this for initialization
	void Start () {
        health = 1;
	}
	
	void OnMouseDown() {
        health -= 0.1f;
    }
}
