using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Text_text : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        switch (GameMainContol.Instance.setscenes())
        {
            case 1:
                this.GetComponent<Text>().text = "チュートリアル";
                break;
            case 2:
                this.GetComponent<Text>().text = "ステージ  １";
                break;
            case 3:
                this.GetComponent<Text>().text = "ステージ  ２";
                break;
            case 4:
                this.GetComponent<Text>().text = "ボス戦";
                break;
            case 5:
                this.GetComponent<Text>().text = "チュートリアル";
                break;

        }
    }
}
