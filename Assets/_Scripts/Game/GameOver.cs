using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour {
    public GameObject respawn;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter(Collider2D col) {
        gameObject.GetComponent<AudioSource>().enabled = true;
    }

    void OnCollisionExit(Collider2D col) {
        Transform temp = respawn.transform;
        //col.gameObject.transform = respawn.transform;
    }
}
