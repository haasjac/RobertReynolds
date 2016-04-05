using UnityEngine;
using System.Collections;

public class DisableObject : MonoBehaviour {

    public int num_press;

	// Use this for initialization
	void Start () {
        num_press = 0;
	}
	
	// Update is called once per frame
	void Update () {
        if (num_press >= 1) {
            this.GetComponent<CircleCollider2D>().enabled = false;
            this.GetComponent<Animator>().enabled = false;
        }
	}

    public void OnPress() {
        num_press++;
    }
}
