using UnityEngine;
using System.Collections;

public class EnemyMelee : Enemy {

    public GameObject robot;
    public GameObject cam;

    public bool attacking;
    public float cooldown;
    public float direction = 1.0f;

    // Use this for initialization
    void Start() {
        health = 3;
        damage = 1;
        armor = 0;
        cooldown = 0.0f;
        reload = 2f;
        movement_speed = 3f;
        ideal_dist = 3f;

        attacking = false;
        spawn = this.transform.position;
        detection_range = 10f;
    }

    // Update is called once per frame
    void Update() {
        //if you're not on camera, do nothing
        if (!on_screen(cam, this.gameObject))
            return;

        //are you currently attacking?
        attacking = GetComponent<Animation>().IsPlaying("punch");

        //if target is within detection range...
        float target_dist = distance(this.gameObject, robot.transform.position);
        if (target_dist <= detection_range) {
            //face your target
            turn_around(this.gameObject, robot);

            //move closer if necessary
            if (target_dist > ideal_dist) {
                cooldown = 0.0f;
                move_to_target(robot.transform.position);
            }
            else {
                //if reload is down, attack
                if (cooldown > 0.0f)
                    cooldown -= Time.deltaTime;
                else
                    fist();
            }
        }
        else
            patrol();
    }


    public void fist() {
        cooldown = reload;
        print("attack!");
        GetComponent<Animation>().Play("punch");
        attacking = true;
    }
    void OnCollisionEnter2D(Collision2D coll)
    {
        if(Top.S.attacking)
        {
            Destroy(gameObject);
        }
    }
}
