using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;

namespace Moveparas
{
    public class MoveParameter
    {
        //=====移動のパラメーター=====
        //キーボード配置
        //Left
        public Vector3 left_move;
        //Up
        public Vector3 up_move;
        //Right
        public Vector3 right_move;
        //Down
        public Vector3 down_move;
        //Sit
        public Vector3 crouch;
        public MoveParameter()
        {
            left_move = new Vector3(-2f, 0f, 0f);
            up_move = new Vector3(0f, 0f, 4f);
            right_move = new Vector3(2f, 0f, 0f);
            down_move = new Vector3(0f, 0f, -2f);
            crouch = new Vector3(0f, 0f, 0f);
            
        }
    }

}
