using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using playerinfo;
using TMPro;

public class DisplayPlayerName : MonoBehaviour
{
    int playerSize = -1;
    //ゲームオブジェクトのリスト
    public List<GameObject> ObjectList;
    //ゲームオブジェクトのTransformのリスト
    public List<Transform> ObjectTransformList;
    //表示するラベルのRectTransformのリスト
    public List<RectTransform> ObjectRectTransformList;
    //プレイヤー名のリスト
    public List<string> plyNames;
    //Textのゲームオブジェクトのリスト
    public List<GameObject> TextObjectList;
    //GameObject[] ObjectList = GameObject.FindGameObjectsWithTag("Player");
    //uGUIラベル
    public GameObject playerNameLabel;
    //uGUIの親ラベル
    public GameObject uGUI;
    //探すタグ
    private string searchTag = "Enemy";//"Player"
    //カメラに見えているか
    private Renderer targetRenderer;
    private bool isInsideCamera;
    //　カメラ内にオブジェクトがあるかどうか
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
    //キャラクターのゲームオブジェクトをリストにして追加
    public void GetCharacter()
    {
        GameObject[] bf = GameObject.FindGameObjectsWithTag(searchTag);
        for (int i = 0; i < bf.Length; i++)
        {
            ObjectList.Add(bf[i]);
        }
    }
    //ゲーム全体にプレイヤーがいるかどうか
    public bool HasCharacter()
    {
        playerSize = GameObject.FindGameObjectsWithTag(searchTag).Length; //ObjectList.Count;//GameObject.FindGameObjectsWithTag("Player").Length;
        Debug.Log($"Player Tag is {playerSize}");
        return playerSize > 0 ? true : false;
    }
    //プレイヤーの名前の取得
    public void GetCharacterName()
    {
        //プレイヤー名をリストに追加
        foreach (var ply in ObjectList)
        {
            var plyinfo = ply.GetComponent<PlayerHolder>();
            plyNames.Add(ply.GetComponent<PlayerHolder>().characterObject.CharacterName);
        }
    }
    //Transformリストの生成
    public void MakeListTransform()
    {
        foreach (var ply in ObjectList)
        {
            ObjectTransformList.Add( ply.GetComponent<Transform>());
        }
    }
    //名前表示のuGUIプレハブの生成
    public void InstanceNamePrefabs()
    {
        //プレイヤー名をリストに追加
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
        //　カメラのビューポート位置
        Vector2 viewportPoint;
        foreach (var ply in ObjectList)
        {
            //　ビューポートの計算
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
