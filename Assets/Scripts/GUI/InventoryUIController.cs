using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using inventory;
using UnityEngine.InputSystem;
using Keyparas;

public class InventoryUIController : MonoBehaviour
{
    //=====��`�̈�=====
    //�L�[�z�u�̃N���X
    private KeyParameter parasKey;
    public DynamicInventorySlotDisplay chestPanel;
    public DynamicInventorySlotDisplay playerBackpackPanel;

    private void Awake()
    {
        chestPanel.gameObject.SetActive(false);
        playerBackpackPanel.gameObject.SetActive(false);
        //�L�[�z�u�̓ǂݍ���
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
        /*if (Input.GetKeyDown(KeyCode.Escape)) {
            Debug.Log("Escape");
            DisplayInventory(new InventorySystem(20));
        }*/
        //�A�N�e�B�u�ɂȂ�����
        if (chestPanel.gameObject.activeInHierarchy && Input.GetKeyDown(KeyCode.Escape))
            chestPanel.gameObject.SetActive(false);
        if (playerBackpackPanel.gameObject.activeInHierarchy && Input.GetKeyDown(KeyCode.Escape))
            playerBackpackPanel.gameObject.SetActive(false);
    }
    void DisplayInventory(InventorySystem invToDisplay)
    {
        chestPanel.gameObject.SetActive(true);
        chestPanel.RefreshDynamicInventory(invToDisplay);
    }
    void DisplayPlayerBackpack(InventorySystem invToDisplay)
    {
        playerBackpackPanel.gameObject.SetActive(true);
        playerBackpackPanel.RefreshDynamicInventory(invToDisplay);
    }
}
