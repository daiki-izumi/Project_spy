using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Keyparas;
using Moveparas;
using inventory;

public class testPlayerMoveRot : MonoBehaviour
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
    //アイテム取得フラグ
    private bool isItem;
    //取得したアイテム情報
    private ItemObject itemObject;
    // 最大の回転角速度[deg/s]
    [SerializeField] private float _maxAngularSpeed = Mathf.Infinity;
    // 進行方向に向くのにかかるおおよその時間[s]
    [SerializeField] private float _smoothTime = 0.1f;
    private float _currentAngularVelocity;
    //前フレームのベクトル
    private Vector3 _preVector3;
    private Vector3 delta;
    //現フレームのベクトル
    private Vector3 _nowVector3;
    //前フレームの向き
    private float _preRot;
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
        //現フレーム処理
        _nowVector3 = Vector3.zero;
        //前フレーム処理
        _transform = transform;
        //this.gameObject.transform;
        //GetComponent<Transform>();
        _prePosition = _transform.position;
        //_prePosition = this.gameObject.transform.GetComponent<Transform>().position;
        //transformThis.positon;
        //アイテム取得フラグ
        isItem = false;
        _preRot = 90.0f;
    }

    //=====主処理=====
    void Update()
    {
        //InputKeySystem2();
        InputKeySystem3();
    }
    //キー入力var2
    void InputKeySystem2()
    {
        //現フレーム処理
        _nowVector3 = Vector3.zero;
        //-----横左-----
        //横左が押されたら
        if (Input.GetKey(parasKey.left_move))
        {
            //Debug.Log($"A is pushed");
            animator.SetBool("isRun", true);
            //this.gameObject.transform.Translate(moveKey.left_move);
            this.gameObject.transform.position += moveKey.left_move * Time.deltaTime;
            _nowVector3 += moveKey.left_move;
        }
        //横左が離れたら
        if (Input.GetKeyUp(parasKey.left_move))
        {
            //Debug.Log($"A is not pushed");
            animator.SetBool("isRun", false);
        }
        //-----横右-----
        //横右が押されたら
        if (Input.GetKey(parasKey.right_move))
        {
            //Debug.Log($"D is pushed");
            animator.SetBool("isRun", true);
            //this.gameObject.transform.Translate(moveKey.right_move);
            this.gameObject.transform.position += moveKey.right_move * Time.deltaTime;
            _nowVector3 += moveKey.right_move;
        }
        //横右が離れたら
        if (Input.GetKeyUp(parasKey.right_move))
        {
            //Debug.Log($"D is not pushed");
            animator.SetBool("isRun", false);
        }
        //-----前-----
        //前が押されたら
        if (Input.GetKey(parasKey.up_move))
        {
            //Debug.Log($"W is pushed");
            animator.SetBool("isRun", true);
            //this.gameObject.transform.Translate(moveKey.up_move);
            this.gameObject.transform.position += moveKey.up_move * Time.deltaTime;
            _nowVector3 += moveKey.up_move;
        }
        //前が離れたら
        if (Input.GetKeyUp(parasKey.up_move))
        {
            //Debug.Log($"W is not pushed");
            animator.SetBool("isRun", false);
        }
        //-----後ろ-----
        //後ろが押されたら
        if (Input.GetKey(parasKey.down_move))
        {
            //Debug.Log($"S is pushed");
            animator.SetBool("isRun", true);
            //this.gameObject.transform.Translate(moveKey.down_move);
            this.gameObject.transform.position += moveKey.down_move * Time.deltaTime;
            _nowVector3 += moveKey.down_move;
        }
        //後ろが離れたら
        if (Input.GetKeyUp(parasKey.down_move))
        {
            //Debug.Log($"S is not pushed");
            animator.SetBool("isRun", false);
        }
        //-----Ctrl左-----
        if (Input.GetKey(parasKey.crouch))
        {
            //Debug.Log($"Ctrl Left is pushed");
            animator.SetBool("isCrouched", true);
        }
        //後ろが離れたら
        if (Input.GetKeyUp(parasKey.crouch))
        {
            //Debug.Log($"Ctrl Left is not pushed");
            animator.SetBool("isCrouched", false);
        }
        //-----アイテムを拾う-----
        if (Input.GetKey(parasKey.pickup))
        {
            //Debug.Log($"E is pushed");
            animator.SetBool("isPickUp", true);
            isItem = true;
        }
        //後ろが離れたら
        if (Input.GetKeyUp(parasKey.pickup))
        {
            //Debug.Log($"E is not pushed");
            animator.SetBool("isPickUp", false);
            isItem = false;
        }
        _nowVector3 = _nowVector3.normalized;
        Vector3 diffDis = new Vector3(this.transform.position.x, 0, this.transform.position.z) -
            new Vector3(_prePosition.x, 0, _prePosition.z);
        _prePosition = this.transform.position;
        //移動の正規化
        //_nowVector3 = _nowVector3.normalized * Time.deltaTime;

        if (Mathf.Abs(diffDis.x) > 0.001f || Mathf.Abs(diffDis.z) > 0.001f)
        {
            Quaternion rot = Quaternion.LookRotation(diffDis);
            rot = Quaternion.Slerp(this.transform.rotation, rot, 0.1f);
            this.transform.rotation = rot;
        }
    }
    //キー入力var3
    void InputKeySystem3()
    {
        //現フレーム処理
        _nowVector3 = Vector3.zero;
        //-----横左-----
        //横左が押されたら
        if (Input.GetKey(parasKey.left_move))
        {
            //Debug.Log($"A is pushed");
            animator.SetBool("isRun", true);
            //this.gameObject.transform.Translate(moveKey.left_move);
            _nowVector3 += moveKey.left_move;
        }
        //横左が離れたら
        if (Input.GetKeyUp(parasKey.left_move))
        {
            //Debug.Log($"A is not pushed");
            animator.SetBool("isRun", false);
        }
        //-----横右-----
        //横右が押されたら
        if (Input.GetKey(parasKey.right_move))
        {
            //Debug.Log($"D is pushed");
            animator.SetBool("isRun", true);
            //this.gameObject.transform.Translate(moveKey.right_move);
            _nowVector3 += moveKey.right_move;
        }
        //横右が離れたら
        if (Input.GetKeyUp(parasKey.right_move))
        {
            //Debug.Log($"D is not pushed");
            animator.SetBool("isRun", false);
        }
        //-----前-----
        //前が押されたら
        if (Input.GetKey(parasKey.up_move))
        {
            //Debug.Log($"W is pushed");
            animator.SetBool("isRun", true);
            //this.gameObject.transform.Translate(moveKey.up_move);
            _nowVector3 += moveKey.up_move;
        }
        //前が離れたら
        if (Input.GetKeyUp(parasKey.up_move))
        {
            //Debug.Log($"W is not pushed");
            animator.SetBool("isRun", false);
        }
        //-----後ろ-----
        //後ろが押されたら
        if (Input.GetKey(parasKey.down_move))
        {
            //Debug.Log($"S is pushed");
            animator.SetBool("isRun", true);
            //this.gameObject.transform.Translate(moveKey.down_move);
            _nowVector3 += moveKey.down_move;
        }
        //後ろが離れたら
        if (Input.GetKeyUp(parasKey.down_move))
        {
            //Debug.Log($"S is not pushed");
            animator.SetBool("isRun", false);
        }
        //-----Ctrl左-----
        if (Input.GetKey(parasKey.crouch))
        {
            //Debug.Log($"Ctrl Left is pushed");
            animator.SetBool("isCrouched", true);
        }
        //後ろが離れたら
        if (Input.GetKeyUp(parasKey.crouch))
        {
            //Debug.Log($"Ctrl Left is not pushed");
            animator.SetBool("isCrouched", false);
        }
        //-----アイテムを拾う-----
        if (Input.GetKey(parasKey.pickup))
        {
            //Debug.Log($"E is pushed");
            animator.SetBool("isPickUp", true);
            isItem = true;
        }
        //後ろが離れたら
        if (Input.GetKeyUp(parasKey.pickup))
        {
            //Debug.Log($"E is not pushed");
            animator.SetBool("isPickUp", false);
            isItem = false;
        }
        _nowVector3 = _nowVector3.normalized * Time.deltaTime;
        if (_nowVector3.magnitude > 0)
        {
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(_nowVector3), 0.1f);
            this.transform.position += _nowVector3;
        }
    }
    //キー入力var1
    //void InputKeySystem
    //180度表記で変換
    float Angle180(Vector2 source)
    {
        return Mathf.Atan2(source.y, source.x) * Mathf.Rad2Deg;
    }
    //360度表記で変換
    float Angle360(Vector2 source)
    {
        float angle = Mathf.Atan2(source.y, source.x) * Mathf.Rad2Deg;
        return angle >= 0 ? angle : 180 - angle;
    }
    //Vector2からVector3への変換
    Vector2 CvtVector23(Vector3 source)
    {
        return new Vector2(source.x, source.z);
    }
    //Vector3からVector2への変換
    Vector3 CvtVector32(Vector2 source)
    {
        return new Vector3(source.x, 0, source.y);
    }
    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Item") && isItem)
        {
            Debug.Log($"すり抜けてる！");
            Debug.Log($"取得ボタンがされてない{isItem}");
            if (isItem)
            {
                Debug.Log($"アイテム取得フラグ true {other.gameObject.GetType()}");
                var item = other.transform.GetComponent<ItemPickUp>();
                var inventory = this.transform.GetComponent<InventoryHolder>();
                if (!inventory) return;
                if (inventory.PrimaryInventorySystem.AddToInventorySystem(item.itemObject, 1))
                {
                    Destroy(other.gameObject);
                }
            }

        }
    }
}
