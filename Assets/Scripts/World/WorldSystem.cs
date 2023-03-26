using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using worldParas;
using System;

public class WorldSystem : MonoBehaviour
{
    //=====�ϐ��̐錾=====
    //�b���̃p�����[�^�[
    private WorldParameter worldParas;
    //�����ڂ�
    public int nowDays = 0;
    //���݂̎��ԑ�0(��)/1(��)
    public int nowTimeZone = 0;
    //���̐؂�ւ����s����
    public bool onNext = true;
    //�Q�[���̏I�������𖞂�������
    public bool onGameOver = false;
    //�I��������
    [SerializeField] public bool isEnd;
    //�b��
    [SerializeField] private int seconds;
    // Start is called before the first frame update
    void Start()
    {
        worldParas = new WorldParameter();
        StartCoroutine(TimeMove());
        /*for (int i = 0; i < worldParas.day_repeats; i++)
        {
            Debug.Log($"����{i}����");
            StartCoroutine(Morning());

        }*/
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            onGameOver = true;
        }
    }
    //���ԑJ�ڂ��s���R���[�`��
    public IEnumerator TimeMove()//int repeatdays
    {
        isEnd = false;
        StartCoroutine(Morning(x => isEnd = x));
        if (onNext)
        {
            yield return new WaitUntil(() => isEnd);
            isEnd = false;
            StartCoroutine(Evening(x => isEnd = x));
            yield return new WaitUntil(() => isEnd);
        }
    }
    //���̎��ԑJ�ڂ��s���R���[�`���B�����ɐ���ɏI���������̃R�[���o�b�N������
    public IEnumerator Morning(Action<bool> callback)
    {
        //���ԑт̐ݒ�
        nowTimeZone = 0;
        //���Ԃ̌v��
        seconds = 0;
        while (seconds < worldParas.time_morning)
        {
            seconds += 1;
            yield return new WaitForSeconds(1.0f);
            /*if (i == (int)worldParas.time_morning - 1)
            {
                Debug.Log("�J�E���g�I��");
            }*/
            if (onGameOver)
            {
                Debug.Log("�Q�[���I�[�o�[");
                onNext = false;
                yield break;
            }
        }
        yield return null;
        onNext = true;
        callback?.Invoke(true);
    }
    //��̎��ԑJ�ڂ��s���R���[�`���B�����ɐ���ɏI���������̃R�[���o�b�N������
    public IEnumerator Evening(Action<bool> callback)
    {
        //���ԑт̐ݒ�
        nowTimeZone = 1;
        //���Ԃ̌v��
        seconds = 0;
        while (seconds < worldParas.time_night)
        {
            seconds += 1;
            yield return new WaitForSeconds(1.0f);
            /*if (i == (int)worldParas.time_morning - 1)
            {
                Debug.Log("�J�E���g�I��");
            }*/
            if (onGameOver)
            {
                Debug.Log("�Q�[���I�[�o�[");
                onNext = false;
                yield break;
            }
        }
        //���̏I���
        nowDays += 1;
        yield return null;
        onNext = true;
        callback?.Invoke(true);
    }
}
