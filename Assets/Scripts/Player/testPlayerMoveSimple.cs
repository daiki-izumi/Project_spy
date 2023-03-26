using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Keyparas;
using Moveparas;
using inventory;

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
    //アイテム捨てるフラグ
    private bool isDrop;
    //取得したアイテム情報
    private ItemObject itemObject;
    //現フレームのベクトル
    private Vector3 _nowVector3;
    //前フレームの向き
    private float _preRot;
    //
    [SerializeField] private StaticInventorySlotDisplay staticInventorySlotDisplay;
    //=====初期処理=====
    void Start()
    {
        //キー配置の読み込み
        parasKey = new KeyParameter();
        //移動パラメーターの読み込み
        moveKey = new MoveParameter();
        //現フレーム処理
        _nowVector3 = Vector3.zero;
        //前フレーム処理
        _transform = transform;
        _prePosition = _transform.position;
        //アイテム取得フラグ
        isItem = false;
        //初めの向き
        _preRot = 90.0f;
    }

    //=====主処理=====
    void Update()
    {
        InputKeySystem();
    }
    void InputKeySystem()
    {
        //現フレーム処理
        _nowVector3 = Vector3.zero;
        //-----横左-----
        //横左が押されたら
        if (Input.GetKey(parasKey.left_move))
        {
            //Debug.Log($"A is pushed");
            _nowVector3 += moveKey.left_move;
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
            //Debug.Log($"D is pushed");
            _nowVector3 += moveKey.right_move;
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
            //Debug.Log($"W is pushed");
            _nowVector3 += moveKey.up_move;
        }
        //前が離れたら
        if (Input.GetKeyUp(parasKey.up_move))
        {
            //Debug.Log($"W is not pushed");
        }
        //-----後ろ-----
        //後ろが押されたら
        if (Input.GetKey(parasKey.down_move))
        {
            //Debug.Log($"S is pushed");
            _nowVector3 += moveKey.down_move;
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
        /*if (Input.GetKey(parasKey.pickup))
        {
            Debug.Log($"E is pushed");
            isItem = true;
        }
        //アイテム拾うが離れたら
        if (Input.GetKeyUp(parasKey.pickup))
        {
            Debug.Log($"E is not pushed");
            isItem = false;
        }*/
        //-----モノを捨てる-----
        /*if (Input.GetKeyDown(parasKey.drop))
        {
            Debug.Log($"Q is pushed");
            isDrop = true;
            DropInventoryItem(staticInventorySlotDisplay.selectSlot);
        }*/
        _nowVector3 = _nowVector3.normalized * Time.deltaTime;
        if (_nowVector3.magnitude > 0)
        {
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(_nowVector3), 0.1f);
            this.transform.position += _nowVector3;
        }
    }
    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Item") && isItem)
        {
            Debug.Log($"すり抜けてる！");
            Debug.Log($"取得ボタンがされてない{isItem}");
            var item = other.transform.GetComponent<ItemPickUp>();
            var inventory = this.transform.GetComponent<InventoryHolder>();
            if (isItem)
            {
                Debug.Log($"アイテム取得フラグ {other.gameObject.GetType()}");
                if (!inventory) return;
                if (inventory.PrimaryInventorySystem.AddToInventorySystem(item.itemObject, 1))
                {
                    Destroy(other.gameObject);
                }
            }
        }
    }
    public void DropInventoryItem(int selectSlot)
    {
        var inventory = this.transform.GetComponent<InventoryHolder>();
        if (isDrop)
        {
            Debug.Log($"アイテムドロップフラグ");
            if (!inventory) return;
            if (inventory.PrimaryInventorySystem.RemoveToInventorySystem(selectSlot, 1))
            {
                //var ui = staticInventorySlotDisplay.slots[selectSlot];
                //ui.UpdateUISlot(staticInventorySlotDisplay.SlotDictionary[ui]);
                //staticInventorySlotDisplay.slots[selectSlot].ClearSlot()
                Debug.Log($"アイテムドロップ");
            }
        }
    }
}
