using UnityEngine;
using System.Collections;

public class Spotlight : MonoBehaviour {
    public SpriteRenderer sr;
    public BoxCollider2D coll;
    public float timeDelay = 2f;
    public float damage = .01f;
    AudioSource sound;
	// Use this for initialization
	void Start ()
    {
        sound = GetComponent<AudioSource>();
        sr = GetComponent<SpriteRenderer>();
        coll = GetComponent<BoxCollider2D>();
        sr = GetComponent<SpriteRenderer>();
        StartCoroutine(OnOff());
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    IEnumerator OnOff()
    {
        while(true)
        {
            if (!UI.S.stopped)
            {
                sound.PlayOneShot(Resources.Load("Sounds/Click") as AudioClip);
                coll.enabled = false;
                sr.enabled = false;
                yield return new WaitForSeconds(timeDelay);
                sound.PlayOneShot(Resources.Load("Sounds/Click") as AudioClip);
                coll.enabled = true;
                sr.enabled = true;
                yield return new WaitForSeconds(timeDelay);
            }
        }
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
