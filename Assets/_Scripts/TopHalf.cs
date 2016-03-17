/*using UnityEngine;
using System.Collections;

public class TopHalf : MonoBehaviour {

    public Sprite[] runRight;
    public Sprite[] jump;
    public Sprite[] idle;
    public Sprite[] crouch;

    SpriteRenderer sr;
    Rigidbody2D rigid;
    StateMachine animation_state_machine;
    public EntityState current_state = EntityState.NORMAL;

    private float iH_Top;
    public float moveSpeed = 5f;

    //PlayerControl tempPC;

    void Start() {
        rigid = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        //animation_state_machine = new StateMachine();
        //animation_state_machine.ChangeState(new StateIdleWithSprite(this, sr, idle[0]));
    }
	
	// Update is called once per frame
	void Update () {

        iH_Top = Input.GetAxis("L_XAxis_1");
        rigid.velocity = new Vector3(iH_Top * moveSpeed, rigid.velocity.y, 0f);

        if (Input.GetButtonDown("A_1")) {
            //Jump
            rigid.velocity = new Vector3(iH_Top * moveSpeed, rigid.velocity.y + 5f, 0f);
            Debug.Log("Player 1 Jumping");
        }

        if (Input.GetButtonDown("B_1")) {
            //Attack
            Debug.Log("Player 1 Attacking");
        }

        if (Input.GetButtonDown("RB_1") || Input.GetButtonDown("RB_2")) { //may not need in both top and bottom
            //call split funcation
            bool tempSplit = PlayerControl.SplitGetter();
            PlayerControl.S.splitOrCombine(tempSplit);
        }
    }
}
*/