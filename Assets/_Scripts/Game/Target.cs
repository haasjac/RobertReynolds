using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class Target : MonoBehaviour {
    public UnityEvent onPress;
    public SpriteRenderer sr;
    public Sprite on;
    bool clicked;

    // Use this for initialization
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        clicked = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (clicked)
        {
            sr.sprite = on;
            onPress.Invoke();
            clicked = false;
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (!clicked && (coll.gameObject.tag == "Laser"))
        {
            Destroy(coll.collider.gameObject);
            clicked = true;
            UI.S.PlaySound("Button Push");
            GetComponent<PolygonCollider2D>().enabled = false;
        }
    }
}
