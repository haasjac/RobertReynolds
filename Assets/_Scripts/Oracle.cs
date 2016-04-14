using UnityEngine;
using System.Collections;

public class Oracle : MonoBehaviour {

    public float delay = 3f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (UI.S.currentSuspicion <= 0.0f)
            StartCoroutine("scene_change", "GameOver");
    }

    public IEnumerator scene_change(string scene) {
        yield return new WaitForSeconds(delay);
        UnityEngine.SceneManagement.SceneManager.LoadScene(scene);
    }
}
