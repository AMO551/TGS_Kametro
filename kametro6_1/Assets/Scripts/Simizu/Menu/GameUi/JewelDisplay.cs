using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JewelDisplay : MonoBehaviour
{
    #region 宣言
    [SerializeField]
    private GameMainContol gameMainContol;
    private GameObject reflection;
    private GameObject weight;
    private GameObject explosion;
    private Text rfText;
    private Text wgText;
    private Text exText;
    private float judge = 0;
    #endregion
    //Awake
    private void Awake()
    {
        reflection = transform.Find("reflection").gameObject;
        weight = transform.Find("weight").gameObject;
        explosion = transform.Find("explosion").gameObject;
        rfText = transform.Find("reflection/rfText").gameObject.GetComponent<Text>();
        wgText = transform.Find("weight/wgText").gameObject.GetComponent<Text>();
        exText = transform.Find("explosion/exText").gameObject.GetComponent<Text>();
    }
    //Update
    void Update()
    {
        //rf→
        if (judge == 0)
        {
            //ここで宝石の数を取得する予定
            explosion.gameObject.SetActive(false);
            weight.gameObject.SetActive(false);
            reflection.gameObject.SetActive(true);
            rfText.text = string.Format("{0}", gameMainContol.reflectcrystalCount);


        }
        //ex→
        else if (judge == 1)
        { //ここで宝石の数を取得する予定

            reflection.gameObject.SetActive(false);
            weight.gameObject.SetActive(false);
            explosion.gameObject.SetActive(true);
            exText.text = string.Format("{0}", gameMainContol.explosioncrystalCount);
           
        
        }
        //wg→
        else if (judge == 2)
        {
            //ここで宝石の数を取得する予定
            reflection.gameObject.SetActive(false);
            explosion.gameObject.SetActive(false);
            weight.gameObject.SetActive(true);
            wgText.text = string.Format("{0}", gameMainContol.gravitycrystalCount);
           
        }
        //--宝石切り替え--
        //L
        if (Input.GetKeyDown("joystick button 4") || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            //rf→
            if(judge == 0)
            {
                //ここで宝石の数を取得する予定

               
                judge = 1;
            }
            //ex→
            else if (judge == 1)
            {
                //ここで宝石の数を取得する予定

               
                judge = 2;
            }
            //wg→
            else if(judge == 2)
            {
                //ここで宝石の数を取得する予定

               
                judge = 0;
            }
        }
        //R
        if (Input.GetKeyDown("joystick button 5") || Input.GetKeyDown(KeyCode.RightArrow))
        {
            //rf→
            if(judge == 0)
            {
                //ここで宝石の数を取得する予定

               
                judge = 2;
            }
            //wg→
            else if (judge == 2)
            {
                //ここで宝石の数を取得する予定

               
                judge = 1;
            }
            //ex→
            else if (judge == 1)
            {
                //ここで宝石の数を取得する予定

               
                judge = 0;
            }
        }
    }
}
