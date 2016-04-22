using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class FemaleStar : MonoBehaviour {
    bool collided = false;
    public bool start = false;
    bool end = false;
    public GameObject heartPrefab;
    Animator anim;
    public string scene;
	// Use this for initialization
	void Start ()
    {
        anim = GetComponent<Animator>();
	}	
	// Update is called once per frame
	void Update ()
    {
        if(end)
        {
            Bottom.S.anim.Stop();
            Whole.S.rigid.velocity = Vector3.zero;
            UI.S.stopped = true;
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
        UI.S.stopped = true;
        end = true;
        UI.S.PlaySound("Success");
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(scene);
    }
}
