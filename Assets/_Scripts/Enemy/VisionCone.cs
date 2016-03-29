using UnityEngine;
using System.Collections;

public class VisionCone : MonoBehaviour {

    public GameObject robot;

    public bool collision;

    void Start() {
        robot = this.transform.parent.GetComponent<Patrol>().robot;
    }


    public void i_see_you() {
        //take into account amount of clothing
        //robot.GetComponent<playerController>().suspicion++;
        print("target in sight");
        UI.S.ChangeSuspicion(0.001f);
    }


    void OnTriggerEnter2D(Collider2D coll) {
        string layer = LayerMask.LayerToName(coll.gameObject.layer);
        switch (layer) {
            case "Player":
                print("whatzat???");
                Patrol enemy = this.transform.parent.GetComponent<Patrol>();
                enemy.enabled = false;
                i_see_you();
                //see if icon has already been spawned
                if (enemy.icon != null)
                    break;
                else {
                    enemy.icon = enemy.spawn_icon(enemy.detected);
                    enemy.icon.transform.parent = this.transform.parent;
                }

                break;
            default:
                break;
        }
    }


    void OnTriggerStay2D(Collider2D coll) {
        string layer = LayerMask.LayerToName(coll.gameObject.layer);
        switch (layer) {
            case "Player":
                i_see_you();
                break;
            default:
                break;
        }
    }


    void OnTriggerExit2D(Collider2D coll) {
        string layer = LayerMask.LayerToName(coll.gameObject.layer);
        switch (layer) {
            case "Player":
                print("break stare");
                Patrol enemy = this.transform.parent.GetComponent<Patrol>();
                enemy.enabled = true;
                enemy.searching = true;
                Destroy(enemy.icon.gameObject);
                break;
            default:
                break;
        }
    }
}
