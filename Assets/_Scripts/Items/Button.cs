using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class Button : MonoBehaviour {
    public UnityEvent onPress;
    public SpriteRenderer sr;
    public Sprite on;
    bool clicked;

	// Use this for initialization
	void Start () {
        sr = GetComponent<SpriteRenderer>();
        clicked = false;
	}
	
	// Update is called once per frame
	void Update () {
	    if (clicked) {
            sr.sprite = on;
            onPress.Invoke();
        }
	}

    void OnCollisionEnter2D(Collision2D coll) {
        if (!clicked && (coll.gameObject.tag == "Bottom" || coll.gameObject.tag == "Top" || coll.gameObject.tag == "Whole") && coll.contacts[0].normal == Vector2.down)
        {
            clicked = true;
            UI.S.PlaySound("Button Push");
        }
    }
}
