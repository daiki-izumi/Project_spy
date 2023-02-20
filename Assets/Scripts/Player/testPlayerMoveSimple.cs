using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Keyparas;
using Moveparas;

public class testPlayerMoveSimple : MonoBehaviour
{
    //=====定義領域=====
    //キー配置のクラス
    KeyParameter parasKey;
    //移動のパラメーターのクラス
    MoveParameter moveKey;
    //前フレームの位置
    private Vector3 _prePosition;
    //このオブジェクトのトランスフォーム
    private Transform _transform;
    //アイテム取得フラグ
    private bool isItem;
    //=====初期処理=====
    void Start()
    {
        //キー配置の読み込み
        parasKey = new KeyParameter();
        Debug.Log($"Left Key is {parasKey.left_move}, {parasKey.left_move.GetType()}");
        Debug.Log($"KeyCode Type is {KeyCode.A.GetType()}");
        //移動パラメーターの読み込み
        moveKey = new MoveParameter();
        //前フレーム処理
        _transform = transform;
        _prePosition = _transform.position;
        //アイテム取得フラグ
        isItem = false;
    }

    //=====主処理=====
    void Update()
    {
        //-----横左-----
        //横左が押されたら
        if (Input.GetKey(parasKey.left_move))
        {
            Debug.Log($"A is pushed");
            this.gameObject.transform.Translate(moveKey.left_move);
        }
        //横左が離れたら
        if (Input.GetKeyUp(parasKey.left_move))
        {
            Debug.Log($"A is not pushed");
        }
        //-----横右-----
        //横右が押されたら
        if (Input.GetKey(parasKey.right_move))
        {
            Debug.Log($"D is pushed");
            this.gameObject.transform.Translate(moveKey.right_move);
        }
        //横右が離れたら
        if (Input.GetKeyUp(parasKey.right_move))
        {
            Debug.Log($"D is not pushed");
        }
        //-----前-----
        //前が押されたら
        if (Input.GetKey(parasKey.up_move))
        {
            Debug.Log($"W is pushed");
            this.gameObject.transform.Translate(moveKey.up_move);
        }
        //前が離れたら
        if (Input.GetKeyUp(parasKey.up_move))
        {
            Debug.Log($"W is not pushed");
        }
        //-----後ろ-----
        //後ろが押されたら
        if (Input.GetKey(parasKey.down_move))
        {
            Debug.Log($"S is pushed");
            this.gameObject.transform.Translate(moveKey.down_move);
        }
        //後ろが離れたら
        if (Input.GetKeyUp(parasKey.down_move))
        {
            Debug.Log($"S is not pushed");
        }
        //-----Ctrl左-----
        if (Input.GetKey(parasKey.crouch))
        {
            Debug.Log($"Ctrl Left is pushed");
        }
        //後ろが離れたら
        if (Input.GetKeyUp(parasKey.crouch))
        {
            Debug.Log($"Ctrl Left is not pushed");
        }
        //-----アイテムを拾う-----
        if (Input.GetKey(parasKey.pickup))
        {
            Debug.Log($"E is pushed");
            isItem = true;
        }
        //-----拾うボタンが離れたら-----
        if (Input.GetKeyUp(parasKey.pickup))
        {
            Debug.Log($"E is not pushed");
            isItem = false;
        }
        //後ろが離れたら
        if (Input.GetKeyUp(parasKey.pickup))
        {
            Debug.Log($"E is not pushed");
        }
        //_prePosition = _nowPosition;
        /*if (delta.magnitude > 0.01f)
        {
            transform.rotation = Quaternion.LookRotation(delta, Vector3.up);
        }*/
        var position = _transform.position;
        var delta = position - _prePosition;
        if (delta == Vector3.zero)
        {
            return;
        }
        
        _prePosition = position;
        var rotation = Quaternion.LookRotation(delta, Vector3.up);
        //_transform.rotation = rotation;
    }
    /*public void OnDetectObject(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            Debug.Log("Detected");
        }
    }*/
    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Item"))
        {
            Debug.Log($"すり抜けてる！");
            Debug.Log($"取得ボタンがされてない{isItem}");
            if (isItem)
            {
                Debug.Log($"アイテム取得フラグ true {other.gameObject.GetType()}");
                //Destroy(other.gameObject);
            }
            
        }
    }
}
