using UnityEngine;
using System.Collections;

public class EnemyRanged : MonoBehaviour {

    public GameObject player_1;
    public GameObject player_2;
    public GameObject projectile;
    Rigidbody2D rigid;
    public float reload = 2f;


	// Use this for initialization
	void Start () {
        StartCoroutine("attack");
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.LookAt(player_1.transform.position);
	}


    public IEnumerator attack() {
        for (;;) {
            //spawn projectile
            GameObject obj = Instantiate(projectile, transform.position, Quaternion.identity) as GameObject;
            obj.GetComponent<Rigidbody2D>().velocity = (player_1.transform.position - transform.position).normalized;
            //obj.transform.position = this.transform.position;

            //choose target and aim
            //Vector3 relativePos = player_1.transform.position - this.transform.position;
            //obj.transform.rotation = Quaternion.LookRotation(relativePos);
            //Quaternion rotation = Quaternion.LookRotation(player_1.transform.position - transform.position, transform.TransformDirection(Vector3.up));
            //obj.transform.rotation = new Quaternion(0, 0, rotation.z, rotation.w);
            //obj.transform.LookAt(player_1.transform.position);

            //TEMP: left rotation fix
            //if (player_1.transform.position.x < this.transform.position.x) {
            //     this.transform.rotation = new Quaternion(0,0,0,0);
            //rotation.z -= 0.5f;
            //obj.transform.rotation = new Quaternion(0, 0, rotation.z, rotation.w);
            // }

            //attack cooldown
            yield return new WaitForSeconds(reload);
        }
    }
}
