using UnityEngine;
using System.Collections;

public class EnemyRanged : Enemy {

    public GameObject robot;
    public GameObject projectile;

    GameObject target;


	// Use this for initialization
	void Start () {
        reload = 2f;
        StartCoroutine("attack");
	}
	
	// Update is called once per frame
	void Update () {
        //target = auto_target(robot, "ranged");
        if(UI.S.together)
        {
            this.transform.LookAt(Whole.S.transform.position);
        }
        else
        {
            this.transform.LookAt(Bottom.S.container.transform.position);
        }
	}


    public IEnumerator attack() {
        for (;;) {
            //spawn projectile
            GameObject obj = Instantiate<GameObject>(projectile);
            obj.transform.position = this.transform.position;

            //choose target and aim
            Vector3 rot = this.transform.eulerAngles;
            rot.z = rot.x;
            rot.x = rot.y = 0.0f;
            obj.transform.eulerAngles = rot;

            //attack cooldown
            yield return new WaitForSeconds(reload);
        }
    }
}
