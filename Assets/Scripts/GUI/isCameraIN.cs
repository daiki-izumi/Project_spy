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
    //見えてるか見えてないかの判定
    //　カメラから外れた
    private void OnBecameInvisible()
    {
        isInsideCamera = false;
    }
    //　カメラ内に入った
    private void OnBecameVisible()
    {
        isInsideCamera = true;
    }
}
