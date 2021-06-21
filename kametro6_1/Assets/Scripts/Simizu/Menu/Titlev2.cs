using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Titlev2 : MonoBehaviour
{
    [Header("フェード")] public Fade fade;
    private bool goNextScene = false;
    private float pos_y;
   
    private void Update()
    {
        //recttransformを取得
        RectTransform pos;
        pos = GetComponent<RectTransform>();
        //D-Pad-vertical
        float dpv = Input.GetAxis("Pad_Vertical");
        //デバッグ用 key-vertical
        float kv = Input.GetAxis("Vertical");
        //下入力
        if (dpv < 0 || kv < 0)
        {
            Debug.Log("-360");
            //矢印上の位置へ
            pos.localPosition = new Vector3(-330, -360, 0);
            
        }
        //上入力
        if(dpv > 0 || kv > 0)
        {
            Debug.Log("-180");
            //矢印下の位置へ
            pos.localPosition = new Vector3(-330, -180, 0);
           
        }
        //とりあえず仮置きの決定ボタン
        if (Input.GetKeyDown("joystick button 1") || Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("入力さえた");
            //フェードアウトスタート
            fade.StartFadeOut();
        }
        //画面遷移
        if (fade.IsFadeOutComplete() && !goNextScene)
        {
            if (pos.localPosition.y == -180)
            {
                SceneManager.LoadScene("Tutorial");
                goNextScene = true;
            }
            if (pos.localPosition.y == -360)
            {
                SceneManager.LoadScene("first half");
                goNextScene = true;
            }
        }
    }
}
