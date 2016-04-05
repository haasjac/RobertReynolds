using UnityEngine;
using System.Collections;

public class FallingTrap : MonoBehaviour {
    // Use this for initialization
    public float damage = .1f;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if(UI.S.together)
        {
            if (Mathf.FloorToInt(Whole.S.transform.position.x) == Mathf.FloorToInt(this.transform.position.x))
            {
                this.GetComponent<FixedJoint2D>().enabled = false;
            }
        }
        else
        {
            if (Mathf.FloorToInt(Top.S.container.transform.position.x) == Mathf.FloorToInt(this.transform.position.x) || Mathf.FloorToInt(Bottom.S.container.transform.position.x) == Mathf.FloorToInt(this.transform.position.x))
            {
                this.GetComponent<FixedJoint2D>().enabled = false;
            }
        }
	}
    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag == "Whole")
        {
            StartCoroutine(Top.S.Flash());
            StartCoroutine(Bottom.S.Flash());
            UI.S.ChangeSuspicion(-damage);
        }
        else if (coll.tag == "Top")
        {
            StartCoroutine(Top.S.Flash());
            UI.S.ChangeSuspicion(-damage);
        }
        else if (coll.tag == "Bottom")
        {
            StartCoroutine(Bottom.S.Flash());
            UI.S.ChangeSuspicion(-damage);
        }
        Destroy(transform.parent.gameObject);
    }
}
