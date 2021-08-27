using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button : MonoBehaviour
{
    public RectTransform rectTransform;
    //public Button button;
    // Update is called once per frame
    [SerializeField]
    Titlev2 titlev2;
    void Update()
    {
         
    }
    public void OnClick()
    {
        Debug.Log("Click");
        rectTransform.localPosition = new Vector3 (0,-19,0);
        titlev2.mane = false;
    }
  
}
