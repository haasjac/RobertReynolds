using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour
{
    public float existTime = 5f;
    public float startTime;
    public float speed = 3f;
    // Use this for initialization
    void Start()
    {
        startTime = Time.time;
        GetComponent<Rigidbody2D>().velocity *= speed;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time - startTime > existTime)
        {
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        Destroy(gameObject);
    }
}
