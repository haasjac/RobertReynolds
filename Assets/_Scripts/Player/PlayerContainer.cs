using UnityEngine;
using System.Collections;

public class PlayerContainer : MonoBehaviour {
    Player childPlayer;
    BoxCollider2D col;
    Rigidbody2D rigid;
    float airTime, airDur = .3f;
    void Start()
    {
        col = GetComponent<BoxCollider2D>();
        rigid = GetComponent<Rigidbody2D>();
        foreach(Transform child in transform)
        {
            childPlayer = child.GetComponent<Player>();
        }
    }
    void Update()
    {
        if(Mathf.Abs(rigid.velocity.y) > .0001f)
        {
            airTime = Time.time;
            
        }
        else if(Time.time - airTime > .2f)
        {
            childPlayer.grounded = true;
        }
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
                      if(coll.contacts[0].normal == Vector2.up)
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
                  if(childPlayer)
                  childPlayer.grounded = false;
                  break;
          }
      }
}
