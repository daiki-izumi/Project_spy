using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isCameraIN : MonoBehaviour
{
    private bool isInsideCamera;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    //�����Ă邩�����ĂȂ����̔���
    //�@�J��������O�ꂽ
    private void OnBecameInvisible()
    {
        isInsideCamera = false;
    }
    //�@�J�������ɓ�����
    private void OnBecameVisible()
    {
        isInsideCamera = true;
    }
}
