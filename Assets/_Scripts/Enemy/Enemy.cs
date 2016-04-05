using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

    //public GameObject robot;
    //base stats
    public int health;
    public int damage;
    public int armor;

    //movement and attacks
    public float movement_speed;
    public float reload;
    public float ideal_dist;

    //patrol variables
    public Vector3 spawn;
    public float right_bound;
    public float left_bound;
    public float detection_range;

    public float turn_cooldown;
    public bool turning;

    //public int state_1, state_2;

	// Use this for initialization
	void Start () {
        //state_1 = state_2 = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

///////////////////////////////////////////////////////////////////////////////
//FUNCTION: decide which player to target based on distance, player split, and
//enemy capability.
    public GameObject auto_target(GameObject robot, string enemy_type) {
        //have the players split?
        if (split(robot)) {
            //target closest  player within range
            GameObject torso = robot.transform.FindChild("TopController").gameObject;
            GameObject legs = robot.transform.FindChild("BottomController").gameObject;

            if(torso == null || legs == null) {
                print("ERROR: auto_target");
                return robot;
            }

            float torso_dist = distance(this.gameObject, torso.transform.position);
            float legs_dist = distance(this.gameObject, legs.transform.position);
            if (torso_dist <= legs_dist)
                return torso;
            else
                return legs;
        }

        //otherwise, target composite robot
        return robot;
    }

///////////////////////////////////////////////////////////////////////////////
//FUNCTION: returns the distance between "first" and "second"
    public float distance(GameObject first, Vector3 second) {
        Vector3 pos1 = first.transform.position;
        Vector3 pos2 = second;//.transform.position;

        return (Mathf.Sqrt(Mathf.Pow(pos1.x - pos2.x, 2) + Mathf.Pow(pos1.y - pos2.y, 2)));
    }

///////////////////////////////////////////////////////////////////////////////
//FUNCTION: turns the enemy to face its target
    public void turn_around(GameObject dude_man_thing, GameObject target) {
        Vector3 turn = dude_man_thing.transform.localScale;
        if (target.transform.position.x > dude_man_thing.transform.position.x)
            turn.x = -1f;
        else
            turn.x = 1f;
        dude_man_thing.transform.localScale = turn;
    }

///////////////////////////////////////////////////////////////////////////////
//FUNCTION: returns true if the object is on camera
    public bool on_screen(GameObject camera, GameObject thingy) {
        if (Mathf.Abs(camera.transform.position.x - thingy.transform.position.x) > 9f)
            return false;
        else
            return true;
    }

///////////////////////////////////////////////////////////////////////////////
//FUNCTION: moves "this" enemy towards the target object
    public void move_to_target(Vector3 target_pos) {
        Vector3 pos = this.transform.position;
        //Vector3 roboPos = target.transform.position;

        if (pos.x > target_pos.x)
            pos.x -= Time.deltaTime * movement_speed;
        else
            pos.x += Time.deltaTime * movement_speed;

        this.transform.position = pos;
    }

    ///////////////////////////////////////////////////////////////////////////////
    //FUNCTION: move back and forth between left and right bounds
    //public void patrol() {
    //    Vector3 pos = this.transform.position;
    //    //if you're facing left
    //    if (this.transform.localScale.x == 1) {
    //        if (pos.x <= spawn.x - left_bound)
    //            this.transform.localScale = new Vector3(-1f, 1f, 1f);
    //        else
    //            pos.x -= Time.deltaTime * movement_speed;
    //    }
    //    //if you're facing right
    //    else {
    //        if (pos.x >= spawn.x + right_bound)
    //            this.transform.localScale = new Vector3(1f, 1f, 1f);
    //        else
    //            pos.x += Time.deltaTime * movement_speed;
    //    }
    //    this.transform.position = pos;
    //}

    //coroutine patrol for turn delays
    public IEnumerator patrol() {
        turning = true;
        Vector3 pos = this.transform.position;
        //if you're facing left
        if (this.transform.localScale.x == 1) {
            if (pos.x <= spawn.x - left_bound) {
                yield return new WaitForSeconds(turn_cooldown);
                this.transform.localScale = new Vector3(-1f, 1f, 1f);
            }
            else
                pos.x -= Time.deltaTime * movement_speed;
        }
        //if you're facing right
        else {
            if (pos.x >= spawn.x + right_bound) {
                yield return new WaitForSeconds(turn_cooldown);
                this.transform.localScale = new Vector3(1f, 1f, 1f);
            }
            else
                pos.x += Time.deltaTime * movement_speed;
        }
        this.transform.position = pos;
        turning = false;
        yield return new WaitForEndOfFrame();
    }

    ///////////////////////////////////////////////////////////////////////////////
    //FUNCTION: returns true if the players have split apart
    public bool split(GameObject robot) {
        //if (robot.GetComponent<playerController>().pState == playerState.APART)
            return true;
        //else
            //return false;
    }

///////////////////////////////////////////////////////////////////////////////
//FUNCTION: spawn the chosen icon above this enemy
    public GameObject spawn_icon(GameObject prefab) {
        GameObject icon = Instantiate<GameObject>(prefab);
        Vector3 pos = this.transform.position;
        pos.y += 1.6f;
        icon.transform.position = pos;

        return icon;
    }
///////////////////////////////////////////////////////////////////////////////
//FUNCTION: list of collisions for enemies
    public void OnCollisionEnter(Collision coll) {
        switch (coll.gameObject.tag) {
            case "PlayerWeapon":
                if (armor <= 0)
                    health--;
                else
                    armor--;

                if (health <= 0)
                    Destroy(this.gameObject);
                break;
            default:
                break;
        }
    }
}
