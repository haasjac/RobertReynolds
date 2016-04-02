using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class Button : MonoBehaviour {
    
    public float dis = 1;
    public float speed = 0.1f;
    public UnityEvent onPress;

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
                onPress.Invoke();
                gameObject.SetActive(false);
            }
        }
	}

    void OnCollisionEnter2D(Collision2D coll) {
        if ((coll.gameObject.tag == "Bottom" || coll.gameObject.tag == "Top" || coll.gameObject.tag == "Whole") && coll.contacts[0].normal == Vector2.down)
        {
            clicked = true;
            UI.S.PlaySound("Button Push");
        }
    }
}
