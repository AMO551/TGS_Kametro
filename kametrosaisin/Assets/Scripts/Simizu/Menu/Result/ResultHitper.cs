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
        //¡“K“–‚Èhitcount’u‚¢‚Ä‚é‚¯‚Ç‚±‚±‚É’Ç‰Á‚µ‚½‚â‚Â
        //clearhit = gameMainContol.hitcount;
        //clearb_hit = gameMainContol.b_atkcount;
        clearhitper = clearhit / clearb_atk * 100;
        Rank();
    }
    // Start is called before the first frame update
    void Start()
    {
        hitper.text = "–½’†—¦    " + clearhitper.ToString() + "    " + hitperRank;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void Rank()
    {
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
