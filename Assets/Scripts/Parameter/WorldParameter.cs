using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace worldParas
{
    public class WorldParameter
    {
        //=====���Ԃ̃p�����[�^�[=====
        //���̎��ԑ�
        public float time_morning;
        //��̎��ԑ�
        public float time_night;
        //�����J��Ԃ���
        public int day_repeats;
        public WorldParameter()
        {
            //���̎��ԑ�
            time_morning = 20.0f * 1;
            //��̎��ԑ�
            time_night = 30.0f * 1;
            //�����J��Ԃ���
            day_repeats = 3;
        }
    }

}
