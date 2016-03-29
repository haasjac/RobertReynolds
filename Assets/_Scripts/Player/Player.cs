using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
    protected Animator anim;
    public SpriteRenderer sr;
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
       
        //Split
        if (UI.S.together)
        {
            UI.S.together = !UI.S.together;
            UI.S.PlaySound("Jump");
            //Need containers for animations to run correctly
            Top.S.container = Instantiate(Top.S.containerPrefab, Whole.S.transform.position, Quaternion.identity) as GameObject;
            Bottom.S.container = Instantiate(Bottom.S.containerPrefab, Whole.S.transform.position, Quaternion.identity) as GameObject;
            Top.S.rigid = Top.S.container.GetComponent<Rigidbody2D>();
            Bottom.S.rigid = Bottom.S.container.GetComponent<Rigidbody2D>();
            Top.S.transform.parent = Top.S.container.transform;
            Bottom.S.transform.parent = Bottom.S.container.transform;
            Top.S.fire.gameObject.SetActive(true);
            Bottom.S.transform.position = Whole.S.transform.position;
            Destroy(Whole.S.gameObject);
            //Split Jump
            Top.S.rigid.velocity = new Vector2(Top.S.rigid.velocity.x, splitJumpSpeed);
        }
        //Join
        else
        {
            if (Top.S.grounded && Bottom.S.grounded && (Top.S.container.transform.position - Bottom.S.container.transform.position).magnitude < 1f)
            {
                UI.S.together = !UI.S.together;
                UI.S.PlaySound("Jump");
                whole = Instantiate(wholePrefab, Top.S.container.transform.position, Quaternion.identity) as GameObject;
                Top.S.transform.parent = Bottom.S.transform.parent = whole.transform;
                Destroy(Top.S.container.gameObject);
                Destroy(Bottom.S.container.gameObject);
                Top.S.rigid = Whole.S.rigid;
                Top.S.fire.gameObject.SetActive(false);
            }
            else
            {
                UI.S.PlaySound("Reject");
            }
        }
    }
    public IEnumerator Flash()
    {
        for(int i = 0; i < 3; ++i)
        {
            sr.color = Color.red;
            yield return new WaitForSeconds(.3f);
            sr.color = Color.white;
            yield return new WaitForSeconds(.3f);
        }
    }
}
