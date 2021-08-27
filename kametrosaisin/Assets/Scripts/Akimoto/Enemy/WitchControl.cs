using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WitchControl : MonoBehaviour
{
    #region 宣言
    public int Witch_HP = 2;
    public bool shotflag = false;
    private float nowPosi;
    private float nowPosition;
    public float x_Coordinate;
    public float y_Coordinate;
    private float playerPosition;
    public GameObject player;
    public GameObject W_a;
    private float targetTime = 5.0f;
    private float currentTime = 0;
    public Transform canvasTransform;
    TriggerControl triggerControl;
    public GameObject Area;
    public Animator animator;
    Vector2 scale;
    private float witch_attack_se_count = 1;
    [SerializeField]
    private bool Freeze = false;
    #endregion
    void Start()
    {
        nowPosition = this.transform.position.x;
        nowPosi = this.transform.position.y;
        triggerControl = Area.GetComponent<TriggerControl>();
        scale = this.transform.localScale;
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (!(Freeze))
        {
            playerPosition = player.transform.position.x;
            transform.position = new Vector3(transform.position.x, nowPosi + Mathf.PingPong(Time.time * 10, 10f) * 50, transform.position.z);
            if (triggerControl.InArea == true)
            {
                currentTime += Time.deltaTime;
                if (targetTime < currentTime)
                {
                    animator.SetBool("Attack", true);
                    currentTime = 0;
                    witch_attack_se_count = 0;
                    var pos = this.gameObject.transform.position;
                    Vector2 vec = player.transform.position - pos;
                    var t = Instantiate(W_a, canvasTransform) as GameObject;
                    if (vec.x <= 0)
                    {
                        pos = new Vector3(this.gameObject.transform.position.x - 100, this.gameObject.transform.position.y, this.gameObject.transform.position.z);
                    }
                    if (vec.x >= 0)
                    {
                        pos = new Vector3(this.gameObject.transform.position.x + 100, this.gameObject.transform.position.y, this.gameObject.transform.position.z);
                    }
                    t.transform.position = pos;
                    vec = player.transform.position - pos;
                    //Debug.Log(vec);
                    t.GetComponent<Rigidbody2D>().velocity = vec;
                }
            }
            else
            {
                animator.SetBool("Attack", false);
            }

            if (playerPosition > nowPosition)
            {
                scale = new Vector2(-100.0f, scale.y);
                gameObject.transform.localScale = scale;
            }
            if (playerPosition < nowPosition)
            {
                scale = new Vector2(100.0f, scale.y);
                gameObject.transform.localScale = scale;
            }
            if (witch_attack_se_count == 0)
            {
                SoundManager.Instance.Play_SE(1, 12);
                witch_attack_se_count += 1;
            }
            //if(this.gameObject.transform.position.x+10>=W_a.gameObject.transform.position.x|| this.gameObject.transform.position.x- 10 <= W_a.gameObject.transform.position.x)
            //{

            //    this.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            //    Freeze = true;
            //}
        }
    }
    //氷弾が当たったとき
    public void freeze()
    {
        this.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        Freeze = true;
    }
    //ブロックダメージ
    public void dame()
    {

        Witch_HP -= 1;
        //データを渡す処理を行う
        SoundManager.Instance.Play_SE(0, 11);
        //Debug.Log("ボマーダメージ");
        if (Witch_HP <= 0)
        {
           // Debug.Log("ボマー死亡");
            Destroy(gameObject, 0.5f);    //Destructor
        }


    }
}
