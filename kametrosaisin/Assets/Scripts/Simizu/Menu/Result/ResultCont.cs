using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultCont : MonoBehaviour
{
    private GameMainContol gameMainContol;
    private Text cont;
    private float clearcont;
    private string contRank;
    public int cscore;
    private void Awake()
    {
        cont = this.GetComponent<Text>();
        clearcont = gameMainContol.gameOverCount;
        Rank();
    }
    // Start is called before the first frame update
    void Start()
    {
        cont.text = clearcont.ToString() + "    " + contRank;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void Rank()
    {
        if(clearcont == 0)
        {
            contRank = "S";
            cscore = 4;
        }
        if (clearcont < 3 && clearcont > 0)
        {
            contRank = "A";
            cscore = 3;
        }
        if (clearcont < 6 && clearcont > 2)
        {
            contRank = "B";
            cscore = 2;
        }
        if (clearcont >= 6)
        {
            contRank = "C";
            cscore = 1;
        }
    }
}
