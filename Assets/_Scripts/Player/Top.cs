using UnityEngine;
using System.Collections;

public class Top : Player
{
    public Transform fire;
    public Transform ps;
    public bool carrying = false;
    public GameObject magnet;
    public float laserDur = 2f, lastLaser = 0f;
    public GameObject laserOrigin, laserBeam;
    public static Top S;
    //bool throwing = false;
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

    IEnumerator Laser()
    {
        lastLaser = Time.time;
        UI.S.PlaySound("Charging");
        yield return new WaitForSeconds(1f);
        UI.S.PlaySound("Laser");
        Instantiate(laserBeam, laserOrigin.transform.position, Quaternion.identity);
    }
    // Update is called once per frame
    new void Update ()
    {
        if(!carrying)
        {
            base.Update();
            if(Input.GetButtonDown("TriggersR_2") && Time.time - lastLaser > laserDur)
            {
                StartCoroutine(Laser());
            }
            //Throw
            if (Input.GetButtonDown("B_2") && !UI.S.stopped && !UI.S.together && 
                (facingRight ? (Bottom.S.container.transform.position.x - Top.S.container.transform.position.x) : (Top.S.container.transform.position.x - Bottom.S.container.transform.position.x)) >  0f && (Bottom.S.container.transform.position - Top.S.container.transform.position).magnitude < 1f)
            {
                if(Bottom.S.facingRight != facingRight)
                {
                    print("H");
                    Bottom.S.facingRight = !Bottom.S.facingRight;
                    Bottom.S.transform.localRotation = facingRight ? Quaternion.Euler(0f, 0f, 0f): Quaternion.Euler(0f, 180f, 0f);
                }
                magnet.SetActive(true);
                Bottom.S.arrow.SetActive(true);
                Bottom.S.arrowHead.SetActive(true);
                Bottom.S.anim.SetBool("walking", true);
                Bottom.S.carried = true;
                Top.S.carrying = true;
                Bottom.S.container.transform.parent = container.transform;
                UI.S.PlaySound("Pickup");
            }
        }
        else
        {
            if (Input.GetButtonDown("B_2"))
            {
                UI.S.PlaySound("Reject");
                magnet.SetActive(false);
                Bottom.S.arrow.SetActive(false);
                Bottom.S.arrowHead.SetActive(false);
                Bottom.S.anim.SetBool("walking", false);
                Bottom.S.carried = false;
                Top.S.carrying = false;
                Bottom.S.container.transform.parent = null;
            }
            if(Mathf.Abs(Input.GetAxis("L_XAxis_2")) > .5f || Mathf.Abs(Input.GetAxis("L_XAxis_1")) > .5f)
            {
                UI.S.PlaySound("Reject");
            }
        }
        /*
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
        }*/
        //Throw
       // if(!UI.S.together)
        //{
          //  anim.Play("ThrowStart");
        //}
        //if(throwing)
        //{
           // Bottom.S.container 
        //}
    }
    new void FixedUpdate()
    {
        if(!carrying)
        {
            base.FixedUpdate();
        }
        if (UI.S.together)
        {
            //LASER
        }
        else
        {
        }
    }
}
