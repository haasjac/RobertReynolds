using UnityEngine;
using System.Collections;

public class IAmTheOneWhoKnocks : MonoBehaviour {

    public GameObject cam;
    //public GameObject robot;

    public float timer = 2f;
    public float penalty = 0.3f;

    //public bool collided;
	// Use this for initialization
	void Start () {
        //collided = false;
	}
	
	// Update is called once per frame
	void Update () {

	}

    public IEnumerator restart(GameObject player) {
        //stop the camera and reload the level
        //cam.GetComponent<CameraFollow>().enabled = false;
        print("hello, ");
        yield return new WaitForSeconds(timer);
        print("world!");
        //Application.LoadLevel(Application.loadedLevel);
        //respawn player up 2 and left 5
        Vector3 pos = this.transform.position;
        pos.x -= 7f;
        pos.y += 7f;
        player.transform.position = pos;
        UI.S.ChangeSuspicion(-penalty);
    }

    public void OnCollisionEnter2D(Collision2D coll) {
        //no switch -- the only thing that should ever collide is the player
        //if (collided == false) {
        //    collided = true;
        //    print("collision");
        if(coll.gameObject.tag == "Whole" || coll.gameObject.tag == "Top" || coll.gameObject.tag == "Bottom")
            StartCoroutine("restart", coll.gameObject);
        //}
    }
}
