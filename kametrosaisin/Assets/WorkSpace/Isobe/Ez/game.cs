using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class game : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnCilck()
    {
        Debug.Log("終了");
        //ゲーム終了
        //Unityエディタ（開発環境）でゲームを実行している場合
        UnityEditor.EditorApplication.isPlaying = false;
        
        //スタンドアロンで実行している場合
        Application.Quit();
    }
}
