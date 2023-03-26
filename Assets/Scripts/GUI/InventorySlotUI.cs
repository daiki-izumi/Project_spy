using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventorySlotUI : MonoBehaviour
{
    [SerializeField] private Image itemSprite;
    [SerializeField] private TextMeshProUGUI itemCount;
    [SerializeField] private ItemSystem assignedInventorySlot;

    private Button button;

    public ItemSystem AssignedInventorySlot => assignedInventorySlot;
    public InventorySlotDisplay ParentDisplay { get; private set; }

    //選択されたスロットのスケール
    private RectTransform rectTransform;

    public void Awake()
    {
        ClearSlot();
        button = GetComponent<Button>();
        button?.onClick.AddListener(OnUISlotClick);

        ParentDisplay = transform.parent.GetComponent<InventorySlotDisplay>();
        //親のスケール取得
        rectTransform = transform.GetComponent<RectTransform>();
        //selectSlot = 0;
    }
    public void Init(ItemSystem slot)
    {
        assignedInventorySlot = slot;
        UpdateUISlot(slot);
    }
    public void UpdateUISlot(ItemSystem slot)
    {
        if (slot.ItemObject != null)
        {
            itemSprite.sprite = slot.ItemObject.Icon;
            itemSprite.color = Color.white;
            if (slot.Amountsize > 0) itemCount.text = slot.Amountsize.ToString();
            else itemCount.text = "";

        }
        else
        {
            ClearSlot();
        }
    }
    public void UpdateUISlot()
    {
        if (assignedInventorySlot != null) UpdateUISlot(assignedInventorySlot);
        else ClearSlot();
    }
    public void ClearSlot()
    {
        assignedInventorySlot?.ClearItemSystem();
        itemSprite.sprite = null;
        itemSprite.color = Color.clear;
        itemCount.text = "";
    }
    public void OnUISlotClick()
    {
        ParentDisplay?.SlotClicked(this);
    }
    public void SelectSlot()
    {
        rectTransform.localScale = new Vector3(1.1f, 1.1f, 1.1f);
    }
    public void DeselectSlot()
    {
        rectTransform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
    }
}
