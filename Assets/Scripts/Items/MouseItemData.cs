using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;

public class MouseItemData : MonoBehaviour
{
    //=====定義領域=====
    public Image ItemSprite;
    public TextMeshProUGUI ItemCount;
    public ItemSystem AssignedInventorySlot;

    private Transform _playerTransform;
    public float _dropOffset = 1f;
    private void Awake()
    {
        ItemSprite.color = Color.clear;
        ItemCount.text = "";

        //プレイヤーの位置
        _playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        if (_playerTransform == null) {
            Debug.Log("Player Tag is not Found");
        }
    }
    public void UpdateMouseSlot(ItemSystem invSlot)
    {
        AssignedInventorySlot.AssignItem(invSlot);
        ItemSprite.sprite = invSlot.ItemObject.Icon;
        ItemCount.text = invSlot.Amountsize.ToString();
        ItemSprite.color = Color.white;
    }
    private void Update()
    {
        if (AssignedInventorySlot.ItemObject != null)
        {
            this.transform.position = Mouse.current.position.ReadValue(); //Input.mousePosition;
            if (Mouse.current.leftButton.wasPressedThisFrame && !IsPointerOverUIObject())
            {
                //アイテムのドロップ
                if (AssignedInventorySlot.ItemObject.prefab != null) //Instantiate(AssignedInventorySlot.ItemObject.prefab, _playerTransform.position + _playerTransform.forward*_dropOffset,Quaternion.identity);
                {
                    for (int i = 0; i < AssignedInventorySlot.Amountsize; i++)
                    {
                        Instantiate(AssignedInventorySlot.ItemObject.prefab, _playerTransform.position + _playerTransform.forward * _dropOffset,
                        Quaternion.identity);
                    }
                }
                ClearSlot();
            }
        }
        /*if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Debug.Log("Left Button is Clicked");
        }*/
    }
    public void ClearSlot()
    {
        AssignedInventorySlot.ClearItemSystem();
        ItemCount.text = "";
        ItemSprite.color = Color.clear;
        ItemSprite.sprite = null;
    }
    public static bool IsPointerOverUIObject()
    {
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = Mouse.current.position.ReadValue();
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        return results.Count > 0;
    }


}
