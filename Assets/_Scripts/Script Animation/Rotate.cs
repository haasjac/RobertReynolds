using UnityEngine;
using System.Collections;

public class Rotate : MonoBehaviour
{
    public float speed = 2f;
	// Update is called once per frame
	void Update ()
    {
        transform.Rotate(0f, 0f, speed);
    }
}
