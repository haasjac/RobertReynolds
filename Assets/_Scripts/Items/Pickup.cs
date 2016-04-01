using UnityEngine;
using System.Collections;

public class Pickup : MonoBehaviour {
    public float speed = .001f;
    public float healthAmount = 1f;
	// Update is called once per frame
	void Update ()
    {
        transform.Rotate(0f, 0f, 2f);
        transform.position -= (new Vector3(0, Mathf.Cos(2 * Mathf.PI * Time.timeSinceLevelLoad) * speed, 0f));
    }
    void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.tag == "Whole" ||  coll.tag == "Top" || coll.tag == "Bottom")
        {
            //TODO: Play Pickup Sound
            //IncPickup
            UI.S.Collect(gameObject);
            Destroy(gameObject);
        }
    }
}
