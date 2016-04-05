using UnityEngine;
using System.Collections;

public class FemaleStar : MonoBehaviour {
    bool collided = false;
    Animator anim;
	// Use this for initialization
	void Start ()
    {
        anim = GetComponent<Animator>();
	}	
	// Update is called once per frame
	void Update ()
    {
        if(!collided)
        {
            transform.position += Vector3.right / 100f;
        }
    }
    void OnTriggerEnter2D(Collider2D coll)
    {
        collided = true;
        anim.SetBool("talking", true);
    }
}
