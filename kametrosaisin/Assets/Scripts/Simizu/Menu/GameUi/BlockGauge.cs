using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlockGauge : MonoBehaviour
{
    #region 宣言
    [SerializeField]
    private GameObject Block;
    [SerializeField]
    private GameMainContol gameMainContol;
    [SerializeField]
    private float zeroBGauge;
    [SerializeField]
    private float oneBGauge;
    [SerializeField]
    private float twoBGauge;
    [SerializeField]
    private float threeBGauge;
    [SerializeField]
    private float fourBGauge;
    [SerializeField]
    private float fiveBGauge;
    [SerializeField]
    private int block;
    private GameObject img;
    private float timer = 0.0f;
    private float interval = 0.1f;
    private float gauge = 1;
    GameObject[] tagObjects;
    #endregion
    // Start
    void Start()
    {
        img = GameObject.Find("gauge");
    }
    // Update
    void Update()
    {
        //gauge = GameMainContol.Instance.blockmeta;
        timer += Time.deltaTime;
        if (timer > interval)
        {
            Gauge();
            //Debug.Log("reset");
            timer = 0.0f;
        }

        //ブロックの前破壊処理
        if (img.GetComponent<Image>().fillAmount <= 0.01f/*&&Block_GA*/)
        {

            foreach (Transform child in Block.transform)
            {
                if(child.gameObject.tag=="Block")
                Destroy(child.gameObject);
            }
            // Block_GA = false;
        }
        GameMainContol.Instance.blockmeta = gauge;



    }
    //ブロック処理
    private void Gauge()
    {
        #region ブロック宣言
        //Debug.Log("yobaeta");　
        tagObjects = GameObject.FindGameObjectsWithTag("Block");
         block = tagObjects.Length;
        //tagObjects = GameObject.FindGameObjectsWithTag("rfBlock");
        //var rfblock = tagObjects.Length;
        //tagObjects = GameObject.FindGameObjectsWithTag("wgBlock");
        //var wgblock = tagObjects.Length;
        //tagObjects = GameObject.FindGameObjectsWithTag("exBlock");
        //var exblock = tagObjects.Length;
        var blocks = block;
        #endregion
        #region ブロック数
        //0個
        if (blocks == 0)
        {
            img.GetComponent<Image>().fillAmount = gauge + zeroBGauge * Time.deltaTime;
            gauge = img.GetComponent<Image>().fillAmount;
            // Block_GA = true;
        }
        else    //1個
        if (blocks == 1)
        {
            img.GetComponent<Image>().fillAmount = gauge - oneBGauge * Time.deltaTime;
            gauge = img.GetComponent<Image>().fillAmount;

        }
        else    //2個
        if (blocks == 2)
        {
            img.GetComponent<Image>().fillAmount = (float)gauge - twoBGauge * Time.deltaTime;
            gauge = img.GetComponent<Image>().fillAmount;

        }
        else    //3個
        if (blocks == 3)
        {
            img.GetComponent<Image>().fillAmount = gauge - threeBGauge*Time.deltaTime;
            gauge = img.GetComponent<Image>().fillAmount;

        }
        else    //4個
        if (blocks == 4)
        {
            img.GetComponent<Image>().fillAmount = gauge - (fourBGauge * Time.deltaTime);
            gauge = img.GetComponent<Image>().fillAmount;

        }
        else    //5個
        if (blocks >= 5)
        {
            img.GetComponent<Image>().fillAmount = (float)gauge - (fiveBGauge * Time.deltaTime);
            gauge = img.GetComponent<Image>().fillAmount;

        }
        #endregion
    }

}
