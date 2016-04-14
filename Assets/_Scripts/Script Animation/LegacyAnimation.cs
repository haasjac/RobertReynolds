using UnityEngine;
using System.Collections;

public class LegacyAnimation : MonoBehaviour {
    Animation anim;
	// Use this for initialization
	void Start () {
        anim = GetComponent<Animation>();
    }
	
	// Update is called once per frame
	void Update () {
        if(!anim.isPlaying)
        {
            anim.Play();
        }
    }
}
