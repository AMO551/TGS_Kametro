using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class StoryText : MonoBehaviour
{
    [SerializeField] List<string> messageList = new List<string>();//��b�����X�g
    [SerializeField] Text text;
    [SerializeField] float novelSpeed;//�ꕶ���ꕶ���̕\�����鑬��
    int novelListIndex = 0; //���ݕ\�����̉�b���̔z��
 
    private bool NextText=true;
    void Start()
    {
        StartCoroutine(Novel());
    }

    private void Update()
    {
        if (Input.GetKeyDown("joystick button 3")&& !NextText&& (novelListIndex < messageList.Count))//�S�Ẳ�b��\��������
        {
            NextText = true;
            StartCoroutine(Novel());
        }
        else
        if (Input.GetKeyDown("joystick button 3") && !NextText && !(novelListIndex < messageList.Count))//�S�Ẳ�b��\��������
        {
         
            //�V�[���̐؂�ւ�
            if (GameMainContol.Instance.setscenes()==1)
            {
                SceneManager.LoadScene("Tutorial");
            }
            else
            if (GameMainContol.Instance.setscenes() == 2)
            {
                SceneManager.LoadScene("first half");
            }
        }

    }
    private IEnumerator Novel()
    {
       
                int messageCount = 0; //���ݕ\�����̕�����
                text.text = ""; //�e�L�X�g�̃��Z�b�g
                while (messageList[novelListIndex].Length > messageCount)//���������ׂĕ\�����Ă��Ȃ��ꍇ���[�v
                {
                    text.text += messageList[novelListIndex][messageCount];//�ꕶ���ǉ�
                    messageCount++;//���݂̕�����
                    yield return new WaitForSeconds(novelSpeed);//�C�ӂ̎��ԑ҂�
                }

                novelListIndex++; //���̉�b���z��
                NextText = false;
    }
}
