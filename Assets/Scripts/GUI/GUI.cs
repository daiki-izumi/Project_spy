using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUI : MonoBehaviour
{
    //=====�ϐ��̐錾=====
    //GUI���W�n
    [SerializeField] RectTransform nameRectTransform;
    //���[���h���W�n
    [SerializeField] Transform nameTransform;
    //�I�t�Z�b�g
    private Vector3 offset = new Vector3(0, 1.5f, 0);
    //�J����
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
