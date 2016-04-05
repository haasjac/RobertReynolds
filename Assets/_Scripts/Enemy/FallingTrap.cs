using UnityEngine;
using System.Collections;

public class FallingTrap : MonoBehaviour
{
    public float damage = .1f;
	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(UI.S.together)
        {
            if (Mathf.FloorToInt(Whole.S.transform.position.x) >= Mathf.FloorToInt(this.transform.position.x) - 1f)
            {
                this.GetComponent<FixedJoint2D>().enabled = false;
            }
        }
        else
        {
            if (Mathf.FloorToInt(Top.S.container.transform.position.x) >= Mathf.FloorToInt(this.transform.position.x) - 1f)
            {
                this.GetComponent<FixedJoint2D>().enabled = false;
            }
            else if (Mathf.FloorToInt(Bottom.S.container.transform.position.x) >= Mathf.FloorToInt(this.transform.position.x) - 1f)
            {
                this.GetComponent<FixedJoint2D>().enabled = false;
            }
        }
    }
    void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.tag == "Whole" || coll.tag == "Bottom" || coll.tag == "Top")
        {
            UI.S.ChangeSuspicion(-damage);
        }
        Destroy(transform.parent.gameObject);
    }
}
