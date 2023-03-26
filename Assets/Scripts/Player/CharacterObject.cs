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
    //=====キャラクターの基本パラメーター=====
    //キャラクターのID
    public int CharacterID;
    //キャラクターの名前
    public string CharacterName;
    //キャラクターのPrefab
    public GameObject prefab;
    //キャラクターの種類
    public CharacterType type;
    //アイコンサムネ
    public Sprite Icon;
    //最大HP
    public int MaxHp;
    //アーマーHP
    public int MaxArmorHp;
    [TextArea(15, 20)]
    public string Description;
}
