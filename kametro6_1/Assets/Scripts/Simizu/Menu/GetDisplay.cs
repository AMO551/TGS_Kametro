using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetDisplay : MonoBehaviour
{
    [SerializeField]
    private GameObject getdisplay;

    private Text gettext;
    private GameObject reflection;
    private GameObject weight;
    private GameObject explosion;
    private bool test = false;
    private void Awake()
    {
        //gettext = GameObject.Find("GetDisplay").gameObject.GetComponent<Text>();
        //reflection = GameObject.Find("GetDisplay/rf").gameObject;
        //weight = GameObject.Find("GetDisplay/wg").gameObject;
        //explosion = GameObject.Find("GetDisplay/ex").gameObject;
    }
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        //ここに宝石を取得したかどうかを書く

        //if内は仮置き
        if(!test)
        {
            //反射宝石取得
            Debug.Log("haitta");
            //test = true;
            Instantiate<GameObject>(getdisplay, transform);
            //reflection.gameObject.SetActive(true);
            //gettext.text = "反射のスキル宝石 ×１";
            StartCoroutine("Texthide");
        }
        if(!test)
        {
            //重量宝石取得
            test = true;
            Instantiate<GameObject>(getdisplay, transform);
            //weight.gameObject.SetActive(true);
            //gettext.text = "重量のスキル宝石 ×１";
            StartCoroutine("Texthide");
        }
        if(!test)
        {
            //爆発宝石取得
            test = true;
            Instantiate<GameObject>(getdisplay, transform);
            explosion.gameObject.SetActive(true);
            gettext.text = "爆発のスキル宝石 ×１";
            StartCoroutine("Texthide");
        }
        ////二周目
        //if (test)
        //{
        //    //反射宝石取得
        //    //Debug.Log("haitta");
        //    test = true;
        //    Instantiate<GameObject>(getdisplay, transform);
        //    reflection.gameObject.SetActive(true);
        //    gettext.text = "反射のスキル宝石 ×１";
        //    StartCoroutine("Texthide");
        //}
        //if (test)
        //{
        //    //重量宝石取得
        //    test = true;
        //    Instantiate<GameObject>(getdisplay, transform);
        //    weight.gameObject.SetActive(true);
        //    gettext.text = "重量のスキル宝石 ×１";
        //    StartCoroutine("Texthide");
        //}
        //if (test)
        //{
        //    //爆発宝石取得
        //    test = true;
        //    Instantiate<GameObject>(getdisplay, transform);
        //    explosion.gameObject.SetActive(true);
        //    gettext.text = "爆発のスキル宝石 ×１";
        //    StartCoroutine("Texthide");
        //}
    }
    private IEnumerator Texthide()
    {
        //Debug.Log("コルーチン");
        //5秒表示
        yield return new WaitForSeconds(5.0f);

        foreach(Transform item in this.transform)
        {
            item.gameObject.SetActive(false);
        }
    }
}
