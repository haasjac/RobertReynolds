using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour
{
    public float existTime = 5f;
    public float startTime;
    public float movement_speed = 3f;
    public float damage = 0.1f;

    // Use this for initialization
    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update() {
        if(Time.time - startTime > existTime) {
            Destroy(gameObject);
        }

        //move projectile forward
        Vector3 pos = this.transform.position;
        pos -= transform.right * (Time.deltaTime * movement_speed);
        this.transform.position = pos;
    }


    void OnTriggerEnter2D(Collider2D col) {
        Destroy(gameObject);
    }
}
