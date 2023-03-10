using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Keyparas;
using Moveparas;

public class testPlayerMove : MonoBehaviour
{
    //=====定義領域=====
    //キー配置のクラス
    KeyParameter parasKey;
    //移動のパラメーターのクラス
    MoveParameter moveKey;
    //アニメーションのクラス
    private Animator animator;
    //前フレームの位置
    private Vector3 _prePosition;
    //このオブジェクトのトランスフォーム
    private Transform _transform;
    //=====初期処理=====
    void Start()
    {
        //キー配置の読み込み
        parasKey = new KeyParameter();
        Debug.Log($"Left Key is {parasKey.left_move}, {parasKey.left_move.GetType()}");
        Debug.Log($"KeyCode Type is {KeyCode.A.GetType()}");
        //移動パラメーターの読み込み
        moveKey = new MoveParameter();
        //アニメーションの設定
        animator = this.gameObject.GetComponent<Animator>();
        animator.SetBool("isRun", false);
        //前フレーム処理
        _transform = transform;
        //this.gameObject.transform;
        //GetComponent<Transform>();
        _prePosition = _transform.position;
        //_prePosition = this.gameObject.transform.GetComponent<Transform>().position;
        //transformThis.positon;
    }

    //=====主処理=====
    void Update()
    {
        //Vector3 delta = this.gameObject.transform.GetComponent<Transform>().position - _prePosition;
        //_prePosition = this.gameObject.transform.GetComponent<Transform>().position;
        var position = _transform.position;
        var delta = position - _prePosition;
        _prePosition = position;
        //-----横左-----
        //横左が押されたら
        if (Input.GetKey(parasKey.left_move))
        {
            Debug.Log($"A is pushed");
            animator.SetBool("isRun", true);
            this.gameObject.transform.Translate(moveKey.left_move);
        }
        //横左が離れたら
        if (Input.GetKeyUp(parasKey.left_move))
        {
            Debug.Log($"A is not pushed");
            animator.SetBool("isRun", false);
        }
        //-----横右-----
        //横右が押されたら
        if (Input.GetKey(parasKey.right_move))
        {
            Debug.Log($"D is pushed");
            animator.SetBool("isRun", true);
            this.gameObject.transform.Translate(moveKey.right_move);
        }
        //横右が離れたら
        if (Input.GetKeyUp(parasKey.right_move))
        {
            Debug.Log($"D is not pushed");
            animator.SetBool("isRun", false);
        }
        //-----前-----
        //前が押されたら
        if (Input.GetKey(parasKey.up_move))
        {
            Debug.Log($"W is pushed");
            animator.SetBool("isRun", true);
            this.gameObject.transform.Translate(moveKey.up_move);
        }
        //前が離れたら
        if (Input.GetKeyUp(parasKey.up_move))
        {
            Debug.Log($"W is not pushed");
            animator.SetBool("isRun", false);
        }
        //-----後ろ-----
        //後ろが押されたら
        if (Input.GetKey(parasKey.down_move))
        {
            Debug.Log($"S is pushed");
            animator.SetBool("isRun", true);
            this.gameObject.transform.Translate(moveKey.down_move);
        }
        //後ろが離れたら
        if (Input.GetKeyUp(parasKey.down_move))
        {
            Debug.Log($"S is not pushed");
            animator.SetBool("isRun", false);
        }
        //-----Ctrl左-----
        if (Input.GetKey(parasKey.crouch))
        {
            Debug.Log($"Ctrl Left is pushed");
            animator.SetBool("isCrouched", true);
        }
        //後ろが離れたら
        if (Input.GetKeyUp(parasKey.crouch))
        {
            Debug.Log($"Ctrl Left is not pushed");
            animator.SetBool("isCrouched", false);
        }
        //-----アイテムを拾う-----
        if (Input.GetKey(parasKey.pickup))
        {
            Debug.Log($"E is pushed");
            animator.SetBool("isPickUp", true);
        }
        //後ろが離れたら
        if (Input.GetKeyUp(parasKey.pickup))
        {
            Debug.Log($"E is not pushed");
            animator.SetBool("isPickUp", false);
        }
        //_prePosition = _nowPosition;
        /*if (delta.magnitude > 0.01f)
        {
            transform.rotation = Quaternion.LookRotation(delta, Vector3.up);
        }*/
        if (delta == Vector3.zero)
        {
            return;
        }
        var rotation = Quaternion.LookRotation(delta, Vector3.up);
        //_transform.rotation = rotation;
    }
}
