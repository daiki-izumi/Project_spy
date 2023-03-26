using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

namespace playerinfo
{
    public class PlayerHolder : MonoBehaviour
    {
        //=====変数の宣言=====
        //キャラクターの関数クラスの呼び出し
        [SerializeField] public CharacterSystem characterSystem;
        public CharacterSystem CharacterSystem => characterSystem;
        public static UnityAction<CharacterSystem> OnPlayerSystemRequested;
        //キャラクターのデータ
        public CharacterObject characterObject;
        //キャラクターの名前
        //[SerializeField] public string characterName;
        //HPバーのGUI
        public Slider slider;
        private void Awake()
        {
            //characterName = characterObject.CharacterName;
            characterSystem = new CharacterSystem(characterObject);
            slider.value = 1;
        }
        private void OnTriggerEnter(Collider other)
        {
            //var playerdata = other.transform.GetComponent<CharacterSystem>();
            if (other.CompareTag("Enemy") | other.CompareTag("Player"))
            {
                Debug.Log($"ダメージを受けた");
                if (characterSystem.TakeDamage(5))
                {
                    slider.value = (float)characterSystem.NowHp/ (float)characterObject.MaxHp;
                    OnPlayerSystemRequested?.Invoke(characterSystem);
                    Debug.Log($"まだ死んでない。現在のHP{characterSystem.NowHp}, 最大値{characterObject.MaxHp}");
                }
                else
                {
                    slider.value = (float)characterSystem.NowHp / (float)characterObject.MaxHp;
                    Debug.Log($"死んだ");
                }
                return;
            }
            return;
        }
    }
}
