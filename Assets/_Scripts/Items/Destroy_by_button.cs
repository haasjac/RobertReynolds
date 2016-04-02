using UnityEngine;
using System.Collections;

public class Destroy_by_button : MonoBehaviour {

    public int buttons_needed = 2;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if (buttons_needed <= 0) {
            gameObject.SetActive(false);
        }
	}

    public void onPress() {
        buttons_needed--;
    }
}
