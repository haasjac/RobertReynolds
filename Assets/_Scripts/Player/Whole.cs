﻿using UnityEngine;
using System.Collections;

public class Whole : MonoBehaviour {
    public static Whole S;
    public Rigidbody2D rigid;
    BoxCollider2D coll;
    Vector2 orig;
    void Awake()
    {
        S = this;
        rigid = GetComponent<Rigidbody2D>();
    }
	// Use this for initialization
	void Start () {
        coll = GetComponent<BoxCollider2D>();
        orig = coll.size;
	}
	
	// Update is called once per frame
	void Update () {
	    if(Top.S.attacking)
        {
            coll.size = new Vector2(orig.x * 2, orig.y);
        }
        else
        {
            coll.size = orig;
        }
	}
    void OnCollisionEnter2D(Collision2D coll)
    {
        switch (coll.gameObject.tag)
        {
            case "Ground":
                Bottom.S.grounded = true;
                break;
            case "Projectile":
                Destroy(coll.gameObject);
                UI.S.fullHealth -= coll.gameObject.GetComponent<Projectile>().damage;
                break;
        }
    }
    void OnCollisionExit2D(Collision2D coll)
    {
        switch (coll.gameObject.tag)
        {
            case "Ground":
                Bottom.S.grounded = false;
                break;
        }
    }
}
