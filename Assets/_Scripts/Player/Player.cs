using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
    protected Animator anim;
    protected Rigidbody2D rigid;
    public GameObject containerPrefab;
    public GameObject container;
    public BoxCollider2D boxCol;
    public GameObject wholePrefab;
    public GameObject whole;
    public bool facingRight = true;
    public float maxHealth = 1f;
    public float health;
    public float moveSpeed = 5f;
    public float maxJumpSpeed = 6f, minJumpSpeed = 3f;
    private float splitJumpSpeed = 8f;
    public float attackDur = .5f, attackStart;
    public bool grounded, jump, jumpCancel, attacking;
    public float iH;
    // Use this for initialization
    protected void SplitOrCombine()
    {
        UI.S.together = !UI.S.together;
        UI.S.PlaySound("Jump");
        //Split
        if (!UI.S.together)
        {
            //Need containers for animations to run correctly
            Top.S.container = Instantiate(Top.S.containerPrefab, Whole.S.transform.position, Quaternion.identity) as GameObject;
            Bottom.S.container = Instantiate(Bottom.S.containerPrefab, Whole.S.transform.position, Quaternion.identity) as GameObject;
            Top.S.rigid = Top.S.container.GetComponent<Rigidbody2D>();
            Bottom.S.rigid = Bottom.S.container.GetComponent<Rigidbody2D>();
            Top.S.transform.parent = Top.S.container.transform;
            Bottom.S.transform.parent = Bottom.S.container.transform;
            Top.S.fire.gameObject.SetActive(true);
            print(Whole.S.transform.position);
            Bottom.S.transform.position = Whole.S.transform.position;
            Destroy(Whole.S.gameObject);
            //Split Jump
            Top.S.rigid.velocity = new Vector2(Top.S.rigid.velocity.x, splitJumpSpeed);
        }
        //Join
        else
        {
            whole = Instantiate(wholePrefab, Top.S.container.transform.position, Quaternion.identity) as GameObject;
            Top.S.transform.parent = Bottom.S.transform.parent = whole.transform;
            Destroy(Top.S.container.gameObject);
            Destroy(Bottom.S.container.gameObject);
            Top.S.rigid = Whole.S.rigid;
            Top.S.fire.gameObject.SetActive(false);
        }
    }
}
