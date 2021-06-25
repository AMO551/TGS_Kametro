using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlockGauge : MonoBehaviour
{
    private GameObject img;
    private float timer = 0.0f;
    private float interval = 0.1f;
    private float gauge = 1;
    GameObject[] tagObjects;
    // Start is called before the first frame update
    void Start()
    {
        img = GameObject.Find("gauge");
    }
    
    // Update is called once per frame
    void Update()
    {
       
        timer += Time.deltaTime;
        if(timer > interval)
        {
            Gauge();
            //Debug.Log("reset");
            timer = 0.0f;
        }
    }
   private void Gauge()
   {
        //Debug.Log("yobaeta");
        tagObjects = GameObject.FindGameObjectsWithTag("Block");
        var block = tagObjects.Length;
        tagObjects = GameObject.FindGameObjectsWithTag("rfBlock");
        var rfblock = tagObjects.Length;
        tagObjects = GameObject.FindGameObjectsWithTag("wgBlock");
        var wgblock = tagObjects.Length;
        tagObjects = GameObject.FindGameObjectsWithTag("exBlock");
        var exblock = tagObjects.Length;
        var blocks = block + rfblock + wgblock + exblock;
        //Debug.Log(blocks);
        //img.GetComponent<Image>().fillAmount = gauge - timer / 25;
        //gauge = img.GetComponent<Image>().fillAmount;
        if (blocks == 0)
        {
            img.GetComponent<Image>().fillAmount = gauge + timer / 10;
        }
        if (blocks == 1)
        {
            img.GetComponent<Image>().fillAmount = gauge - timer / 25;
            gauge = img.GetComponent<Image>().fillAmount;
        }
        if (blocks == 2)
        {
            img.GetComponent<Image>().fillAmount = (float)(gauge - timer / 16.7);
            gauge = img.GetComponent<Image>().fillAmount;
        }
        if (blocks == 3)
        {
            img.GetComponent<Image>().fillAmount = gauge - timer / 10;
            gauge = img.GetComponent<Image>().fillAmount;
        }
        if (blocks == 4)
        {
            img.GetComponent<Image>().fillAmount = gauge - timer / 4;
            gauge = img.GetComponent<Image>().fillAmount;
        }
        if (blocks == 5)
        {
            img.GetComponent<Image>().fillAmount = (float)(gauge - timer * 1.4);
            gauge = img.GetComponent<Image>().fillAmount;
        }
    }
}
