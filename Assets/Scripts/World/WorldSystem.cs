using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using worldParas;
using System;

public class WorldSystem : MonoBehaviour
{
    //=====変数の宣言=====
    //秒数のパラメーター
    private WorldParameter worldParas;
    //何日目か
    public int nowDays = 0;
    //現在の時間帯0(朝)/1(夜)
    public int nowTimeZone = 0;
    //次の切り替えを行うか
    public bool onNext = true;
    //ゲームの終了条件を満たしたら
    public bool onGameOver = false;
    //終了したか
    [SerializeField] public bool isEnd;
    //秒数
    [SerializeField] private int seconds;
    // Start is called before the first frame update
    void Start()
    {
        worldParas = new WorldParameter();
        StartCoroutine(TimeMove());
        /*for (int i = 0; i < worldParas.day_repeats; i++)
        {
            Debug.Log($"今は{i}日目");
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
    //時間遷移を行うコルーチン
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
    //朝の時間遷移を行うコルーチン。引数に正常に終了したかのコールバックを持つ
    public IEnumerator Morning(Action<bool> callback)
    {
        //時間帯の設定
        nowTimeZone = 0;
        //時間の計測
        seconds = 0;
        while (seconds < worldParas.time_morning)
        {
            seconds += 1;
            yield return new WaitForSeconds(1.0f);
            /*if (i == (int)worldParas.time_morning - 1)
            {
                Debug.Log("カウント終了");
            }*/
            if (onGameOver)
            {
                Debug.Log("ゲームオーバー");
                onNext = false;
                yield break;
            }
        }
        yield return null;
        onNext = true;
        callback?.Invoke(true);
    }
    //夜の時間遷移を行うコルーチン。引数に正常に終了したかのコールバックを持つ
    public IEnumerator Evening(Action<bool> callback)
    {
        //時間帯の設定
        nowTimeZone = 1;
        //時間の計測
        seconds = 0;
        while (seconds < worldParas.time_night)
        {
            seconds += 1;
            yield return new WaitForSeconds(1.0f);
            /*if (i == (int)worldParas.time_morning - 1)
            {
                Debug.Log("カウント終了");
            }*/
            if (onGameOver)
            {
                Debug.Log("ゲームオーバー");
                onNext = false;
                yield break;
            }
        }
        //日の終わり
        nowDays += 1;
        yield return null;
        onNext = true;
        callback?.Invoke(true);
    }
}
