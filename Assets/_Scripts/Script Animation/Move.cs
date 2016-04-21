using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour {
    public float xMove, yMove, speed;
    public Vector3 dest;
    public bool start = false, delete = false;
	// Use this for initialization
	void Start () {
        dest = new Vector3(transform.position.x + xMove, transform.position.y + yMove, transform.position.z);
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        if(start)
        {
            transform.position = new Vector3(Mathf.Lerp(transform.position.x, dest.x, speed * Time.fixedDeltaTime), Mathf.Lerp(transform.position.y, dest.y, speed * Time.fixedDeltaTime), dest.z);
        }	
        if(delete && transform.position == dest)
        {
            Destroy(gameObject);
        }
        else if(transform.position == dest)
        {
            Destroy(this);
        }
	}
    public void startMove()
    {
        start = true;
    }
}
