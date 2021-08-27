using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorManager : MonoBehaviour
{
    public static ColorManager Instance { get => _instance; }
    static ColorManager _instance;
    // �F��ς������I�u�W�F�N�g�����X�g��
    [SerializeField]
    List<SpriteRenderer> colorlist = new List<SpriteRenderer>();
    // ���͔ԍ����o����ׂ̕ϐ�
    private int changcolor;
    void Awake()
    {
        _instance = this;
    }
    // �F�ύX�X�N���v�g(���X�g�̔ԍ����L��)
    public void ChangeColor(int color_num)
    {
        changcolor = color_num;
        StartCoroutine("Cooltime");
    }
    IEnumerator Cooltime()
    {
        // �Ԃ��ύX
        colorlist[changcolor].color = new Color(180.0f / 255f, 30.0f / 255f, 25.0f / 255f, 210.0f / 255f);
        yield return new WaitForSeconds(1.0f);
        // ���Ƃɖ߂�
        colorlist[changcolor].color = new Color(255.0f / 255f, 255.0f / 255f, 255.0f / 255f, 255.0f / 255f);
    }
}