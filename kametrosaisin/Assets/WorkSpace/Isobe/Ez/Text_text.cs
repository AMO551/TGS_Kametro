using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Text_text : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        switch (GameMainContol.Instance.setscenes())
        {
            case 1:
                this.GetComponent<Text>().text = "�`���[�g���A��";
                break;
            case 2:
                this.GetComponent<Text>().text = "�X�e�[�W  �P";
                break;
            case 3:
                this.GetComponent<Text>().text = "�X�e�[�W  �Q";
                break;
            case 4:
                this.GetComponent<Text>().text = "�{�X��";
                break;
            case 5:
                this.GetComponent<Text>().text = "�`���[�g���A��";
                break;

        }
    }
}
