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
    //�������������珈�����s����
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Player�̃^�O�̂����������������Ƃ��ɏ��������
        if (collision.gameObject.CompareTag("Player"))
        {
            //�V�[����Tutorial�Ƃ������O�������珈�������
            if (SceneManager.GetActiveScene().name == "Tutorial")
            {
                StartCoroutine("test");
                GameMainContol.Instance.scenes_contol(2);
                //first half�Ƃ����V�[���ɐ؂�ւ���
                SceneManager.LoadScene("first half");
                timecontrol = Time.time;

                //�V�[����first half�Ƃ������O�������珈�������
                if (SceneManager.GetActiveScene().name == "first half")
                {
                    StartCoroutine("test");

                    GameMainContol.Instance.scenes_contol(3);
                    //second half�Ƃ����V�[���ɐ؂�ւ���
                    //SceneManager.LoadScene("second half");
                    SceneManager.LoadScene("second half");
                }

                //�V�[����second half�Ƃ������O�������珈�������
                if (SceneManager.GetActiveScene().name == "second half")
                {
                    StartCoroutine("test");
                    GameMainContol.Instance.scenes_contol(4);
                    //Safe half�Ƃ����V�[���ɐ؂�ւ���
                    SceneManager.LoadScene("Safe half");
                }

                //�V�[����Safe half�Ƃ������O�������珈�������
                if (SceneManager.GetActiveScene().name == "Safe Zone")
                {
                    //bos half�Ƃ����V�[���ɐ؂�ւ���
                    SceneManager.LoadScene("bos half");
                }
            }



        }
        IEnumerator test()
        {
            yield return new WaitForSeconds(2);
            //�V�[����Tutorial�Ƃ������O�������珈�������
            if (SceneManager.GetActiveScene().name == "Tutorial")
            {
                GameMainContol.Instance.scenes_contol(2);
            }

            //�V�[����first half�Ƃ������O�������珈�������
            if (SceneManager.GetActiveScene().name == "first half")
            {
                GameMainContol.Instance.scenes_contol(3);
            }

            //�V�[����second half�Ƃ������O�������珈�������
            if (SceneManager.GetActiveScene().name == "second half")
            {
                GameMainContol.Instance.scenes_contol(4);
            }
        }
    }
}

