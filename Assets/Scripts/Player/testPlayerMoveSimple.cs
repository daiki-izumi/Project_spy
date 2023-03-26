using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Keyparas;
using Moveparas;
using inventory;

public class testPlayerMoveSimple : MonoBehaviour
{
    //=====��`�̈�=====
    //�L�[�z�u�̃N���X
    KeyParameter parasKey;
    //�ړ��̃p�����[�^�[�̃N���X
    MoveParameter moveKey;
    //�O�t���[���̈ʒu
    private Vector3 _prePosition;
    //���̃I�u�W�F�N�g�̃g�����X�t�H�[��
    private Transform _transform;
    //�A�C�e���擾�t���O
    private bool isItem;
    //�A�C�e���̂Ă�t���O
    private bool isDrop;
    //�擾�����A�C�e�����
    private ItemObject itemObject;
    //���t���[���̃x�N�g��
    private Vector3 _nowVector3;
    //�O�t���[���̌���
    private float _preRot;
    //
    [SerializeField] private StaticInventorySlotDisplay staticInventorySlotDisplay;
    //=====��������=====
    void Start()
    {
        //�L�[�z�u�̓ǂݍ���
        parasKey = new KeyParameter();
        //�ړ��p�����[�^�[�̓ǂݍ���
        moveKey = new MoveParameter();
        //���t���[������
        _nowVector3 = Vector3.zero;
        //�O�t���[������
        _transform = transform;
        _prePosition = _transform.position;
        //�A�C�e���擾�t���O
        isItem = false;
        //���߂̌���
        _preRot = 90.0f;
    }

    //=====�又��=====
    void Update()
    {
        InputKeySystem();
    }
    void InputKeySystem()
    {
        //���t���[������
        _nowVector3 = Vector3.zero;
        //-----����-----
        //�����������ꂽ��
        if (Input.GetKey(parasKey.left_move))
        {
            //Debug.Log($"A is pushed");
            _nowVector3 += moveKey.left_move;
        }
        //���������ꂽ��
        if (Input.GetKeyUp(parasKey.left_move))
        {
            Debug.Log($"A is not pushed");
        }
        //-----���E-----
        //���E�������ꂽ��
        if (Input.GetKey(parasKey.right_move))
        {
            //Debug.Log($"D is pushed");
            _nowVector3 += moveKey.right_move;
        }
        //���E�����ꂽ��
        if (Input.GetKeyUp(parasKey.right_move))
        {
            Debug.Log($"D is not pushed");
        }
        //-----�O-----
        //�O�������ꂽ��
        if (Input.GetKey(parasKey.up_move))
        {
            //Debug.Log($"W is pushed");
            _nowVector3 += moveKey.up_move;
        }
        //�O�����ꂽ��
        if (Input.GetKeyUp(parasKey.up_move))
        {
            //Debug.Log($"W is not pushed");
        }
        //-----���-----
        //��낪�����ꂽ��
        if (Input.GetKey(parasKey.down_move))
        {
            //Debug.Log($"S is pushed");
            _nowVector3 += moveKey.down_move;
        }
        //��낪���ꂽ��
        if (Input.GetKeyUp(parasKey.down_move))
        {
            Debug.Log($"S is not pushed");
        }
        //-----Ctrl��-----
        if (Input.GetKey(parasKey.crouch))
        {
            Debug.Log($"Ctrl Left is pushed");
        }
        //��낪���ꂽ��
        if (Input.GetKeyUp(parasKey.crouch))
        {
            Debug.Log($"Ctrl Left is not pushed");
        }
        //-----�A�C�e�����E��-----
        /*if (Input.GetKey(parasKey.pickup))
        {
            Debug.Log($"E is pushed");
            isItem = true;
        }
        //�A�C�e���E�������ꂽ��
        if (Input.GetKeyUp(parasKey.pickup))
        {
            Debug.Log($"E is not pushed");
            isItem = false;
        }*/
        //-----���m���̂Ă�-----
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
            Debug.Log($"���蔲���Ă�I");
            Debug.Log($"�擾�{�^��������ĂȂ�{isItem}");
            var item = other.transform.GetComponent<ItemPickUp>();
            var inventory = this.transform.GetComponent<InventoryHolder>();
            if (isItem)
            {
                Debug.Log($"�A�C�e���擾�t���O {other.gameObject.GetType()}");
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
            Debug.Log($"�A�C�e���h���b�v�t���O");
            if (!inventory) return;
            if (inventory.PrimaryInventorySystem.RemoveToInventorySystem(selectSlot, 1))
            {
                //var ui = staticInventorySlotDisplay.slots[selectSlot];
                //ui.UpdateUISlot(staticInventorySlotDisplay.SlotDictionary[ui]);
                //staticInventorySlotDisplay.slots[selectSlot].ClearSlot()
                Debug.Log($"�A�C�e���h���b�v");
            }
        }
    }
}
