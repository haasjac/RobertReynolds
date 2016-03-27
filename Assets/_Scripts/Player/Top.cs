using UnityEngine;
using System.Collections;

public class Top : Player
{
    public Transform fire;
    public static Top S;
    void Awake()
    {
        S = this;
    }
    // Use this for initialization
    void Start ()
    {
        rigid = Whole.S.rigid;
        fire = transform.FindChild("Fire");
        anim = GetComponent<Animator>();
        health = maxHealth;
        boxCol = GetComponent<BoxCollider2D>();
        grounded = true;
	}
	
	// Update is called once per frame
	void Update ()
    {
        //Animation Parameters set
        if (Mathf.Abs(rigid.velocity.x) > .01f)
        {
            anim.SetBool("walking", true);
        }
        else
        {
            anim.SetBool("walking", false);
            anim.Play("Idle Top");
        }
        if (facingRight && Input.GetKeyDown(KeyCode.A) && !UI.S.stopped)
        {
            facingRight = !facingRight;
            transform.localRotation = Quaternion.Euler(0f, 180f, 0f);
        }
        else if(!facingRight && Input.GetKeyDown(KeyCode.D) && !UI.S.stopped)
        {
            facingRight = !facingRight;
            transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
        }
        //Jump input
        if(Input.GetKeyDown(KeyCode.W) && grounded && !UI.S.stopped)
        {
            jump = true;
            anim.SetBool("jumping", true);
            UI.S.PlaySound("Jump");
        }
        else if(Input.GetKeyUp(KeyCode.W) && !grounded && !UI.S.stopped)
        {
            jumpCancel = true;
        }
        if(Input.GetKeyDown(KeyCode.LeftShift) && !attacking && !UI.S.stopped)
        {
            anim.SetBool("attacking", true);
            attacking = true;
            attackStart = Time.time;
            UI.S.PlaySound("Punch");
            //ATTACK
        }
        else if(attacking && Time.time > attackStart + attackDur)
        {
            attacking = false;
            anim.SetBool("attacking", false);
        }
        if(Input.GetKeyDown(KeyCode.LeftControl) && !UI.S.stopped)
        {
            SplitOrCombine();
        }
        anim.SetBool("jumping", jump);
    }
    void FixedUpdate()
    {
        if (UI.S.together)
        {
            //LASER
        }
        else
        {
            if(!UI.S.stopped)
            {
                iH = Input.GetAxis("Horizontal2");
            }
            Vector2 newVel = rigid.velocity; 
            newVel.x = iH * moveSpeed;
            rigid.velocity = newVel;
            //Jump
            if (jump)
            {
                rigid.velocity = new Vector2(rigid.velocity.x, maxJumpSpeed);
                jump = false;
                grounded = false;
                anim.SetBool("jumping", false);
            }
            if (jumpCancel)
            {
                if (rigid.velocity.y > minJumpSpeed)
                {
                    rigid.velocity = new Vector2(rigid.velocity.x, minJumpSpeed);
                }
                jumpCancel = false;
            }
        }
    }
}
