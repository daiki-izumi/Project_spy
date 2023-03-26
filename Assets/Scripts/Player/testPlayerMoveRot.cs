using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Keyparas;
using Moveparas;
using inventory;

public class testPlayerMoveRot : MonoBehaviour
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
    //�O�t���[���̃x�N�g��
    private Vector3 _preVector3;
    private Vector3 delta;
    //���t���[���̃x�N�g��
    private Vector3 _nowVector3;
    //�O�t���[���̌���
    private float _preRot;
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
        //���t���[������
        _nowVector3 = Vector3.zero;
        //�O�t���[������
        _transform = transform;
        //this.gameObject.transform;
        //GetComponent<Transform>();
        _prePosition = _transform.position;
        //_prePosition = this.gameObject.transform.GetComponent<Transform>().position;
        //transformThis.positon;
        //�A�C�e���擾�t���O
        isItem = false;
        _preRot = 90.0f;
    }

    //=====�又��=====
    void Update()
    {
        //InputKeySystem2();
        InputKeySystem3();
    }
    //�L�[����var2
    void InputKeySystem2()
    {
        //���t���[������
        _nowVector3 = Vector3.zero;
        //-----����-----
        //�����������ꂽ��
        if (Input.GetKey(parasKey.left_move))
        {
            //Debug.Log($"A is pushed");
            animator.SetBool("isRun", true);
            //this.gameObject.transform.Translate(moveKey.left_move);
            this.gameObject.transform.position += moveKey.left_move * Time.deltaTime;
            _nowVector3 += moveKey.left_move;
        }
        //���������ꂽ��
        if (Input.GetKeyUp(parasKey.left_move))
        {
            //Debug.Log($"A is not pushed");
            animator.SetBool("isRun", false);
        }
        //-----���E-----
        //���E�������ꂽ��
        if (Input.GetKey(parasKey.right_move))
        {
            //Debug.Log($"D is pushed");
            animator.SetBool("isRun", true);
            //this.gameObject.transform.Translate(moveKey.right_move);
            this.gameObject.transform.position += moveKey.right_move * Time.deltaTime;
            _nowVector3 += moveKey.right_move;
        }
        //���E�����ꂽ��
        if (Input.GetKeyUp(parasKey.right_move))
        {
            //Debug.Log($"D is not pushed");
            animator.SetBool("isRun", false);
        }
        //-----�O-----
        //�O�������ꂽ��
        if (Input.GetKey(parasKey.up_move))
        {
            //Debug.Log($"W is pushed");
            animator.SetBool("isRun", true);
            //this.gameObject.transform.Translate(moveKey.up_move);
            this.gameObject.transform.position += moveKey.up_move * Time.deltaTime;
            _nowVector3 += moveKey.up_move;
        }
        //�O�����ꂽ��
        if (Input.GetKeyUp(parasKey.up_move))
        {
            //Debug.Log($"W is not pushed");
            animator.SetBool("isRun", false);
        }
        //-----���-----
        //��낪�����ꂽ��
        if (Input.GetKey(parasKey.down_move))
        {
            //Debug.Log($"S is pushed");
            animator.SetBool("isRun", true);
            //this.gameObject.transform.Translate(moveKey.down_move);
            this.gameObject.transform.position += moveKey.down_move * Time.deltaTime;
            _nowVector3 += moveKey.down_move;
        }
        //��낪���ꂽ��
        if (Input.GetKeyUp(parasKey.down_move))
        {
            //Debug.Log($"S is not pushed");
            animator.SetBool("isRun", false);
        }
        //-----Ctrl��-----
        if (Input.GetKey(parasKey.crouch))
        {
            //Debug.Log($"Ctrl Left is pushed");
            animator.SetBool("isCrouched", true);
        }
        //��낪���ꂽ��
        if (Input.GetKeyUp(parasKey.crouch))
        {
            //Debug.Log($"Ctrl Left is not pushed");
            animator.SetBool("isCrouched", false);
        }
        //-----�A�C�e�����E��-----
        if (Input.GetKey(parasKey.pickup))
        {
            //Debug.Log($"E is pushed");
            animator.SetBool("isPickUp", true);
            isItem = true;
        }
        //��낪���ꂽ��
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
        //�ړ��̐��K��
        //_nowVector3 = _nowVector3.normalized * Time.deltaTime;

        if (Mathf.Abs(diffDis.x) > 0.001f || Mathf.Abs(diffDis.z) > 0.001f)
        {
            Quaternion rot = Quaternion.LookRotation(diffDis);
            rot = Quaternion.Slerp(this.transform.rotation, rot, 0.1f);
            this.transform.rotation = rot;
        }
    }
    //�L�[����var3
    void InputKeySystem3()
    {
        //���t���[������
        _nowVector3 = Vector3.zero;
        //-----����-----
        //�����������ꂽ��
        if (Input.GetKey(parasKey.left_move))
        {
            //Debug.Log($"A is pushed");
            animator.SetBool("isRun", true);
            //this.gameObject.transform.Translate(moveKey.left_move);
            _nowVector3 += moveKey.left_move;
        }
        //���������ꂽ��
        if (Input.GetKeyUp(parasKey.left_move))
        {
            //Debug.Log($"A is not pushed");
            animator.SetBool("isRun", false);
        }
        //-----���E-----
        //���E�������ꂽ��
        if (Input.GetKey(parasKey.right_move))
        {
            //Debug.Log($"D is pushed");
            animator.SetBool("isRun", true);
            //this.gameObject.transform.Translate(moveKey.right_move);
            _nowVector3 += moveKey.right_move;
        }
        //���E�����ꂽ��
        if (Input.GetKeyUp(parasKey.right_move))
        {
            //Debug.Log($"D is not pushed");
            animator.SetBool("isRun", false);
        }
        //-----�O-----
        //�O�������ꂽ��
        if (Input.GetKey(parasKey.up_move))
        {
            //Debug.Log($"W is pushed");
            animator.SetBool("isRun", true);
            //this.gameObject.transform.Translate(moveKey.up_move);
            _nowVector3 += moveKey.up_move;
        }
        //�O�����ꂽ��
        if (Input.GetKeyUp(parasKey.up_move))
        {
            //Debug.Log($"W is not pushed");
            animator.SetBool("isRun", false);
        }
        //-----���-----
        //��낪�����ꂽ��
        if (Input.GetKey(parasKey.down_move))
        {
            //Debug.Log($"S is pushed");
            animator.SetBool("isRun", true);
            //this.gameObject.transform.Translate(moveKey.down_move);
            _nowVector3 += moveKey.down_move;
        }
        //��낪���ꂽ��
        if (Input.GetKeyUp(parasKey.down_move))
        {
            //Debug.Log($"S is not pushed");
            animator.SetBool("isRun", false);
        }
        //-----Ctrl��-----
        if (Input.GetKey(parasKey.crouch))
        {
            //Debug.Log($"Ctrl Left is pushed");
            animator.SetBool("isCrouched", true);
        }
        //��낪���ꂽ��
        if (Input.GetKeyUp(parasKey.crouch))
        {
            //Debug.Log($"Ctrl Left is not pushed");
            animator.SetBool("isCrouched", false);
        }
        //-----�A�C�e�����E��-----
        if (Input.GetKey(parasKey.pickup))
        {
            //Debug.Log($"E is pushed");
            animator.SetBool("isPickUp", true);
            isItem = true;
        }
        //��낪���ꂽ��
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
    //�L�[����var1
    //void InputKeySystem
    //180�x�\�L�ŕϊ�
    float Angle180(Vector2 source)
    {
        return Mathf.Atan2(source.y, source.x) * Mathf.Rad2Deg;
    }
    //360�x�\�L�ŕϊ�
    float Angle360(Vector2 source)
    {
        float angle = Mathf.Atan2(source.y, source.x) * Mathf.Rad2Deg;
        return angle >= 0 ? angle : 180 - angle;
    }
    //Vector2����Vector3�ւ̕ϊ�
    Vector2 CvtVector23(Vector3 source)
    {
        return new Vector2(source.x, source.z);
    }
    //Vector3����Vector2�ւ̕ϊ�
    Vector3 CvtVector32(Vector2 source)
    {
        return new Vector3(source.x, 0, source.y);
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
