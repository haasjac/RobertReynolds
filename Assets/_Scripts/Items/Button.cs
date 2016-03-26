using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour {

    public GameObject destroy;
    public float dis = 1;
    public float speed = 0.1f;

    bool clicked;
    Vector3 target;

	// Use this for initialization
	void Start () {
        target = transform.position + Vector3.down * dis;
        clicked = false;
	}
	
	// Update is called once per frame
	void Update () {
	    if (clicked) {
            transform.position = Vector3.Lerp(transform.position, target, speed);
            if (Vector3.Distance(transform.position, target) < 0.1) {
                destroy.SetActive(false);
                gameObject.SetActive(false);
            }
        }
	}

    void OnCollisionEnter2D(Collision2D coll) {
        print(coll.contacts[0].normal);
        if (coll.gameObject.tag == "Bottom" && coll.contacts[0].normal == Vector2.down) {
            print(clicked);
            clicked = true;
            
        }
    }
}
