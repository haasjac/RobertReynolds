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
    new void Start ()
    {
        base.Start();
        fire = transform.FindChild("Fire");
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
