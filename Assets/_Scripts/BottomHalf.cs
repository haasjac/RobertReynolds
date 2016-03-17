/*using UnityEngine;
using System.Collections;

public class BottomHalf : MonoBehaviour {

    public Sprite[] runRight;
    public Sprite[] jump;
    public Sprite[] idle;
    public Sprite[] crouch;

    SpriteRenderer sr;
    Rigidbody2D rigid;
    StateMachine animation_state_machine;
    public EntityState current_state = EntityState.NORMAL;

    private float iH_Bottom;
    public float moveSpeed = 5f;

    // Use this for initialization
    void Start () {
        rigid = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }
	
	// Update is called once per frame
	void Update () {
        iH_Bottom = Input.GetAxis("L_XAxis_2");
        rigid.velocity = new Vector3(iH_Bottom * moveSpeed, rigid.velocity.y, 0f);

        if (Input.GetButtonDown("A_2")) {
            //Jump
            rigid.velocity = new Vector3(iH_Bottom * moveSpeed, rigid.velocity.y + 5f, 0f);
            Debug.Log("Player 2 Jumping");
        }

        if (Input.GetButtonDown("B_2")) {
            //Attack
            Debug.Log("Player 2 Attacking");
        }

        if (Input.GetButtonDown("RB_1") || Input.GetButtonDown("RB_2")) { //may not need in both top and bottom
            //call split funcation
            bool tempSplit = PlayerControl.SplitGetter();
            PlayerControl.S.splitOrCombine(tempSplit);
        }

    }
}*/
