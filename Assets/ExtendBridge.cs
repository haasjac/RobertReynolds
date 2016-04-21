using UnityEngine;
using System.Collections;

public class ExtendBridge : MonoBehaviour {

    public float distance;
    public int buttons_needed = 1;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (distance <= 0.0f)
            return;
	    if(buttons_needed <= 0) {
            float slide = Time.deltaTime * 5;
            if (slide > distance)
                slide = distance;
            Vector3 pos = this.transform.position;
            pos.x -= slide;
            distance -= slide;
            this.transform.position = pos;
        }
	}

    public void OnPress() {
        buttons_needed--;
    }
}
