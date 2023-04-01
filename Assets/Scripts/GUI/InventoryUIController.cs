using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using inventory;
using UnityEngine.InputSystem;
using Keyparas;

public class InventoryUIController : MonoBehaviour
{
    //=====定義領域=====
    //キー配置のクラス
    private KeyParameter parasKey;
    public DynamicInventorySlotDisplay chestPanel;
    public DynamicInventorySlotDisplay playerBackpackPanel;

    private void Awake()
    {
        chestPanel.gameObject.SetActive(false);
        playerBackpackPanel.gameObject.SetActive(false);
        //キー配置の読み込み
        parasKey = new KeyParameter();
    }
    private void OnEnable()
    {
        InventoryHolder.OnInventorySystemRequested += DisplayInventory;
        PlayerInventoryHolder.OnPlayerBackpackRequested += DisplayPlayerBackpack;
    }
    private void OnDisable()
    {
        InventoryHolder.OnInventorySystemRequested -= DisplayInventory;
        PlayerInventoryHolder.OnPlayerBackpackRequested -= DisplayPlayerBackpack;
    }

    // Update is called once per frame
    void Update()
    {
        //チェストがアクティブになったら&Escapeが押されたら
        if (chestPanel.gameObject.activeInHierarchy) 
        {
            DisplayInventory();
            if (Input.GetKeyDown(KeyCode.Escape)) chestPanel.gameObject.SetActive(false);
        }
        //インベントリがアクティブになったら&Escapeが押されたら
        if (playerBackpackPanel.gameObject.activeInHierarchy && Input.GetKeyDown(KeyCode.Escape))
        { 
            playerBackpackPanel.gameObject.SetActive(false);
            //プレイヤーの移動を止める
            PlayerMove.IsAllowMove?.Invoke(true);
        }
    }
    void DisplayInventory(InventorySystem invToDisplay)
    {
        chestPanel.gameObject.SetActive(true);
        chestPanel.RefreshDynamicInventory(invToDisplay);
    }
    void DisplayInventory()
    {
        chestPanel.gameObject.SetActive(true);
        //chestPanel.RefreshDynamicInventory(SecondaryInventorySystem);
    }
    void DisplayPlayerBackpack(InventorySystem invToDisplay)
    {
        playerBackpackPanel.gameObject.SetActive(true);
        playerBackpackPanel.RefreshDynamicInventory(invToDisplay);
    }
}
