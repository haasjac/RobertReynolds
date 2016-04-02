using UnityEngine;
using System.Collections;

public class Oscillate : MonoBehaviour {
    public float speed = .001f;
	// Update is called once per frame
	void Update ()
    {
        transform.position -= (new Vector3(0, Mathf.Cos(2 * Mathf.PI * Time.timeSinceLevelLoad) * speed, 0f));
    }
}
