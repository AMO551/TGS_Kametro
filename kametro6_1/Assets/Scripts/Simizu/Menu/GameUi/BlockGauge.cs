using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlockGauge : MonoBehaviour
{
    #region �錾
    [SerializeField]
    private GameObject Block;
    [SerializeField]
    private GameMainContol gameMainContol;
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
        gauge = GameMainContol.Instance.blockmeta;
        timer += Time.deltaTime;
        if (timer > interval)
        {
            Gauge();
            //Debug.Log("reset");
            timer = 0.0f;
        }
        //�u���b�N�̑O�j�󏈗�
        if (img.GetComponent<Image>().fillAmount <= 0.01f/*&&Block_GA*/)
        {

            foreach (Transform child in Block.transform)
            {
                Destroy(child.gameObject);
            }
           // Block_GA = false;
        }
        GameMainContol.Instance.blockmeta = gauge;

    }
    //�u���b�N����
    private void Gauge()
    {
        #region �u���b�N�錾
        //Debug.Log("yobaeta");�@
        tagObjects = GameObject.FindGameObjectsWithTag("Block");
        var block = tagObjects.Length;
        tagObjects = GameObject.FindGameObjectsWithTag("rfBlock");
        var rfblock = tagObjects.Length;
        tagObjects = GameObject.FindGameObjectsWithTag("wgBlock");
        var wgblock = tagObjects.Length;
        tagObjects = GameObject.FindGameObjectsWithTag("exBlock");
        var exblock = tagObjects.Length;
        var blocks = block + rfblock + wgblock + exblock;
        #endregion
        #region �u���b�N��
        //0��
        if (blocks == 0)
        {
            img.GetComponent<Image>().fillAmount = gauge + timer * 0.1f;
            gauge = img.GetComponent<Image>().fillAmount;
            // Block_GA = true;
        }
        else    //1��
        if (blocks == 1)
        {
            img.GetComponent<Image>().fillAmount = gauge - timer / 25;
            gauge = img.GetComponent<Image>().fillAmount;

        }
        else    //2��
        if (blocks == 2)
        {
            img.GetComponent<Image>().fillAmount = (float)(gauge - timer / 16.7);
            gauge = img.GetComponent<Image>().fillAmount;

        }
        else    //3��
        if (blocks == 3)
        {
            img.GetComponent<Image>().fillAmount = gauge - timer / 10;
            gauge = img.GetComponent<Image>().fillAmount;

        }
        else    //4��
        if (blocks == 4)
        {
            img.GetComponent<Image>().fillAmount = gauge - timer / 8;
            gauge = img.GetComponent<Image>().fillAmount;

        }
        else    //5��
        if (blocks >= 5)
        {
            img.GetComponent<Image>().fillAmount = (float)(gauge - timer / 3);
            gauge = img.GetComponent<Image>().fillAmount;

        }
        #endregion
    }

}
