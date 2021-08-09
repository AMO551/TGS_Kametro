using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMainContol : MonoBehaviour
{
    #region �錾
    public static GameMainContol Instance { get => _instance; }
    static GameMainContol _instance;
    // �v���C���[��HP
    public float player_HP = 10;
    // �G�l�~�[��ATK
    public float tNT_ATK = 4;
    // �G�l�~�[��ATK
    public float witch_ATK = 3;
    // �G�l�~�[��ATK
    public float human_ATK = 2;
    // �G�l�~�[��ATK
    public float golem_ATK_No1 = 4;
    // �G�l�~�[��ATK
    public float golem_ATK_No2 = 3;
    // �G�l�~�[��ATK
    public float golem_ATK_No3 = 2;
    //�Ń_���[�W
    public float Poison_ATK = 1;
    // �z�΂̌�
    public float reflectcrystalCount = 5;
    public float gravitycrystalCount = 0;
    public float explosioncrystalCount = 0;
    // �񕜖�̒l 
    public float healingNUM = 10;
    public float blockmeta = 100;
    public float pullmeta = 0;
    //�V�[���̊Ǘ�
    [SerializeField]
    static private int scenes = 1;
    //�z�Ύ擾�̊m�F
    public bool getCrystal=false;
    public int getReCrystal = 0;
    public int getGrCrystal = 0;
    public int getExCrystal = 0;
    //Playerfreeze(�d��)
    public bool PlayerFreeze = false;

    // ����
    public float time;
    // GameOver������
    public float gameOverCount = 0;
    public int SetScenes()
    {
        return scenes;
    }
    #endregion
    void Awake()
    {
        _instance = this;
        //DontDestroyOnLoad(gameObject);
    }
    public void Update()
    {
        //Debug.Log(scenes);
    }
    // �����ɂ��_���[�W�v�Z
    public void TNTPlayerDamege()
    {
        player_HP -= tNT_ATK;
    }
    // �E�B�b�`�ɂ��_���[�W�v�Z
    public void WitchPlayerDamege()
    {
        player_HP -= witch_ATK;
        SoundManager.Instance.Play_SE(0,0);
    }
    // �A���f�b�g�ɂ��_���[�W�v�Z
    public void HumanPlayerDamege()
    {
        player_HP -= human_ATK;
        SoundManager.Instance.Play_SE(0, 0);
    }
    // �S�[�����ɂ��_���[�W�v�Z1
    public void GolemPlayerDamageVer1()
    {
        player_HP -= golem_ATK_No1;
       SoundManager.Instance.Play_SE(0, 0);
    }
    // �S�[�����ɂ��_���[�W�v�Z1
    public void GolemPlayerDamageVer2()
    {
        player_HP -= golem_ATK_No2;
        SoundManager.Instance.Play_SE(0, 0);
    }
    // �S�[�����ɂ��_���[�W�v�Z1
    public void GolemPlayerDamageVer3()
    {
        player_HP -= golem_ATK_No3;
        SoundManager.Instance.Play_SE(0, 0);
    }
    //�Ő��ɓ��������Ƃ��̃_���[�W�v�Z
    public void Poison_Atk()
    {
        SoundManager.Instance.Play_SE(0, 19);
        player_HP -= Poison_ATK;
    }
    public void StartRecrystal()
    {
        getReCrystal = 0;
    }
    public void StartGrcrystal()
    {
        getGrCrystal = 0;
    }
    public void StartExcrystal()
    {
        getExCrystal = 0;
    }
    public void addCrystal(int Re, int Gr, int Ex)
    {
       SoundManager.Instance.Play_SE(0, 5);
        getReCrystal = Re;
        getGrCrystal = Gr;
        getExCrystal = Ex;
        getCrystal = true;
        for (int i = 0; i < Re; i++)
        {
            AddReflectCrystalCount();
            
            
        }
        for (int i = 0; i < Gr; i++)
        {
            AddGravityCrystalCount();
            
        }
        for (int i = 0; i < Ex; i++)
        {
          
            AddExplosioncrystalCount();
        }
    }
    public void AddReflectCrystalCount()
    {
        reflectcrystalCount += 1;
    }
    public void AddGravityCrystalCount()
    {
        gravitycrystalCount += 1;
    }
    public void AddExplosioncrystalCount()
    {
        explosioncrystalCount += 1;
    }
    public void PullReflectCrystalCount()
    {
        reflectcrystalCount -= 1;
    }
    public void PullGravityCrystalCount()
    {
        gravitycrystalCount -= 1;
    }
    public void PullExplosioncrystalCount()
    {
        explosioncrystalCount -= 1;
    }
    // �Q�[�W���񕜂��鏈��
    public void BlockHealmeta(float healmeta)
    {
        blockmeta += healmeta;
    }
    // �Q�[�W�����炷����
    public void PullBlockmeta()
    {
        blockmeta -= pullmeta;
    }
    public void TimeStart()
    {
        time += Time.deltaTime;
    }
    public void AddGameOverCount()
    {
        gameOverCount += 1;
    }
    //�V�[���̊Ǘ�
    public void scenes_contol(int num)
    {
        scenes = num;
    }
    public int setscenes()
    {
        return scenes;
    }
    //player�̑̂������Ȃ��Ȃ�
    public�@void Player_Freeze()
    {
        SoundManager.Instance.Play_SE(0, 13);
        PlayerFreeze = true;
        StartCoroutine("Freeze");
    }
    IEnumerator Freeze()
    {
        yield return new WaitForSeconds(0.1f);
        SoundManager.Instance.Play_SE(0, 14);
        PlayerFreeze =false;
    }
}