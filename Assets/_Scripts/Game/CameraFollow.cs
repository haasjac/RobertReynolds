using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

    public GameObject full;
    public GameObject top;
    public GameObject bottom;

    public playerController pc;

    Vector3 pos;

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        pos = transform.position;
	    if (pc.pState == playerState.TOGETEHER) {
            pos.x = full.transform.position.x;
        } else if (pc.pState == playerState.APART) {
            pos.x = (top.transform.position.x + bottom.transform.position.x) / 2;
        }
        transform.position = pos;
	}
}
