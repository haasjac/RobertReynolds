/*using UnityEngine;
using System.Collections;

public enum EntityState {NORMAL, ATTACKING};

public class PlayerControl : MonoBehaviour {

    public Sprite[] runRight;
	public Sprite[] jump;
	public Sprite[] idle;
    public Sprite[] crouch;

    SpriteRenderer sr;
    Rigidbody2D rigid;
    StateMachine animation_state_machine;
    public EntityState current_state = EntityState.NORMAL;
    public float moveSpeed = 5f;

    //horizontal movement
    private float iH_together; 


    static public bool split = false; //false = together, true = split
    public GameObject top;
    public GameObject bottom;
    public GameObject wholebody;

    public static PlayerControl S; //player control singlton

    // Use this for initialization
    void Start ()
    {
        S = this;
        rigid = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        animation_state_machine = new StateMachine();
        animation_state_machine.ChangeState(new StateIdleWithSprite(this, sr, idle[0]));
    }
	
	// Update is called once per frame
	void Update ()
    {
        animation_state_machine.Update();
        //iV = Input.GetAxis("A");
        iH_together = Input.GetAxis("L_XAxis_2") * 5f;
        rigid.velocity = new Vector3(iH_together * moveSpeed, rigid.velocity.y, 0f);
        if (Input.GetButtonDown("RB_1") || Input.GetButtonDown("RB_2")) {
            //call split funcation
            split = !split;
            splitOrCombine(split);
        }

        if (Input.GetButtonDown("A_2")) {
            //Jump
            rigid.velocity = new Vector3(iH_together * moveSpeed, rigid.velocity.y + 5f, 0f);
            Debug.Log("Jumping");
        }

        if (Input.GetButtonDown("B_1")) {
            //Attack
            Debug.Log("Attacking");
        }
        
 
    }

    static public bool SplitGetter() {
        //Flips & returns !split from PlayerControl
        split = !split;
        return split;

    }

    public void splitOrCombine(bool breakup) {
        Debug.Log("Split Var: " + breakup);
        if (breakup) {
            //split
            top.SetActive(true);
            bottom.SetActive(true);
            wholebody.SetActive(false);
            Debug.Log("Split");
        }
        else {
            //recombine
            top.SetActive(false);
            bottom.SetActive(false);
            wholebody.SetActive(true);
            Debug.Log("Combine");
        }

    }

}*/
