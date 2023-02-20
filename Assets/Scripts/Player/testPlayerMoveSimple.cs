using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Keyparas;
using Moveparas;

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
    //=====��������=====
    void Start()
    {
        //�L�[�z�u�̓ǂݍ���
        parasKey = new KeyParameter();
        Debug.Log($"Left Key is {parasKey.left_move}, {parasKey.left_move.GetType()}");
        Debug.Log($"KeyCode Type is {KeyCode.A.GetType()}");
        //�ړ��p�����[�^�[�̓ǂݍ���
        moveKey = new MoveParameter();
        //�O�t���[������
        _transform = transform;
        _prePosition = _transform.position;
        //�A�C�e���擾�t���O
        isItem = false;
    }

    //=====�又��=====
    void Update()
    {
        //-----����-----
        //�����������ꂽ��
        if (Input.GetKey(parasKey.left_move))
        {
            Debug.Log($"A is pushed");
            this.gameObject.transform.Translate(moveKey.left_move);
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
            Debug.Log($"D is pushed");
            this.gameObject.transform.Translate(moveKey.right_move);
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
            Debug.Log($"W is pushed");
            this.gameObject.transform.Translate(moveKey.up_move);
        }
        //�O�����ꂽ��
        if (Input.GetKeyUp(parasKey.up_move))
        {
            Debug.Log($"W is not pushed");
        }
        //-----���-----
        //��낪�����ꂽ��
        if (Input.GetKey(parasKey.down_move))
        {
            Debug.Log($"S is pushed");
            this.gameObject.transform.Translate(moveKey.down_move);
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
        if (Input.GetKey(parasKey.pickup))
        {
            Debug.Log($"E is pushed");
            isItem = true;
        }
        //-----�E���{�^�������ꂽ��-----
        if (Input.GetKeyUp(parasKey.pickup))
        {
            Debug.Log($"E is not pushed");
            isItem = false;
        }
        //��낪���ꂽ��
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
            Debug.Log($"���蔲���Ă�I");
            Debug.Log($"�擾�{�^��������ĂȂ�{isItem}");
            if (isItem)
            {
                Debug.Log($"�A�C�e���擾�t���O true {other.gameObject.GetType()}");
                //Destroy(other.gameObject);
            }
            
        }
    }
}
