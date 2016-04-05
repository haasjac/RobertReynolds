using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {

    public GameObject clothing;

    public float timer = 2f;
    float count = 0.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerStay2D(Collider2D coll) {
        Vector3 pos = coll.gameObject.transform.position;
        if (count >= timer)
        {
            //move the player to the other room
            pos.x -= 7.5f;
            coll.gameObject.transform.position = pos;
        }
        else {
            if (clothing != null)
                return;
            count += Time.deltaTime;
        }
    }
}
