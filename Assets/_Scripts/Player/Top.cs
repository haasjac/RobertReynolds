using UnityEngine;
using System.Collections;

public class Top : Player
{
    public Transform fire;
    public Transform ps;
    public static Top S;
    bool throwing;
    void Awake()
    {
        S = this;
    }
    
    // Use this for initialization
    new void Start ()
    {
        base.Start();
        fire = transform.FindChild("Fire");
        ps = transform.FindChild("Particle System");
	}
	
	// Update is called once per frame
	new void Update ()
    {
        base.Update();
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
        //Throw
        if(!UI.S.together)
        {
            anim.Play("ThrowStart");
        }
        if(throwing)
        {
           // Bottom.S.container 
        }
    }
    new void FixedUpdate()
    {
        base.FixedUpdate();
        if (UI.S.together)
        {
            //LASER
        }
        else
        {
        }
    }
}
