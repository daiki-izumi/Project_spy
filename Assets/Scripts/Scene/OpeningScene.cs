using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpeningScene : MonoBehaviour
{
    AsyncOperation asyncOperation;
    // Start is called before the first frame update
    void Start()
    {
        asyncOperation = SceneManager.LoadSceneAsync("New Scene");
        //‚±‚ê‚ªtrue‚É‚È‚é‚ÆƒV[ƒ“ˆÚ“®‚·‚é
        asyncOperation.allowSceneActivation = false;
    }

    public void ChangeScene()
    {
        asyncOperation.allowSceneActivation = true;
    }
}
