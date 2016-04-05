using UnityEngine;
using System.Collections;

public class Spotlight : MonoBehaviour {
    public SpriteRenderer sr;
    public BoxCollider2D coll;
    public float timeDelay = 2f;
    public float damage = .01f;
    public bool going = false, running = false;
    AudioSource sound;
	// Use this for initialization
	void Start ()
    {
        sound = GetComponent<AudioSource>();
        sr = GetComponent<SpriteRenderer>();
        coll = GetComponent<BoxCollider2D>();
        sr = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
        if(going && !running)
        {
            StartCoroutine(OnOff());
        }
    }
    IEnumerator OnOff()
    {
            if (!UI.S.stopped && going)
            {
                running = true;
                sound.PlayOneShot(Resources.Load("Sounds/Click") as AudioClip);
                coll.enabled = true;
                sr.enabled = true;
                yield return new WaitForSeconds(timeDelay);
                sound.PlayOneShot(Resources.Load("Sounds/Click") as AudioClip);
                coll.enabled = false;
                sr.enabled = false;
                yield return new WaitForSeconds(timeDelay);
            }
        running = false;
    }
    void OnTriggerEnter2D(Collider2D coll)
    {
        sound.PlayOneShot(Resources.Load("Sounds/Alarm") as AudioClip);
    }
    void OnTriggerStay2D(Collider2D coll)
    {
        UI.S.ChangeSuspicion(-damage);
        if(coll.tag == "Whole")
        {
            StartCoroutine(Top.S.Flash());
            StartCoroutine(Bottom.S.Flash());
        }
        else if (coll.tag == "Top")
        {
            StartCoroutine(Top.S.Flash());
        }
        else if (coll.tag == "Bottom")
        {
            StartCoroutine(Bottom.S.Flash());
        }
    }
}
