using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using playerinfo;
using TMPro;

public class DisplayPlayerName : MonoBehaviour
{
    int playerSize = -1;
    //�Q�[���I�u�W�F�N�g�̃��X�g
    public List<GameObject> ObjectList;
    //�Q�[���I�u�W�F�N�g��Transform�̃��X�g
    public List<Transform> ObjectTransformList;
    //�\�����郉�x����RectTransform�̃��X�g
    public List<RectTransform> ObjectRectTransformList;
    //�v���C���[���̃��X�g
    public List<string> plyNames;
    //Text�̃Q�[���I�u�W�F�N�g�̃��X�g
    public List<GameObject> TextObjectList;
    //GameObject[] ObjectList = GameObject.FindGameObjectsWithTag("Player");
    //uGUI���x��
    public GameObject playerNameLabel;
    //uGUI�̐e���x��
    public GameObject uGUI;
    //�T���^�O
    private string searchTag = "Enemy";//"Player"
    //�J�����Ɍ����Ă��邩
    private Renderer targetRenderer;
    private bool isInsideCamera;
    //�@�J�������ɃI�u�W�F�N�g�����邩�ǂ���
    //var isInsideCamera = false;
    void Start()
    {
        if (HasCharacter())
        {
            GetCharacter();
            GetCharacterName();
            MakeListTransform();
            InstanceNamePrefabs();
        }
    }
    void Update()
    {
        for (int i = 0; i < playerSize; i++)
        {
            ObjectRectTransformList[i].position = RectTransformUtility.WorldToScreenPoint(UnityEngine.Camera.main, ObjectTransformList[i].position);
        }
    }
    //�L�����N�^�[�̃Q�[���I�u�W�F�N�g�����X�g�ɂ��Ēǉ�
    public void GetCharacter()
    {
        GameObject[] bf = GameObject.FindGameObjectsWithTag(searchTag);
        for (int i = 0; i < bf.Length; i++)
        {
            ObjectList.Add(bf[i]);
        }
    }
    //�Q�[���S�̂Ƀv���C���[�����邩�ǂ���
    public bool HasCharacter()
    {
        playerSize = GameObject.FindGameObjectsWithTag(searchTag).Length; //ObjectList.Count;//GameObject.FindGameObjectsWithTag("Player").Length;
        Debug.Log($"Player Tag is {playerSize}");
        return playerSize > 0 ? true : false;
    }
    //�v���C���[�̖��O�̎擾
    public void GetCharacterName()
    {
        //�v���C���[�������X�g�ɒǉ�
        foreach (var ply in ObjectList)
        {
            var plyinfo = ply.GetComponent<PlayerHolder>();
            plyNames.Add(ply.GetComponent<PlayerHolder>().characterObject.CharacterName);
        }
    }
    //Transform���X�g�̐���
    public void MakeListTransform()
    {
        foreach (var ply in ObjectList)
        {
            ObjectTransformList.Add( ply.GetComponent<Transform>());
        }
    }
    //���O�\����uGUI�v���n�u�̐���
    public void InstanceNamePrefabs()
    {
        //�v���C���[�������X�g�ɒǉ�
        foreach (var ply in plyNames)
        {
            GameObject obj = Instantiate(playerNameLabel, new Vector3(0, 0, 0), Quaternion.identity);
            obj.transform.SetParent(uGUI.transform);
            TextObjectList.Add(obj);
            ObjectRectTransformList.Add(obj.transform.GetComponent<RectTransform>());
            var lines = obj.GetComponent<TextMeshProUGUI>();
            lines.text = ply;
        }
    }
    /*
    public void IsCameraIn()
    {
        //�@�J�����̃r���[�|�[�g�ʒu
        Vector2 viewportPoint;
        foreach (var ply in ObjectList)
        {
            //�@�r���[�|�[�g�̌v�Z
            viewportPoint = Camera.main.WorldToViewportPoint(ply.trasform.position);

            if (0f <= viewportPoint.x && viewportPoint.x <= 1f
                && 0f <= viewportPoint.y && viewportPoint.y <= 1f
                )
            {
                isInsideCamera = true;
                break;
            }
            if (isInsideCamera)
            {
                break;
            }
        }
    }*/
}
