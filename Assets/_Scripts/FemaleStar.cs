using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class FemaleStar : MonoBehaviour {
    bool collided = false;
    public bool start = false;
    public GameObject heartPrefab;
    Animator anim;
	// Use this for initialization
	void Start ()
    {
        anim = GetComponent<Animator>();
	}	
	// Update is called once per frame
	void Update ()
    {
        if(!collided && start)
        {
            transform.position -= Vector3.right / 100f;
        }
    }
    void OnTriggerEnter2D(Collider2D coll)
    {
        collided = true;
        anim.SetBool("talking", true);
        StartCoroutine(Finish());
    }
    public void startWalk()
    {
        start = true;
    }
    IEnumerator Finish()
    {
        Instantiate(heartPrefab, (Whole.S.transform.position + transform.position) / 2f, Quaternion.identity);
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("Title");
    }
}
