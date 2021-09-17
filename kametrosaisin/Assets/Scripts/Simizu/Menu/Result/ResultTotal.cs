using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultTotal : MonoBehaviour
{
    private ResultTime resultTime;
    private ResultCont resultCont;
    private ResultHitper resultHitper;
    private Text total;
    private string totalRank;
    private void Awake()
    {
        total = this.GetComponent<Text>();
        Rank();
    }
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(totalRank);
        Debug.Log("a");
        //�e�L�X�g�\��
        total.text = "�R���e�B�j���[��    " + totalRank;
    }
    private void Rank()
    {
        //�����N����A���������N�p�X�R�A
        var score = resultTime.tscore + resultCont.cscore + resultHitper.hscore;
        if(score >= 11)
        {
            totalRank = "S";
        }
        if (score >= 8 && score < 11)
        {
            totalRank = "A";
        }
        if (score >= 5 && score < 8)
        {
            totalRank = "B";
        }
        if (score <= 4)
        {
            totalRank = "C";
        }
    }
}