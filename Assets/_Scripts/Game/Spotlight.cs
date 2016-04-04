using UnityEngine;
using System.Collections;

public class Spotlight : MonoBehaviour {
    public SpriteRenderer sr, ray_sr;
    public BoxCollider2D coll;
    public GameObject ray;
    public float timeDelay = 2f;
    public float damage = .01f;
    AudioSource sound;
	// Use this for initialization
	void Start ()
    {
        sound = GetComponent<AudioSource>();
        sr = GetComponent<SpriteRenderer>();
        coll = ray.GetComponent<BoxCollider2D>();
        ray_sr = ray.GetComponent<SpriteRenderer>();
        StartCoroutine(OnOff());
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    IEnumerator OnOff()
    {
        while(true)
        {
            sound.PlayOneShot(Resources.Load("Sounds/Click") as AudioClip);
            coll.enabled = false;
            ray_sr.enabled = false;
            yield return new WaitForSeconds(timeDelay);
            sound.PlayOneShot(Resources.Load("Sounds/Click") as AudioClip);
            coll.enabled = true;
            ray_sr.enabled = true;
            yield return new WaitForSeconds(timeDelay);
        }
    }
    void OnTriggerEnter2D(Collider2D coll)
    {
        sound.PlayOneShot(Resources.Load("Sounds/Alarm") as AudioClip);
    }
    void OnTriggerStay2D(Collider2D coll)
    {
        print("Hit");
        UI.S.ChangeSuspicion(-damage);
    }
}
