using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ore : MonoBehaviour
{

    public float ore_a = 0;          //�z��A�̏�����
    public float ore_b = 0;          //�z��B�̏�����
    public float ore_c = 0;          //�z��C�̏�����
    public float ore_d = 0;          //�z��D�̏�����
    private bool Updeta = false;     //�A�b�v�f�[�g��false�ɏ�����
    private bool Ore_A = false;      //�z��A��false�ɏ�����
    private bool Ore_B = false;      //�z��A��false�ɏ�����
    private bool Ore_C = false;      //�z��A��false�ɏ�����
    private bool Ore_D = false;      //�z��A��false�ɏ�����
    private bool Ore_E = false;      //�z��A��false�ɏ�����
    private bool Ore_F = false;      //�z��A��false�ɏ�����
    private bool Ore_G = false;      //�z��A��false�ɏ�����
    private bool Ore_H = false;      //�z��A��false�ɏ�����

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Player_HP���A�b�v�f�[�g���Ă���
        if (Updeta == true)
        {
            //�z��A����������Ă��邩����
            if (Ore_A == true)
            {
                ore_a = 1;�@�@�@//���ˍz��1�^����
                ore_b = 2;      //�d�͍z��2�^����
                Ore_A = false;  //A�z��
            }
            //�z��B����������Ă��邩����
            if (Ore_B == true)
            {
                ore_a = 2;      //���ˍz��2�^����
                ore_b = 1;      //�d�͍z��1�^����
                Ore_B = false;  //B�z��
            }
            //�z��C����������Ă��邩����
            if (Ore_C == true)
            {
                ore_a = 1;      //���ˍz��1�^����
                ore_b = 3;      //�d�͍z��3�^����
                Ore_C = false;  //C�z��
            }
            //�z��D����������Ă��邩����
            if (Ore_D == true)
            {
                ore_a = 3;      //���ˍz��3�^����
                ore_b = 1;      //�d�͍z��1�^����
                Ore_D = false;  //D�z��
            }
            //�z��E����������Ă��邩����
            if (Ore_E == true)
            {
                ore_a = 1;�@�@�@//���ˍz��1�^����
                ore_b = 1;      //�d�͍z��1�^����
                ore_c = 2;      //�����z��2�^����
                Ore_E = false;  //A�z��
            }
            //�z��F����������Ă��邩����
            if (Ore_F == true)
            {
                ore_a = 1;      //���ˍz��1�^����
                ore_b = 0;      //�d�͍z��0�^����
                ore_c = 3;      //�����z��3�^����
                Ore_F = false;  //B�z��
            }
            //�z��G����������Ă��邩����
            if (Ore_G == true)
            {
                ore_a = 1;      //���ˍz��1�^����
                ore_b = 2;      //�d�͍z��2�^����
                ore_c = 1;      //�����z��1�^����
                Ore_G = false;  //C�z��
            }
            //�z��H����������Ă��邩����
            if (Ore_H == true)
            {
                ore_a = 2;      //���ˍz��2�^����
                ore_b = 0;      //�d�͍z��0�^����
                ore_c = 2;      //�����z��2�^����
                Ore_H = false;  //D�z��
            }
            Updeta = false;     //update��false�ɂ���
        }
        else
        {
            ore_a = 0;          //A�̍z�΂̎󂯓n���������ɖ߂�
            ore_b = 0;          //B�̍z�΂̎󂯓n���������ɖ߂�
            ore_c = 0;          //C�̍z�΂̎󂯓n���������ɖ߂�
            ore_d = 0;          //D�̍z�΂̎󂯓n���������ɖ߂�
        }

    }
    //�����ʉ߂���������
    void OnTriggerEnter2D(Collider2D collision2d)
    {
        Debug.Log("�z�΃h���b�v");
        //Debug.Log("���ɂ�������a");
        //�v���C���[���������Ă��邩�̔���
        if (collision2d.gameObject.CompareTag("P_A"))
        {
            Debug.Log("�v���C���[���m�F");
            //�ǂ̍z�΂����������̂��̔���iA�z�΁j
            if (gameObject.CompareTag("Ore_A"))
            {
                //�z�΂�����
                Destroy(gameObject);
                //�z��A��true�ɂ���
                Ore_A = true;
                //Updata��true�ɂ���
                Updeta = true;
                Debug.Log("Ore_A���m�F");
            }
            //�ǂ̍z�΂����������̂��̔���iB�z�΁j
            if (gameObject.CompareTag("Ore_B"))
            {
                //�z�΂�����
                Destroy(gameObject);
                //�z��B��true�ɂ���
                Ore_B = true;
                //Updata��true�ɂ���
                Updeta = true;
            }
            //�ǂ̍z�΂����������̂��̔���iC�z�΁j
            if (gameObject.CompareTag("Ore_C"))
            {
                //�z�΂�����
                Destroy(gameObject);
                //�z��C��true�ɂ���
                Ore_C = true;
                //Updata��true�ɂ���
                Updeta = true;
            }
            //�ǂ̍z�΂����������̂��̔���iD�z��)
            if (gameObject.CompareTag("Ore_D"))
            {
                //�z�΂�����
                Destroy(gameObject);
                //�z��D��true�ɂ���
                Ore_D = true;
                //Updata��true�ɂ���
                Updeta = true;
            }
            //�ǂ̍z�΂����������̂��̔���iE�z�΁j
            if (gameObject.CompareTag("Ore_E"))
            {
                //�z�΂�����
                Destroy(gameObject);
                //�z��A��true�ɂ���
                Ore_E = true;
                //Updata��true�ɂ���
                Updeta = true;
                Debug.Log("Ore_E���m�F");
            }
            //�ǂ̍z�΂����������̂��̔���iF�z�΁j
            if (gameObject.CompareTag("Ore_F"))
            {
                //�z�΂�����
                Destroy(gameObject);
                //�z��B��true�ɂ���
                Ore_F = true;
                //Updata��true�ɂ���
                Updeta = true;
            }
            //�ǂ̍z�΂����������̂��̔���iG�z�΁j
            if (gameObject.CompareTag("Ore_G"))
            {
                //�z�΂�����
                Destroy(gameObject);
                //�z��C��true�ɂ���
                Ore_G = true;
                //Updata��true�ɂ���
                Updeta = true;
            }
            //�ǂ̍z�΂����������̂��̔���iH�z��
            if (gameObject.CompareTag("Ore_H"))
            {
                //�z�΂�����
                Destroy(gameObject);
                //�z��D��true�ɂ���
                Ore_H = true;
                //Updata��true�ɂ���
                Updeta = true;
            }
        }
    }
}