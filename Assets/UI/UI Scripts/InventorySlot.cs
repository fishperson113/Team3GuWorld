using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour, IDropHandler
{
    [SerializeField] private Image image;
    [SerializeField] private Color selectedColor, notSelectedColor;

    private void Awake()
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
