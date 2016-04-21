using UnityEngine;
using System.Collections;

public class IAmTheOneWhoKnocks : MonoBehaviour {
    public float timer = 2f;
    public float penalty = 0.3f;
    

    public IEnumerator restart(GameObject player) {
        yield return new WaitForSeconds(timer);
        Vector3 pos = this.transform.position;
        pos.x -= 7f;
        pos.y += 7f;
        pos.z = 0;
        player.transform.position = pos;
        UI.S.ChangeSuspicion(-penalty);
    }

    public void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.gameObject.tag == "Whole" || coll.gameObject.tag == "Top" || coll.gameObject.tag == "Bottom")
            StartCoroutine("restart", coll.gameObject);
    }
    public void Dest()
    {
        Destroy(gameObject);
    }
}
