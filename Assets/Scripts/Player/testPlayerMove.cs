using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Keyparas;
using Moveparas;
using inventory;

public class testPlayerMove : MonoBehaviour
{
    //=====��`�̈�=====
    //�L�[�z�u�̃N���X
    KeyParameter parasKey;
    //�ړ��̃p�����[�^�[�̃N���X
    MoveParameter moveKey;
    //�A�j���[�V�����̃N���X
    private Animator animator;
    //�O�t���[���̈ʒu
    private Vector3 _prePosition;
    //���̃I�u�W�F�N�g�̃g�����X�t�H�[��
    private Transform _transform;
    //�A�C�e���擾�t���O
    private bool isItem;
    //�擾�����A�C�e�����
    private ItemObject itemObject;
    // �ő�̉�]�p���x[deg/s]
    [SerializeField] private float _maxAngularSpeed = Mathf.Infinity;
    // �i�s�����Ɍ����̂ɂ����邨���悻�̎���[s]
    [SerializeField] private float _smoothTime = 0.1f;
    private float _currentAngularVelocity;
    //=====��������=====
    void Start()
    {
        //�L�[�z�u�̓ǂݍ���
        parasKey = new KeyParameter();
        Debug.Log($"Left Key is {parasKey.left_move}, {parasKey.left_move.GetType()}");
        Debug.Log($"KeyCode Type is {KeyCode.A.GetType()}");
        //�ړ��p�����[�^�[�̓ǂݍ���
        moveKey = new MoveParameter();
        //�A�j���[�V�����̐ݒ�
        animator = this.gameObject.GetComponent<Animator>();
        animator.SetBool("isRun", false);
        //�O�t���[������
        _transform = transform;
        //this.gameObject.transform;
        //GetComponent<Transform>();
        _prePosition = _transform.position;
        //_prePosition = this.gameObject.transform.GetComponent<Transform>().position;
        //transformThis.positon;
        //�A�C�e���擾�t���O
        isItem = false;
    }

    //=====�又��=====
    void Update()
    {
        //Vector3 delta = this.gameObject.transform.GetComponent<Transform>().position - _prePosition;
        //_prePosition = this.gameObject.transform.GetComponent<Transform>().position;
        //var position = _transform.position;
        //_prePosition = position;
        //-----����-----
        //�����������ꂽ��
        if (Input.GetKey(parasKey.left_move))
        {
            Debug.Log($"A is pushed");
            animator.SetBool("isRun", true);
            this.gameObject.transform.Translate(moveKey.left_move);
        }
        //���������ꂽ��
        if (Input.GetKeyUp(parasKey.left_move))
        {
            Debug.Log($"A is not pushed");
            animator.SetBool("isRun", false);
        }
        //-----���E-----
        //���E�������ꂽ��
        if (Input.GetKey(parasKey.right_move))
        {
            Debug.Log($"D is pushed");
            animator.SetBool("isRun", true);
            this.gameObject.transform.Translate(moveKey.right_move);
        }
        //���E�����ꂽ��
        if (Input.GetKeyUp(parasKey.right_move))
        {
            Debug.Log($"D is not pushed");
            animator.SetBool("isRun", false);
        }
        //-----�O-----
        //�O�������ꂽ��
        if (Input.GetKey(parasKey.up_move))
        {
            Debug.Log($"W is pushed");
            animator.SetBool("isRun", true);
            this.gameObject.transform.Translate(moveKey.up_move);
        }
        //�O�����ꂽ��
        if (Input.GetKeyUp(parasKey.up_move))
        {
            Debug.Log($"W is not pushed");
            animator.SetBool("isRun", false);
        }
        //-----���-----
        //��낪�����ꂽ��
        if (Input.GetKey(parasKey.down_move))
        {
            Debug.Log($"S is pushed");
            animator.SetBool("isRun", true);
            this.gameObject.transform.Translate(moveKey.down_move);
        }
        //��낪���ꂽ��
        if (Input.GetKeyUp(parasKey.down_move))
        {
            Debug.Log($"S is not pushed");
            animator.SetBool("isRun", false);
        }
        //-----Ctrl��-----
        if (Input.GetKey(parasKey.crouch))
        {
            Debug.Log($"Ctrl Left is pushed");
            animator.SetBool("isCrouched", true);
        }
        //��낪���ꂽ��
        if (Input.GetKeyUp(parasKey.crouch))
        {
            Debug.Log($"Ctrl Left is not pushed");
            animator.SetBool("isCrouched", false);
        }
        //-----�A�C�e�����E��-----
        if (Input.GetKey(parasKey.pickup))
        {
            Debug.Log($"E is pushed");
            animator.SetBool("isPickUp", true);
            isItem = true;
        }
        //��낪���ꂽ��
        if (Input.GetKeyUp(parasKey.pickup))
        {
            Debug.Log($"E is not pushed");
            animator.SetBool("isPickUp", false);
            isItem = false;
        }
        var position = _transform.position;
        var delta = position - _prePosition;
        _prePosition = position;
        /*
        if (delta.magnitude > 0.003f)
        {
            transform.rotation = Quaternion.LookRotation(delta);
        }*/
        if (delta == Vector3.zero)
            return;
        var targetRot = Quaternion.LookRotation(delta, Vector3.up);
        var diffAngle = Vector3.Angle(_transform.forward, delta);
        var rotAngle = Mathf.SmoothDampAngle(
            0,
            diffAngle,
            ref _currentAngularVelocity,
            _smoothTime,
            _maxAngularSpeed
        );
        // ���݃t���[���ɂ������]���v�Z
        var nextRot = Quaternion.RotateTowards(
            _transform.rotation,
            targetRot,
            rotAngle
        );

        // �I�u�W�F�N�g�̉�]�ɔ��f
        _transform.rotation = nextRot;
        //_transform.rotation = rotation;
    }
    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Item") && isItem)
        {
            Debug.Log($"���蔲���Ă�I");
            Debug.Log($"�擾�{�^��������ĂȂ�{isItem}");
            if (isItem)
            {
                Debug.Log($"�A�C�e���擾�t���O true {other.gameObject.GetType()}");
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
