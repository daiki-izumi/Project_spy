using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUI : MonoBehaviour
{
    //=====変数の宣言=====
    //GUI座標系
    [SerializeField] RectTransform nameRectTransform;
    //ワールド座標系
    [SerializeField] Transform nameTransform;
    //オフセット
    private Vector3 offset = new Vector3(0, 1.5f, 0);
    //カメラ
    //private Camera mainCamera;
    // Start is called before the first frame update
    void Start()
    {
        nameRectTransform = GetComponent<RectTransform>();
        //mainCamera =  GameObject.Find("Camera").GetComponent<Camera>().main;
    }

    // Update is called once per frame
    void Update()
    {
        //nameRectTransform.position = RectTransformUtility.WorldToScreenPoint(Camera.main, nameTransform.position + offset);
    }
}
