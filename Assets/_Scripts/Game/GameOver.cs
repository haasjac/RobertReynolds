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

    void OnCollisionEnter2D(Collision2D col) {
        gameObject.GetComponent<AudioSource>().enabled = true;
    }

    void OnCollisionExit2D(Collision2D col) {
        Transform temp = respawn.transform;
        //col.gameObject.transform = respawn.transform;
    }
}
