using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class siyuukai : MonoBehaviour
{

    [Header("フェード")] public Fade fade;
    private bool goNextScene = false;
    private float pos_y;
    [SerializeField]
    GameMainContol gameMainContol;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //recttransformを取得
        RectTransform pos;
        pos = GetComponent<RectTransform>();
        //D-Pad-vertical
        // float dpv = Input.GetAxis("Pad_Vertical");
        //デバッグ用 key-vertical
        float kv = Input.GetAxis("Vertical");

        //とりあえず仮置きの決定ボタン
        if (Input.GetKeyDown("joystick button 1") || Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("入力さえた");
            //フェードアウトスタート
            fade.StartFadeOut();
        }
        if (fade.IsFadeOutComplete() && !goNextScene)
        {
            if (pos.localPosition.y == -360)
            {
                SceneManager.LoadScene("title");
                goNextScene = true;
            }
        }
    }
        
}
