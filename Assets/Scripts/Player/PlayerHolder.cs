using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

namespace playerinfo
{
    public class PlayerHolder : MonoBehaviour
    {
        //=====�ϐ��̐錾=====
        //�L�����N�^�[�̊֐��N���X�̌Ăяo��
        [SerializeField] public CharacterSystem characterSystem;
        public CharacterSystem CharacterSystem => characterSystem;
        public static UnityAction<CharacterSystem> OnPlayerSystemRequested;
        //�L�����N�^�[�̃f�[�^
        public CharacterObject characterObject;
        //�L�����N�^�[�̖��O
        //[SerializeField] public string characterName;
        //HP�o�[��GUI
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
                Debug.Log($"�_���[�W���󂯂�");
                if (characterSystem.TakeDamage(5))
                {
                    slider.value = (float)characterSystem.NowHp/ (float)characterObject.MaxHp;
                    OnPlayerSystemRequested?.Invoke(characterSystem);
                    Debug.Log($"�܂�����łȂ��B���݂�HP{characterSystem.NowHp}, �ő�l{characterObject.MaxHp}");
                }
                else
                {
                    slider.value = (float)characterSystem.NowHp / (float)characterObject.MaxHp;
                    Debug.Log($"����");
                }
                return;
            }
            return;
        }
    }
}
