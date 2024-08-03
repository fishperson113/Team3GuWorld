using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour, IDropHandler
{
    [SerializeField] protected Image image;
    [SerializeField] protected Color selectedColor, notSelectedColor;
    [SerializeField] protected GameObject inventoryItemPrefab;
    protected void Awake()
    {
      //  DeSelected();
    }

    public void Select()
    {
        image.color = selectedColor;
    }

    public void DeSelected()
    {
        image.color = notSelectedColor;
    }
    public void AddItem(GuConfig guData)
    {             
        GameObject item = Instantiate(inventoryItemPrefab, transform);
        InventoryItem inventoryItem = item.GetComponent<InventoryItem>();
        inventoryItem.InitialiseGu(guData);
    }    
    public virtual void OnDrop(PointerEventData eventData)
    {
        GameObject dropped = eventData.pointerDrag;
        InventoryItem item = dropped.GetComponent<InventoryItem>();
        if (transform.childCount > 0)
        {
            Transform child = transform.GetChild(0);
            InventoryItem dragChild = child.GetComponent<InventoryItem>();
            dragChild.transform.SetParent(item.GetParent());
        }    
        item.SetParent(transform);
    }
}
