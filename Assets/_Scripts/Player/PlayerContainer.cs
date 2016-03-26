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
        if(childPlayer == Top.S)
        {
            if (!childPlayer.grounded)
            {
                col.offset = new Vector2(1, -3.3f);
                col.size = new Vector2(1.27f, 2f);
            }
            else
            {
                col.offset = new Vector2(1f, -3.75f);
                col.size = new Vector2(1.27f, 3.62f);
            }
        }
    }
    void OnCollisionEnter2D(Collision2D coll)
    {
        switch (coll.gameObject.tag)
        {
            case "Ground":
                childPlayer.grounded = true;
                break;
            case "Projectile":
                Destroy(coll.gameObject);
                childPlayer.health -= coll.gameObject.GetComponent<Projectile>().damage;
                break;
        }
    }
    void OnCollisionExit2D(Collision2D coll)
    {
        switch (coll.gameObject.tag)
        {
            case "Ground":
                childPlayer.grounded = false;
                break;
        }
    }
}
