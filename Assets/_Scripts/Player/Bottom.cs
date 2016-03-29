using UnityEngine;
using System.Collections;

public class Bottom : Player {
    public static Bottom S;
    void Awake()
    {
        S = this;
    }
    // Use this for initialization
    void Start ()
    {
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        health = maxHealth;
        boxCol = GetComponent<BoxCollider2D>();
        grounded = true;
    }
    void Update()
    {
        //Animation Parameters set
        if(Mathf.Abs(iH) > .01f)
        {
            anim.SetBool("walking", true);
        }
        else
        {
            anim.SetBool("walking", false);
        }
        //Left or right input
        if (facingRight && Input.GetKeyDown(KeyCode.LeftArrow))
        {
            facingRight = !facingRight;
            transform.localRotation = Quaternion.Euler(0f, 180f, 0f);
        }
        else if (!facingRight && Input.GetKeyDown(KeyCode.RightArrow))
        {
            facingRight = !facingRight;
            transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
        }
        //Jump input
        if(Input.GetKeyDown(KeyCode.UpArrow) && grounded && !UI.S.stopped)
        {
            jump = true;
            UI.S.PlaySound("Feet Jumping");
            anim.SetBool("jumping", true);
        }
        else if(Input.GetKeyUp(KeyCode.UpArrow) && !grounded && !UI.S.stopped)
        {
            jumpCancel = true;
        }
        if (Input.GetKeyDown(KeyCode.RightControl) && !UI.S.stopped)
        {
            SplitOrCombine();
        }
    }
    void FixedUpdate()
    {
        Rigidbody2D currentRigid = UI.S.together ? Whole.S.rigid : rigid;
        //Move left or right
        if(!UI.S.stopped)
        {
            iH = Input.GetAxis("Horizontal");
        }
        Vector2 newVel = currentRigid.velocity;
        newVel.x = iH * moveSpeed;
        currentRigid.velocity = newVel;
        //Jump
        if(jump)
        {
            currentRigid.velocity = new Vector2(currentRigid.velocity.x, maxJumpSpeed);
            jump = false;
            grounded = false;
            anim.SetBool("jumping", false);
        }
        if(jumpCancel)
        {
            if(currentRigid.velocity.y > minJumpSpeed)
            {
                currentRigid.velocity = new Vector2(currentRigid.velocity.x, minJumpSpeed);
            }
            jumpCancel = false;
        }
        //Legs only attack together/fall down?
        if (UI.S.together)
        {
        }
        else
        {
            
        }
    }
}
