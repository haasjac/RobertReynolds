using UnityEngine;
using System.Collections;

public class PlayerContainer : MonoBehaviour {
    Player childPlayer;
    BoxCollider2D col;
    void Start()
    {
        col = GetComponent<BoxCollider2D>();
        foreach(Transform child in transform)
        {
            childPlayer = child.GetComponent<Player>();
        }
    }
    void Update()
    { 
    }
    void OnCollisionEnter2D(Collision2D coll)
    {
        if(childPlayer == Bottom.S && !Top.S.carrying)
        {
            Bottom.S.carried = false;
        }
        childPlayer.rigid.gravityScale = 1f;
        switch (coll.gameObject.tag)
        {
            case "Ground":
                if (coll.collider.bounds.max.y < col.bounds.min.y + .1f)
                {
                    childPlayer.grounded = true;
                    childPlayer.anim.SetBool("jumping", false);
                }
                break;
        }
    }
    void OnCollisionExit2D(Collision2D coll)
    {
        switch (coll.gameObject.tag)
        {
            case "Ground":
                if (coll.contacts[0].normal == Vector2.up) {
                    childPlayer.grounded = false;
                }
                break;
        }
    }
}
