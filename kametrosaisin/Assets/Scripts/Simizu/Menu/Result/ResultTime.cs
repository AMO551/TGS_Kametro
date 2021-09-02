using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultTime : MonoBehaviour
{
    private scenechange scenechange;
    private Text time;
    private float cleartime;
    private string timeRank;
    public int tscore;
    private void Awake()
    {
        time = this.GetComponent<Text>();
        cleartime = Time.time - scenechange.timecontrol;
        Rank();
    }
    // Start is called before the first frame update
    void Start()
    {
        time.text = "クリアタイム    " + cleartime.ToString() + "    " + timeRank;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(Time.time);
    }
    private void Rank()
    {
        if(cleartime < 600)
        {
            timeRank = "S";
            tscore = 4;
        }
        if (cleartime < 1200 && cleartime >= 600)
        {
            timeRank = "A";
            tscore = 3;
        }
        if (cleartime < 1800 && cleartime >= 1200)
        {
            timeRank = "B";
            tscore = 2;
        }
        if (cleartime >= 1800)
        {
            timeRank = "C";
            tscore = 1;
        }
    }
}
