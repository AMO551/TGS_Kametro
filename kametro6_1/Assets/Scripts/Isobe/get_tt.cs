using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class get_tt : MonoBehaviour
{
    private Image image = null;
    private float time;
    [SerializeField]
    //private float time_rt=10;
    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
        image.fillAmount = 0;
    }


    // Update is called once per frame
    void Update()
    {

        time = Time.deltaTime;
        //if(time>time_rt)
        //{
        //    SceneManager.LoadScene("Tutorial");
        //}
        image.fillAmount += 0.1f * time;
        if(image.fillAmount==1)
        {
            SceneManager.LoadScene("Tutorial");
        }
    }
}
