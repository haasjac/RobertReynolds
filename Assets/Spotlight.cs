using UnityEngine;
using System.Collections;

public class Spotlight : MonoBehaviour {
    SpriteRenderer sr, ray_sr;
    BoxCollider2D coll;
    public GameObject ray;

	// Use this for initialization
	void Start ()
    {
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
            UI.S.PlaySound("Click");
            coll.enabled = false;
            ray_sr.enabled = false;
            yield return new WaitForSeconds(1f);
            UI.S.PlaySound("Click");
            coll.enabled = true;
            ray_sr.enabled = true;
            yield return new WaitForSeconds(1f);
        }
    }
    void OnTriggerEnter2D(Collider2D coll)
    {
        UI.S.PlaySound("Alarm");
    }
    void OnTriggerStay2D(Collider2D coll)
    {
        UI.S.ChangeSuspicion(-.01f);
    }
}
