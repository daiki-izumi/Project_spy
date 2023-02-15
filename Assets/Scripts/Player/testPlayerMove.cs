using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Keyparas;
using Moveparas;

public class testPlayerMove : MonoBehaviour
{
    //=====��`�̈�=====
    //�L�[�z�u�̃N���X
    KeyParameter parasKey;
    //�ړ��̃p�����[�^�[�̃N���X
    MoveParameter moveKey;
    //�A�j���[�V�����̃N���X
    private Animator animator;
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
    }

    //=====�又��=====
    void Update()
    {
        //-----����-----
        //�����������ꂽ��
        if (Input.GetKey(parasKey.left_move))
        {
            Debug.Log($"A is pushed");
            animator.SetBool("isRun", true);
            this.gameObject.transform.parent.Translate(moveKey.left_move);
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
            this.gameObject.transform.parent.Translate(moveKey.right_move);
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
            this.gameObject.transform.parent.Translate(moveKey.up_move);
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
            this.gameObject.transform.parent.Translate(moveKey.down_move);
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
        }
        //��낪���ꂽ��
        if (Input.GetKeyUp(parasKey.pickup))
        {
            Debug.Log($"E is not pushed");
            animator.SetBool("isPickUp", false);
        }
    }
}
