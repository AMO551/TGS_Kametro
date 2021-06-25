using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JewelDisplay : MonoBehaviour
{
    private GameObject reflection;
    private GameObject weight;
    private GameObject explosion;
    private Text rfText;
    private Text wgText;
    private Text exText;
    private float judge = 0;

    private void Awake()
    {
        reflection = transform.Find("reflection").gameObject;
        weight = transform.Find("weight").gameObject;
        explosion = transform.Find("explosion").gameObject;
        rfText = transform.Find("reflection/rfText").gameObject.GetComponent<Text>();
        wgText = transform.Find("weight/wgText").gameObject.GetComponent<Text>();
        exText = transform.Find("explosion/exText").gameObject.GetComponent<Text>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        //--•óÎØ‚è‘Ö‚¦--
        //L
        if(Input.GetKeyDown("joystick button 4") || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            //rf¨
            if(judge == 0)
            {
                //‚±‚±‚Å•óÎ‚Ì”‚ğæ“¾‚·‚é—\’è

                reflection.gameObject.SetActive(false);
                explosion.gameObject.SetActive(true);
                //exText.text = "";
                judge = 1;
            }
            //ex¨
            else if (judge == 1)
            {
                //‚±‚±‚Å•óÎ‚Ì”‚ğæ“¾‚·‚é—\’è

                explosion.gameObject.SetActive(false);
                weight.gameObject.SetActive(true);
                //wgText.text = "";
                judge = 2;
            }
            //wg¨
            else if(judge == 2)
            {
                //‚±‚±‚Å•óÎ‚Ì”‚ğæ“¾‚·‚é—\’è

                weight.gameObject.SetActive(false);
                reflection.gameObject.SetActive(true);
                //rfText.text = "";
                judge = 0;
            }
        }
        //R
        if (Input.GetKeyDown("joystick button 5") || Input.GetKeyDown(KeyCode.RightArrow))
        {
            //rf¨
            if(judge == 0)
            {
                //‚±‚±‚Å•óÎ‚Ì”‚ğæ“¾‚·‚é—\’è

                reflection.gameObject.SetActive(false);
                weight.gameObject.SetActive(true);
                //wgText.text = "";
                judge = 2;
            }
            //wg¨
            else if (judge == 2)
            {
                //‚±‚±‚Å•óÎ‚Ì”‚ğæ“¾‚·‚é—\’è

                weight.gameObject.SetActive(false);
                explosion.gameObject.SetActive(true);
                //exText.text = "";
                judge = 1;
            }
            //ex¨
            else if (judge == 1)
            {
                //‚±‚±‚Å•óÎ‚Ì”‚ğæ“¾‚·‚é—\’è

                explosion.gameObject.SetActive(false);
                reflection.gameObject.SetActive(true);
                //rfText.text = "";
                judge = 0;
            }
        }
    }
}
