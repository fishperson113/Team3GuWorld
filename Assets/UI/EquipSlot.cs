using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
public class EquipSlot :InventorySlot
{
    public GuEventChannel equippedGu;
    public override void OnDrop(PointerEventData eventData)
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
        IGu guToEquip = GuFactory.CreateGu(item.GetGuItem());
        if(guToEquip != null)
        {
            equippedGu.Invoke(guToEquip);
            return;
        }
        Debug.Log("No item");
    }
}