using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

    public float movement_speed = 10f;

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        //move projectile forward
        Vector3 pos = this.transform.position;
        pos += transform.forward * (Time.deltaTime * movement_speed);
        this.transform.position = pos;
    }


    void OnCollisionEnter(Collision coll) {
        switch (coll.gameObject.tag) {
            case "Player":
                //player.health--;
                Destroy(this.gameObject);
                break;
            default:
                Destroy(this.gameObject);
                break;
        }
    }
}
