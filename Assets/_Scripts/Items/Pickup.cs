using UnityEngine;
using System.Collections;

public class Pickup : MonoBehaviour {
    public float speed = .000f;
    public float healthAmount = 1f;
	// Update is called once per frame
	void Update ()
    {
        //transform.Rotate(0f, 0f, 2f);
        //transform.position -= (new Vector3(0, Mathf.Cos(2 * Mathf.PI * Time.timeSinceLevelLoad) * speed, 0f));
    }
    void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.tag == "Whole" ||  coll.tag == "Top" || coll.tag == "Bottom")
        {
            UI.S.Collect(gameObject);
            if (this.tag == "shirt") {
                Vector3 shirt = new Vector3(0.505f, -6.93f, 0.0f);
                this.transform.parent = coll.gameObject.transform;
                this.transform.localPosition = shirt;
            }
            else if(this.tag == "pants") {
                Vector3 pants = new Vector3(-0.01f, -0.59f, 0.0f);
                this.transform.parent = coll.gameObject.transform;
                this.transform.localPosition = pants;
            }
            else if (this.tag == "shoes") {
                Vector3 shoes = new Vector3(0.069f, -1.039f, 0.0f);
                this.transform.parent = coll.gameObject.transform;
                this.transform.localPosition = shoes;
            }
            else if (this.tag == "hat") {
                Vector3 shoes = new Vector3(0.33f, 13.5f, 0.0f);
                this.transform.parent = coll.gameObject.transform;
                this.transform.localPosition = shoes;
            }
            else if (this.tag == "prop") {
                Vector3 shoes = new Vector3(6f, -0.4f, 0.0f);
                this.transform.parent = coll.gameObject.transform;
                this.transform.localPosition = shoes;
            }
            this.transform.localPosition = clothing;
        }
    }
    
}
