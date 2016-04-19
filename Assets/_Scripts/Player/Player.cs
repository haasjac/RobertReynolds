using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
    //PUBLIC
    public GameObject containerPrefab;
    public GameObject wholePrefab;
    public float moveSpeed = 5f;
    public float maxJumpSpeed = 6f, minJumpSpeed = 3f;
    public float splitJumpSpeed = 8f;
    public float attackDur = .5f, attackStart;
    public int player_num = 1;
    public bool grounded, attacking, flashing;
    public static bool hiding = false;
    [HideInInspector]
    public GameObject container;

    //PROTECTED
    public Animator anim;
    protected SpriteRenderer sr;
    protected Rigidbody2D rigid;
    protected GameObject whole;
    protected bool facingRight = true;
    protected bool jump, jumpCancel;
    protected float iH;
    protected bool walking = false;
    static protected bool can_split = true;
    static protected float split_cooldown = 1;
    static protected float split_timer = 0;

    // Use this for initialization
    protected void Start() {
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    protected void Update() {

        if (!UI.S.stopped) {

            //MOVING
            if (UI.S.together && !hiding) {
                iH = Input.GetAxis("L_XAxis_1") + Input.GetAxis("L_XAxis_2");
                if (iH > 1)
                    iH = 1;
                if (iH < -1)
                    iH = -1;
            } else {
                iH = Input.GetAxis("L_XAxis_" + player_num.ToString());
            }
            
            //Jump input
            if (Input.GetButtonDown("A_" + player_num.ToString()) && grounded && !UI.S.stopped && !hiding) {
                jump = true;
                if (UI.S.together || player_num == 1) {
                    UI.S.PlaySound("Jump");
                    Bottom.S.anim.Play("Bottom Jumping");
                } else {
                    UI.S.PlaySound("Top Jumping");
                }
            } else if (Input.GetButtonUp("A_" + player_num.ToString()) && !grounded && !UI.S.stopped && !hiding) {
                jumpCancel = true;
            }
            if (Input.GetKeyDown(KeyCode.RightControl) && !UI.S.stopped && !hiding && player_num == 1) {
                SplitOrCombine();
            }

            //SPLIT
            if (Input.GetButtonDown("Y_" + player_num.ToString()) && !UI.S.stopped && !hiding && can_split) {
                can_split = false;
                split_timer = 0;
                Top.S.SplitOrCombine();
            }
            if (!can_split) {
                split_timer += Time.deltaTime;
                if (split_timer > split_cooldown) {
                    can_split = true;
                }
            }


            //Animation Parameters set
            if (Mathf.Abs(iH) > .01f) {
                anim.SetBool("walking", true);
                walking = true;
                if (iH > 0) {
                    facingRight = true;
                    transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
                } else if (iH < 0) {
                    facingRight = false;
                    transform.localRotation = Quaternion.Euler(0f, 180f, 0f);
                }
            } else {
                walking = false;
                anim.SetBool("walking", false);
                if(anim.GetBool("jumping"))
                {
                    Bottom.S.anim.Play("Idle Bottom");
                }
            }
        }
    }

    protected void FixedUpdate() {

        if (!UI.S.stopped) {
            Rigidbody2D currentRigid = UI.S.together ? Whole.S.rigid : rigid;
            Vector2 newVel = currentRigid.velocity;
            newVel.x = iH * moveSpeed;
            currentRigid.velocity = newVel;
            //Jump
            if (jump) {
                currentRigid.velocity = new Vector2(currentRigid.velocity.x, maxJumpSpeed);
                jump = false;
                //grounded = false;
            }
            if (jumpCancel) {
                if (currentRigid.velocity.y > minJumpSpeed) {
                    currentRigid.velocity = new Vector2(currentRigid.velocity.x, minJumpSpeed);
                }
                jumpCancel = false;
            }
        }
    }

    protected void SplitOrCombine()
    {
       
        //Split
        if (UI.S.together)
        {
            UI.S.together = !UI.S.together;
            UI.S.PlaySound("Split");
            //Need containers for animations to run correctly
            Top.S.container = Instantiate(Top.S.containerPrefab, Whole.S.transform.position, Quaternion.identity) as GameObject;
            Bottom.S.container = Instantiate(Bottom.S.containerPrefab, Whole.S.transform.position, Quaternion.identity) as GameObject;
            Top.S.rigid = Top.S.container.GetComponent<Rigidbody2D>();
            Bottom.S.rigid = Bottom.S.container.GetComponent<Rigidbody2D>();
            Top.S.transform.parent = Top.S.container.transform;
            Bottom.S.transform.parent = Bottom.S.container.transform;
            Top.S.fire.gameObject.SetActive(true);
            Top.S.ps.gameObject.SetActive(true);
            Bottom.S.transform.position = Whole.S.transform.position;
            Destroy(Whole.S.gameObject);
            //Split Jump
            Top.S.rigid.velocity = new Vector2(Top.S.rigid.velocity.x, splitJumpSpeed);
            Top.S.grounded = false;
        }
        //Join
        else
        {
            if (/*Top.S.grounded && Bottom.S.grounded && */(Top.S.container.transform.position - Bottom.S.container.transform.position).magnitude < 1f)
            {
                UI.S.together = !UI.S.together;
                UI.S.PlaySound("Recombine");
                whole = Instantiate(wholePrefab, Top.S.container.transform.position, Quaternion.identity) as GameObject;
                Top.S.transform.parent = Bottom.S.transform.parent = whole.transform;
                Bottom.S.transform.localPosition = Vector3.zero;
                Destroy(Top.S.container.gameObject);
                Destroy(Bottom.S.container.gameObject);
                Top.S.rigid = Whole.S.rigid;
                Top.S.fire.gameObject.SetActive(false);
                Top.S.ps.gameObject.SetActive(false);
            }
            else
            {
                UI.S.PlaySound("Reject");
            }
        }
    }
    public IEnumerator Flash()
    {
        if (!flashing)
        {
            UI.S.PlaySound("Alarm");
            flashing = true;
            for (int i = 0; i < 3; ++i)
            {
                sr.color = Color.red;
                yield return new WaitForSeconds(.15f);
                sr.color = Color.white;
                yield return new WaitForSeconds(.15f);
            }
            flashing = false;
        }
    }
}
