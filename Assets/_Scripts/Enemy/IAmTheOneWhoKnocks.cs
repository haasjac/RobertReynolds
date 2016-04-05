using UnityEngine;
using System.Collections;

public class IAmTheOneWhoKnocks : MonoBehaviour {

    public GameObject cam;
    public GameObject robot;

    public bool collided;
	// Use this for initialization
	void Start () {
        collided = false;
	}
	
	// Update is called once per frame
	void Update () {

	}

    public IEnumerator restart() {
        //stop the camera and reload the level
        cam.GetComponent<CameraFollow>().enabled = false;
        print("hello, ");
        yield return new WaitForSeconds(5f);
        print("world!");
        Application.LoadLevel(Application.loadedLevel);
    }

    public void OnCollisionEnter2D(Collision2D coll) {
        //no switch -- the only thing that should ever collide is the player
        if (collided == false) {
            collided = true;
            print("collision");
            StartCoroutine("restart");
        }
    }
}
