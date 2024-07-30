using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour, IDropHandler
{
    [SerializeField] protected Image image;
    [SerializeField] protected InventoryItem inventoryItem;
    [SerializeField] protected Color selectedColor, notSelectedColor;

    protected void Awake()
    {
        DeSelected();
    }

    public void Select()
    {
        image.color = selectedColor;
    }

    public void DeSelected()
    {
        image.color = notSelectedColor;
    }


    public void OnDrop(PointerEventData eventData)
    {
        if(transform.childCount == 0)
        {
            GameObject dropped = eventData.pointerDrag;
            InventoryItem item = dropped.GetComponent<InventoryItem>();
            item.parentAfterDrag = transform;
        }    
    }
}
