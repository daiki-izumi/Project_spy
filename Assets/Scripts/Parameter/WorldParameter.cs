using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace worldParas
{
    public class WorldParameter
    {
        //=====時間のパラメーター=====
        //朝の時間帯
        public float time_morning;
        //夜の時間帯
        public float time_night;
        //何日繰り返すか
        public int day_repeats;
        public WorldParameter()
        {
            //朝の時間帯
            time_morning = 20.0f * 1;
            //夜の時間帯
            time_night = 30.0f * 1;
            //何日繰り返すか
            day_repeats = 3;
        }
    }

}
