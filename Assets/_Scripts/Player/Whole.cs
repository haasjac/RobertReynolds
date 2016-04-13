using UnityEngine;
using System.Collections;

public class Whole : MonoBehaviour {
    public static Whole S;
    public Rigidbody2D rigid;
    BoxCollider2D col;
    Vector2 orig;
    void Awake()
    {
        S = this;
        rigid = GetComponent<Rigidbody2D>();
    }
	// Use this for initialization
	void Start () {
        col = GetComponent<BoxCollider2D>();
        orig = col.size;
	}
	
	// Update is called once per frame
	void Update () {
	    if(Top.S.attacking)
        {
            col.size = new Vector2(orig.x * 2, orig.y);
        }
        else
        {
            col.size = orig;
        }
	}
    void OnCollisionEnter2D(Collision2D coll)
    {
        switch (coll.gameObject.tag)
        {
            case "Ground":
                if (coll.collider.bounds.max.y < col.bounds.min.y + .1f)
                {
                    Top.S.grounded = true;
                    Bottom.S.grounded = true;
                    Top.S.anim.SetBool("jumping", false);
                    Bottom.S.anim.SetBool("jumping", false);
                }
                break;
        }
    }
    void OnCollisionExit2D(Collision2D coll)
    {
        switch (coll.gameObject.tag)
        {
            case "Ground":
                Top.S.grounded = false;
                Bottom.S.grounded = false;
                break;
        }
    }
}
