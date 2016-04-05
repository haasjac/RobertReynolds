using UnityEngine;
using System.Collections;

public class Pickup : MonoBehaviour
{
    public float speed = .000f;
    public float healthAmount = 1f;
    // Update is called once per frame
    void Update()
    {
        //transform.Rotate(0f, 0f, 2f);
        //transform.position -= (new Vector3(0, Mathf.Cos(2 * Mathf.PI * Time.timeSinceLevelLoad) * speed, 0f));
    }
    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag == "Whole" || coll.tag == "Top" || coll.tag == "Bottom")
        {
            //TODO: Play Pickup Sound
            //IncPickup
            UI.S.Collect(gameObject);
            //Destroy(gameObject);
            this.GetComponent<BoxCollider2D>().enabled = false;
            Vector3 clothing = Vector3.zero;
            switch (this.tag)
            {
                case "shirt":
                    clothing = new Vector3(0.2f, 1.7f, 0.0f);
                    this.transform.parent = coll.gameObject.transform.FindChild("Top").transform;
                    break;
                case "pants":
                    clothing = new Vector3(-0.2f, -2.8f, 0.0f);
                    this.transform.parent = coll.gameObject.transform.FindChild("Bottom").transform;
                    break;
                case "shoes":
                    clothing = new Vector3(0.43f, -6.5f, 0.0f);
                    this.transform.parent = coll.gameObject.transform.FindChild("Bottom").transform;
                    break;
                case "hat":
                    clothing = new Vector3(-0.01f, -0.59f, 0.0f);
                    this.transform.parent = coll.gameObject.transform.FindChild("Top").transform;
                    break;
                case "prop":
                    clothing = new Vector3(-0.01f, -0.59f, 0.0f);
                    this.transform.parent = coll.gameObject.transform.FindChild("Bottom").transform;
                    break;
                default:
                    break;
            }
            this.transform.localPosition = clothing;
        }
    }
}

