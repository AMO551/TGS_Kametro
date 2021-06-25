using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverText : MonoBehaviour
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
            Debug.Log("-290");
            //矢印上の位置へ
            pos.localPosition = new Vector3(-470, -290, 0);

        }
        //上入力
        if (dpv > 0 || kv > 0)
        {
            Debug.Log("-90");
            //矢印下の位置へ
            pos.localPosition = new Vector3(-470, -90, 0);

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
            //-90ifの条件を追加予定
            if (pos.localPosition.y == -90)
            {
                //ダンジョンの最初から用
                SceneManager.LoadScene("tutorial");
                goNextScene = true;
            }
            if (pos.localPosition.y == -90)
            {
                //ステージ１から用
                SceneManager.LoadScene("first half");
                goNextScene = true;
            }
            if (pos.localPosition.y == -90)
            {
                //ステージ２から用
                SceneManager.LoadScene("second half");
                goNextScene = true;
            }
            if (pos.localPosition.y == -90)
            {
               //ボス戦から用
                SceneManager.LoadScene("bos half");
                goNextScene = true;
            }
            if (pos.localPosition.y == -290)
            {
                SceneManager.LoadScene("title");
                goNextScene = true;
            }
        }
    }
}
