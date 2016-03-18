using UnityEngine;
using System.Collections;

public class Pickup : MonoBehaviour {
    public bool health = false;
    public float speed = 2f;
    Rigidbody2D rigid;
	// Use this for initialization
	void Start () {
        rigid = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.position += (Vector3.up + new Vector3(0, Mathf.Cos(Time.timeSinceLevelLoad)) * speed) * Time.deltaTime * 60;
    }
    void OnTriggerEnter2D(Collider coll)
    {
        if(coll.tag == "Whole" || coll.tag == "Top" || coll.tag == "Bottom")
        {
            if(health)
            {
                //TODO: Play Health Sound
                //IncHealth
            }
            else
            {
                //TODO: Play Pickup Sound
                //IncPickup
            }
            Destroy(gameObject);
        }
    }
}
