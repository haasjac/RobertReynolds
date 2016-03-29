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
        //StartCoroutine("suspicious");
        //StartCoroutine_Auto(suspicious);
        //icon.transform.parent = this.transform;
    }
	
	// Update is called once per frame
	void Update () {
        if (freak_out) {
            //destroy vision cone and raise the roof!!!
            //Destroy(this.transform.FindChild("vision_cone").gameObject);
            //movement_speed *= 3;
            patrol();
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
            patrol();
        }
    }


    //public IEnumerator suspicious() {
    //    for (;;) {
    //        if (searching)
    //        {
    //            searching = false;
    //            yield return new WaitForSeconds(3f);
    //        }
    //        else
    //        {
    //            patrol();
    //            yield return new WaitForEndOfFrame();
    //        }
    //    }
    //}
}
