using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class scenechange : MonoBehaviour
{
    public float timecontrol;
    private void Start()
    {
        // DontDestroyOnLoad(gameObject);
    }
    //何か当たったら処理が行われる
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Playerのタグのついた物が当たったときに処理される
        if (collision.gameObject.CompareTag("Player"))
        {
            //シーンがTutorialという名前だったら処理される
            if (SceneManager.GetActiveScene().name == "Tutorial")
            {
                StartCoroutine("test");
                GameMainContol.Instance.scenes_contol(2);
                //first halfというシーンに切り替える
                SceneManager.LoadScene("first half");
                timecontrol = Time.time;

                //シーンがfirst halfという名前だったら処理される
                if (SceneManager.GetActiveScene().name == "first half")
                {
                    StartCoroutine("test");

                    GameMainContol.Instance.scenes_contol(3);
                    //second halfというシーンに切り替える
                    //SceneManager.LoadScene("second half");
                    SceneManager.LoadScene("second half");
                }

                //シーンがsecond halfという名前だったら処理される
                if (SceneManager.GetActiveScene().name == "second half")
                {
                    StartCoroutine("test");
                    GameMainContol.Instance.scenes_contol(4);
                    //Safe halfというシーンに切り替える
                    SceneManager.LoadScene("Safe half");
                }

                //シーンがSafe halfという名前だったら処理される
                if (SceneManager.GetActiveScene().name == "Safe Zone")
                {
                    //bos halfというシーンに切り替える
                    SceneManager.LoadScene("bos half");
                }
            }



        }
        IEnumerator test()
        {
            yield return new WaitForSeconds(2);
            //シーンがTutorialという名前だったら処理される
            if (SceneManager.GetActiveScene().name == "Tutorial")
            {
                GameMainContol.Instance.scenes_contol(2);
            }

            //シーンがfirst halfという名前だったら処理される
            if (SceneManager.GetActiveScene().name == "first half")
            {
                GameMainContol.Instance.scenes_contol(3);
            }

            //シーンがsecond halfという名前だったら処理される
            if (SceneManager.GetActiveScene().name == "second half")
            {
                GameMainContol.Instance.scenes_contol(4);
            }
        }
    }
}

