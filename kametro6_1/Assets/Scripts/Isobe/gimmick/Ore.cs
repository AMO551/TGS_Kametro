//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.PlayerLoop;

public enum Ore_TB
{
    None,
    Ore_A,
    Ore_B,
    Ore_C,
    Ore_D,
    Ore_E,
    Ore_F,
    Ore_G,
    Ore_H,
}

public class Ore : MonoBehaviour
{
   
    public int ore_a = 0;          //�z��A�̏�����
    public int ore_b = 0;          //�z��B�̏�����
    public int ore_c = 0;          //�z��C�̏�����
    private bool Updeta = false;     //�A�b�v�f�[�g��false�ɏ�����
    private bool Updeta_t = false; //�z�΂��ق��̃X�N���v�g�ɓn��                           

    public Ore_TB m_type = Ore_TB.None;
    // Update is called once per frame

    public void Start()
    {

    }
    void Update()
    {
        if (Updeta_t)
        {
            if (Updeta == true)
            {
                ore_a = 0;          //�z��A�̏�����
                ore_b = 0;          //�z��B�̏�����
                ore_c = 0;          //�z��C�̏�����

                //�f�[�^��n���������s��
                SoundManager.Instance.Play_SE(0, 18);
                //�f�X�g���C����
                Destroy(gameObject);
            }

        }
        else
        {
            //Player_HP���A�b�v�f�[�g���Ă���
            if (Updeta == true)
            {
                Ore_processing();
            }
        }
    }
    void Ore_processing()
    {
        Ore ore = this.gameObject.GetComponent<Ore>();
        switch (ore.m_type)
        {
            //�z��A����������Ă��邩����
            case Ore_TB.Ore_A:
                ore_a = 1;   //���ˍz��1�^����
                ore_b = 2;      //�d�͍z��2�^����
                GameMainContol.Instance.addCrystal(ore_a, ore_b, ore_c);
                Updeta_t = true; //�����Ɉړ�
                break;
            //�z��B����������Ă��邩����
            case Ore_TB.Ore_B:
                ore_a = 2;      //���ˍz��2�^����
                ore_b = 1;      //�d�͍z��1�^����
                GameMainContol.Instance.addCrystal(ore_a, ore_b, ore_c);
                Updeta_t = true; //�����Ɉړ�
                break;
            //�z��C����������Ă��邩����
            case Ore_TB.Ore_C:
                ore_a = 1;      //���ˍz��1�^����
                ore_b = 3;      //�d�͍z��3�^����
                GameMainContol.Instance.addCrystal(ore_a, ore_b, ore_c);
                Updeta_t = true; //�����Ɉړ�
                break;
            //�z��D����������Ă��邩����
            case Ore_TB.Ore_D:
                ore_a = 3;      //���ˍz��3�^����
                ore_b = 1;      //�d�͍z��1�^����
                GameMainContol.Instance.addCrystal(ore_a, ore_b, ore_c);
                Updeta_t = true; //�����Ɉړ�
                break;
            //�z��E����������Ă��邩����
            case Ore_TB.Ore_E:
                ore_a = 1;   //���ˍz��1�^����
                ore_b = 1;      //�d�͍z��1�^����
                ore_c = 2;      //�����z��2�^����
                GameMainContol.Instance.addCrystal(ore_a, ore_b, ore_c);
                Updeta_t = true; //�����Ɉړ�
                break;
            //�z��F����������Ă��邩����
            case Ore_TB.Ore_F:
                ore_a = 1;      //���ˍz��1�^����
                ore_b = 0;      //�d�͍z��0�^����
                ore_c = 3;      //�����z��3�^����
                GameMainContol.Instance.addCrystal(ore_a, ore_b, ore_c);
                Updeta_t = true; //�����Ɉړ�
                break;
            //�z��G����������Ă��邩����
            case Ore_TB.Ore_G:
                ore_a = 1;      //���ˍz��1�^����
                ore_b = 2;      //�d�͍z��2�^����
                ore_c = 1;      //�����z��1�^����
                GameMainContol.Instance.addCrystal(ore_a, ore_b, ore_c);
                Updeta_t = true; //�����Ɉړ�
                break;
            //�z��H����������Ă��邩����
            case Ore_TB.Ore_H:
                ore_a = 2;      //���ˍz��2�^����
                ore_b = 0;      //�d�͍z��0�^����
                ore_c = 2;      //�����z��2�^����
                GameMainContol.Instance.addCrystal(ore_a, ore_b, ore_c);
                Updeta_t = true; //�����Ɉړ�
                break;
        }
    }


    //�����ʉ߂���������
    void OnTriggerEnter2D(Collider2D collision2d)
    {
        //Debug.Log("�z�΃h���b�v");
        //Debug.Log("���ɂ�������a");
        //�v���C���[���������Ă��邩�̔���
        if (collision2d.gameObject.CompareTag("P_A"))
        {
            Debug.Log("�v���C���[���m�F");
            Updeta = true;
        }
    }
}
