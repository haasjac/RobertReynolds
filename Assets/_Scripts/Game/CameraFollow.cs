using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {
    Vector3 pos;

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        pos = transform.position;
	    if (UI.S.together)
        {
            pos.x = Whole.S.transform.position.x;
            pos.y = Whole.S.transform.position.y + 2;
        } else
        {
            pos.x = (Top.S.container.transform.position.x + Bottom.S.container.transform.position.x) / 2;
            pos.y = (Top.S.container.transform.position.y + Bottom.S.container.transform.position.y) / 2 + 2;
        }
        transform.position = pos;
	}
}
