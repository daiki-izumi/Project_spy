using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;
using SimpleJSON;

namespace Keyparas
{
    public class KeyParameter
    {
        //キー配置のパラメーター
        private string path = Application.persistentDataPath + "/keyparameter.json";
        //キーボード配置
        //Left
        public UnityEngine.KeyCode left_move;
        //Up
        public UnityEngine.KeyCode up_move;
        //Right
        public UnityEngine.KeyCode right_move;
        //Down
        public UnityEngine.KeyCode down_move;
        //Sit
        public UnityEngine.KeyCode crouch;
        //PickUp
        public UnityEngine.KeyCode pickup;
        public KeyParameter()
        {
            if (File.Exists(path))
            {
                StreamReader streamReader = new StreamReader(path, Encoding.UTF8);
                string json = streamReader.ReadToEnd();
                var o = JSON.Parse(json);
                string [] dic = new[] { "Character" };
                //output = o[dic];
                Debug.Log(path);
            }
            else
            {
                left_move = KeyCode.A;
                up_move = KeyCode.W;
                right_move = KeyCode.D;
                down_move = KeyCode.S;
                crouch = KeyCode.LeftControl;
                pickup = KeyCode.E;
            }
        }
    }

}
