using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour {
    public GameObject respawn_location;
	
	// Update is called once per frame
	void Update () {
	    if(UI.S.currentSuspicion == UI.S.maxSuspicion) {
            GameOverScreen();
        }
	}

    void OnCollisionEnter2D(Collision2D col) {
        //Enviomental hazard, crowd booing
        gameObject.GetComponent<AudioSource>().enabled = true;
    }

    void OnCollisionExit2D(Collision2D col) {
        //Respawn @ checkpoint
        //Transform temp = respawn.transform;
        //col.gameObject.transform = respawn.transform;
    }

    void GameOverScreen() {
        //Ending screen?
        //Spawn Robot mentor?
    }
}
