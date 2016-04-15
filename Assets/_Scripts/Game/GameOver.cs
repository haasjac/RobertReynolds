using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour {
    public GameObject respawn_location;
	

    void OnTriggerEnter2D(Collider2D col) {
        //Enviomental hazard
        //Debug.Log("TouchWater");
        UI.S.PlaySound("Cut");
    }

    void OnTriggerExit2D(Collider2D col) {
        //Respawn @ checkpoint
        //Debug.Log("LeftWater");
        col.gameObject.transform.position = respawn_location.transform.position;
    }


}
