using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class StoryText : MonoBehaviour
{
    [SerializeField] List<string> messageList = new List<string>();//会話文リスト
    [SerializeField] Text text;
    [SerializeField] float novelSpeed;//一文字一文字の表示する速さ
    int novelListIndex = 0; //現在表示中の会話文の配列
 
    private bool NextText=true;
    void Start()
    {
        StartCoroutine(Novel());
    }

    private void Update()
    {
        if (Input.GetKeyDown("joystick button 3")&& !NextText&& (novelListIndex < messageList.Count))//全ての会話を表示したか
        {
            NextText = true;
            StartCoroutine(Novel());
        }
        else
        if (Input.GetKeyDown("joystick button 3") && !NextText && !(novelListIndex < messageList.Count))//全ての会話を表示したか
        {
         
            //シーンの切り替え
            if (GameMainContol.Instance.setscenes()==1)
            {
                SceneManager.LoadScene("Tutorial");
            }
            else
            if (GameMainContol.Instance.setscenes() == 2)
            {
                SceneManager.LoadScene("first half");
            }
        }

    }
    private IEnumerator Novel()
    {
       
                int messageCount = 0; //現在表示中の文字数
                text.text = ""; //テキストのリセット
                while (messageList[novelListIndex].Length > messageCount)//文字をすべて表示していない場合ループ
                {
                    text.text += messageList[novelListIndex][messageCount];//一文字追加
                    messageCount++;//現在の文字数
                    yield return new WaitForSeconds(novelSpeed);//任意の時間待つ
                }

                novelListIndex++; //次の会話文配列
                NextText = false;
    }
}
