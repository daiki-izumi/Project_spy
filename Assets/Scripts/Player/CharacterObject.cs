using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CharacterType
{
    King,
    Spy,
    Farmer,
    Hunter
}
[CreateAssetMenu(menuName = "Character System/Character Object")]
public class CharacterObject : ScriptableObject
{
    //=====�L�����N�^�[�̊�{�p�����[�^�[=====
    //�L�����N�^�[��ID
    public int CharacterID;
    //�L�����N�^�[�̖��O
    public string CharacterName;
    //�L�����N�^�[��Prefab
    public GameObject prefab;
    //�L�����N�^�[�̎��
    public CharacterType type;
    //�A�C�R���T���l
    public Sprite Icon;
    //�ő�HP
    public int MaxHp;
    //�A�[�}�[HP
    public int MaxArmorHp;
    [TextArea(15, 20)]
    public string Description;
}
