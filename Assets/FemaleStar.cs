using UnityEngine;
using System.Collections;

public class FemaleStar : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.position += Vector3.right / 100f;
	}
}
