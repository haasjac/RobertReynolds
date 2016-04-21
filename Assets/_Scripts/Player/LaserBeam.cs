using UnityEngine;
using System.Collections;

public class LaserBeam : MonoBehaviour {
    public float speed = 2f;
    Rigidbody2D rigid;
	// Use this for initialization
	void Start ()
    {
        rigid = GetComponent<Rigidbody2D>();
        if(transform.position.x < Top.S.transform.position.x)
        {
            speed *= -1f;
        }
        rigid.velocity = new Vector2(speed, 0f);
    }
	
	// Update is called once per frame
	void Update ()
    {
	
	}
    void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.collider.tag == "Target")
        {

        }
        else if(coll.collider.tag == "Mirror")
        {

        }
        else
        {
            Destroy(gameObject);
        }
    }
}
