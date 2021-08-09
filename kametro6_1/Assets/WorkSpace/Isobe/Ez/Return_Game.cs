using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Return_Game : MonoBehaviour
{
    //チュートリアル
    [SerializeField]
    Titlev2 titlev2;
    [SerializeField]
    public RectTransform rectTransform;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnClick()
    {
        Debug.Log("Click");
        rectTransform.localPosition = new Vector3(0, -900, 0);
        titlev2.mane = true;

    }
}
