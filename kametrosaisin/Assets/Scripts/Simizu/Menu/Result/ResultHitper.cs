using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultHitper : MonoBehaviour
{
    private GameMainContol gameMainContol;
    private Text hitper;
    private float clearhit;
    private float clearb_atk;
    private float clearhitper;
    private string hitperRank;
    public int hscore;
    private void Awake()
    {
        hitper = this.GetComponent<Text>();
        clearhitper = clearhit / clearb_atk * 100;
        Rank();
    }
    // Start is called before the first frame update
    void Start()
    {
        //テキスト表示
        hitper.text = "命中率    " + clearhitper.ToString() + "    " + hitperRank;
    }
    private void Rank()
    {
        //ランク決定、総合ランク用スコア
        if (clearhitper >= 80)
        {
            hitperRank = "S";
            hscore = 4;
        }
        if (clearhitper >= 60 && clearhitper < 80)
        {
            hitperRank = "A";
            hscore = 3;
        }
        if (clearhitper >= 40 && clearhitper < 60)
        {
            hitperRank = "B";
            hscore = 2;
        }
        if (clearhitper < 40 )
        {
            hitperRank = "C";
            hscore = 1;
        }
    }
}
