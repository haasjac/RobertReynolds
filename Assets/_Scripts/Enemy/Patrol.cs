using UnityEngine;
using System.Collections;

public class Patrol : Enemy {

    public GameObject cam;
    public GameObject robot;
    public GameObject detected;
    public GameObject search;
    public GameObject icon;
    
    public bool searching;
    public bool freak_out;
    
    public float search_cooldown;

	// Use this for initialization
	void Start () {
        searching = false;
        freak_out = false;
        spawn = this.transform.position;
        GetComponent<Animator>().enabled = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (freak_out) {
            turn_cooldown = 0.0f;
            if (!turning)
                StartCoroutine("patrol");
            return;
        }


        //did you just see a robot?
        if(search_cooldown > 0.0f) {
            search_cooldown -= Time.deltaTime;
            return;
        }
        else if (search_cooldown <= 0.0f) {
            Destroy(icon.gameObject);
        }

        if (searching) {
            searching = false;
            search_cooldown = 3f;
            icon = spawn_icon(search);
            icon.transform.parent = this.transform;
        }
        else {
            //patrol();
            if (turning == false)
                StartCoroutine("patrol");
        }
    }
}
