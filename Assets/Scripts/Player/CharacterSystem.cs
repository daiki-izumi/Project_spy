using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[System.Serializable]
public class CharacterSystem
{
    //=====変数の宣言=====
    //CharacterObject
    private CharacterObject characterObject;
    //今のHP
    [SerializeField] private int nowHp;
    //今のアーマーHP
    [SerializeField] private int nowHpArmor;
    //プレイヤー名
    [SerializeField] private string playerName;
    //=====プロパティ=====
    //ItemObject
    public CharacterObject CharacterObject => characterObject;
    //今のHP
    public int NowHp => nowHp;
    //今のアーマーHP
    public int NowHpArmor => nowHpArmor;
    //プレイヤー名
    public string PlayerName => playerName;
    //コンストラクタ
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
    //ダメージを受ける
    public bool TakeDamage(int Damage)
    {
        //アーマーが割れたかどうかの計算
        int bfDamage = (nowHpArmor - Damage) >= 0 ? 0 : Math.Abs(nowHpArmor - Damage);
        nowHpArmor = (nowHpArmor - Damage) >= 0 ? (nowHpArmor - Damage) : 0;
        Damage = bfDamage;
        //HPのダメージ計算
        if (Damage > 0)
        {
            nowHp -= Damage;
        }
        nowHp = nowHp < 0 ? 0: nowHp;
        //死んだかどうかのチェック
        return nowHp > 0 ? true : false;
    }
}
