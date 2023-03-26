using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[System.Serializable]
public class CharacterSystem
{
    //=====�ϐ��̐錾=====
    //CharacterObject
    private CharacterObject characterObject;
    //����HP
    [SerializeField] private int nowHp;
    //���̃A�[�}�[HP
    [SerializeField] private int nowHpArmor;
    //�v���C���[��
    [SerializeField] private string playerName;
    //=====�v���p�e�B=====
    //ItemObject
    public CharacterObject CharacterObject => characterObject;
    //����HP
    public int NowHp => nowHp;
    //���̃A�[�}�[HP
    public int NowHpArmor => nowHpArmor;
    //�v���C���[��
    public string PlayerName => playerName;
    //�R���X�g���N�^
    public CharacterSystem(CharacterObject source, int Hp, int HpArmor)
    {
        characterObject = source;
        nowHp = Hp;
        nowHpArmor = HpArmor;
    }
    public CharacterSystem(CharacterObject source)
    {
        characterObject = source;
        nowHp = source.MaxHp;
        nowHpArmor = source.MaxArmorHp;
        playerName = source.CharacterName;
    }
    public CharacterSystem()
    {
        characterObject = null;
        nowHp = -1;
        nowHpArmor = -1;
    }
    //�_���[�W���󂯂�
    public bool TakeDamage(int Damage)
    {
        //�A�[�}�[�����ꂽ���ǂ����̌v�Z
        int bfDamage = (nowHpArmor - Damage) >= 0 ? 0 : Math.Abs(nowHpArmor - Damage);
        nowHpArmor = (nowHpArmor - Damage) >= 0 ? (nowHpArmor - Damage) : 0;
        Damage = bfDamage;
        //HP�̃_���[�W�v�Z
        if (Damage > 0)
        {
            nowHp -= Damage;
        }
        nowHp = nowHp < 0 ? 0: nowHp;
        //���񂾂��ǂ����̃`�F�b�N
        return nowHp > 0 ? true : false;
    }
}
