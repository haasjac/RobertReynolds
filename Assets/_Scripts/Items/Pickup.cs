﻿using UnityEngine;
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
            //Destroy(gameObject);
            Vector3 clothing = Vector3.zero;
            switch (this.tag)
            {
                case "shirt":
                    if (coll.gameObject.tag != "Top" && coll.gameObject.tag != "Whole")
                        return;
                    clothing = new Vector3(0.2f, 1.7f, 0.0f);
                    this.transform.parent = Top.S.transform;
                    break;
                case "pants":
                    if (coll.gameObject.tag != "Bottom" && coll.gameObject.tag != "Whole")
                        return;
                    clothing = new Vector3(-0.2f, -2.8f, 0.0f);
                    this.transform.parent = Bottom.S.transform;
                    break;
                case "shoes":
                    if (coll.gameObject.tag != "Bottom" && coll.gameObject.tag != "Whole")
                        return;
                    clothing = new Vector3(0.43f, -6.5f, 0.0f);
                    this.transform.parent = Bottom.S.transform;
                    break;
                case "pony":
                    if (coll.gameObject.tag != "Bottom" && coll.gameObject.tag != "Whole")
                        return;
                    clothing = new Vector3(2.8f, -1.7f, 0.0f);
                    this.transform.parent = Bottom.S.transform;
                    break;
                case "hat":
                    if (coll.gameObject.tag != "Top" && coll.gameObject.tag != "Whole")
                        return;
                    clothing = new Vector3(-0.01f, 14f, 0.0f);
                    this.transform.parent = Top.S.transform;
                    break;
                case "shades":
                    if (coll.gameObject.tag != "Top" && coll.gameObject.tag != "Whole")
                        return;
                    clothing = new Vector3(1.26f, 9.71f, 0.0f);
                    this.transform.parent = Top.S.transform;
                    break;
                case "prop":
                    if (coll.gameObject.tag != "Bottom" && coll.gameObject.tag != "Whole")
                        return;
                    clothing = new Vector3(-0.01f, -0.59f, 0.0f);
                    this.transform.parent = Bottom.S.transform;
                    break;
                case "ET Hand":
                    if (coll.gameObject.tag != "Bottom" && coll.gameObject.tag != "Whole" && coll.gameObject.tag != "Bottom")
                        return;

                    this.transform.parent = Top.S.transform;
                    clothing = new Vector3(-1f, -4.2f, 0.0f);
                    this.transform.localRotation = Quaternion.Euler(0f, 0f, 180f);
                    break;
                case "Shades":
                    if (coll.gameObject.tag != "Bottom" && coll.gameObject.tag != "Whole" && coll.gameObject.tag != "Top")
                        return;

                    this.transform.parent = Bottom.S.transform;
                    clothing = new Vector3(.84f, -.67f, 0.0f);
                    this.transform.localRotation = Quaternion.Euler(0f, 30f, 0f);
                    break;
                case "Spock Ears":
                    if (coll.gameObject.tag != "Bottom" && coll.gameObject.tag != "Whole" && coll.gameObject.tag != "Top")
                        return;

                    this.transform.parent = Top.S.transform;
                    clothing = new Vector3(.5f, 14.13f, 0.0f);
                    break;
                default:
                    break;
            }
            //IncPickup
            UI.S.Collect(gameObject);
            if (GetComponent<Move>()) {
                Destroy(GetComponent<Move>());
            }
            Destroy(transform.FindChild("Clothes Outline").gameObject);
            this.GetComponent<BoxCollider2D>().enabled = false;
            this.transform.localPosition = clothing;
        }
    }
}

