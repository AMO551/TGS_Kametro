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
    void OnCollisionEnter2D(Collision2D collision2d)
    {
        //Debug.Log("���ɂ�������");
        //�v���C���[���������Ă��邩�̔���
        if (collision2d.gameObject.CompareTag("Player"))
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
            //�ǂ̍z�΂����������̂��̔���iD�z�΁j
            if (gameObject.CompareTag("Ore_D"))
            if (gameObject.CompareTag("Ore_D"))
            {
                //�z�΂�����
                Destroy(gameObject);
                //�z��D��true�ɂ���
                Ore_D = true;
                //Updata��true�ɂ���
                Updeta = true;
            }
        }
    }
}
