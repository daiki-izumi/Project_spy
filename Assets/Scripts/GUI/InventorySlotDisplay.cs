using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public abstract class InventorySlotDisplay : MonoBehaviour
{
    [SerializeField] private MouseItemData mouseItemData;
    protected InventorySystem inventorySystem;
    protected Dictionary<InventorySlotUI, ItemSystem> slotDictionary;

    public InventorySystem InventorySystem => inventorySystem;
    public Dictionary<InventorySlotUI, ItemSystem> SlotDictionary => slotDictionary;

    //�I�����ꂽ�X���b�g
    public int selectSlot;
    //�ȑO�I�����ꂽ�X���b�g
    public int preselectSlot;

    protected virtual void Start()
    {

    }

    public abstract void AssignSlot(InventorySystem invToDisplay);

    protected virtual void UpdateSlot(ItemSystem updateSlot)
    {
        foreach (var slot in SlotDictionary)
        {
            if (slot.Value == updateSlot)
            {
                slot.Key.UpdateUISlot(updateSlot);
            }
        }
    }

    public void SlotClicked(InventorySlotUI clickedUISlot)
    {
        //�C���x���g���̃A�C�e�����N���b�N�����-�}�E�X�����̃A�C�e���������ĂȂ�������
        if (clickedUISlot.AssignedInventorySlot.ItemObject != null && mouseItemData.AssignedInventorySlot.ItemObject == null)
        {
            mouseItemData.UpdateMouseSlot(clickedUISlot.AssignedInventorySlot);
            clickedUISlot.ClearSlot();
            return;
        }
        //�C���x���g�������-�}�E�X�������A�C�e���������Ă�����
        if (clickedUISlot.AssignedInventorySlot.ItemObject == null && mouseItemData.AssignedInventorySlot.ItemObject != null)
        {
            clickedUISlot.AssignedInventorySlot.AssignItem(mouseItemData.AssignedInventorySlot);
            clickedUISlot.UpdateUISlot();
            mouseItemData.ClearSlot();
            return;
        }
        //�C���x���g�������������Ă���-�}�E�X�������A�C�e���������Ă�����
        bool isSameItem = clickedUISlot.AssignedInventorySlot.ItemObject == mouseItemData.AssignedInventorySlot.ItemObject;
        Debug.Log($"isSameItem {isSameItem}");
        if (clickedUISlot.AssignedInventorySlot.ItemObject != null && mouseItemData.AssignedInventorySlot.ItemObject != null)
        {
            //�N���b�N�����C���x���g���̃A�C�e���ƃ}�E�X�̃A�C�e��������&�ǉ��\�Ȃ��
            if (isSameItem && clickedUISlot.AssignedInventorySlot.RoomLeftInStack(mouseItemData.AssignedInventorySlot.Amountsize))
            {
                clickedUISlot.AssignedInventorySlot.AssignItem(mouseItemData.AssignedInventorySlot);
                clickedUISlot.UpdateUISlot();

                mouseItemData.ClearSlot();
            }
            else if (isSameItem && !clickedUISlot.AssignedInventorySlot.RoomLeftInStack(mouseItemData.AssignedInventorySlot.Amountsize, out int leftInStack))
            {
                //�ǉ����ė]��Ȃ�
                if (leftInStack < 1) SwapSlot(clickedUISlot);
                //�ǉ����ė]�肠��
                else
                {
                    //�C���x���g���֒ǉ�
                    int remainingOnMouse = mouseItemData.AssignedInventorySlot.Amountsize - leftInStack;
                    clickedUISlot.AssignedInventorySlot.AddToStack(leftInStack);
                    clickedUISlot.UpdateUISlot();
                    //�]��̓}�E�X�Ɏc��
                    var newItem = new ItemSystem(mouseItemData.AssignedInventorySlot.ItemObject, remainingOnMouse);
                    mouseItemData.ClearSlot();
                    mouseItemData.UpdateMouseSlot(newItem);
                }
            }//�N���b�N�����C���x���g���̃A�C�e���ƃ}�E�X�̃A�C�e�����Ⴄ
            else// if (!isSameItem)
            {
                SwapSlot(clickedUISlot);
            }
        }
    }
    //�}�E�X�ƃC���x���g���̃X���b�v
    private void SwapSlot(InventorySlotUI clickedUISlot)
    {
        var cloneSlot = new ItemSystem(mouseItemData.AssignedInventorySlot.ItemObject, mouseItemData.AssignedInventorySlot.Amountsize);
        mouseItemData.ClearSlot();

        mouseItemData.UpdateMouseSlot(clickedUISlot.AssignedInventorySlot);
        clickedUISlot.ClearSlot();
        clickedUISlot.AssignedInventorySlot.AssignItem(cloneSlot);
        clickedUISlot.UpdateUISlot();
    }

}
