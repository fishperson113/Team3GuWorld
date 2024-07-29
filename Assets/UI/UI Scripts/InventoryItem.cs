using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class InventoryItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [Header("UI")]
    public Image image;
    public TextMeshProUGUI countText;

 //   [HideInInspector] public Item item;
    [HideInInspector] public int count = 1;
    [HideInInspector] public Transform parentAfterDrag;

    [HideInInspector] public Gu item;

   /* public void InitialiseItem(Item newItem)
    {
        item = newItem;
        if(image != null)
            image.sprite = newItem.image;
        Debug.Log("Item initialized: " + newItem.name + ", Sprite: " + newItem.image.name);
        RefreshCount();
    }*/

    public void InitialiseGu(Gu newGu)
    {
        item = newGu;
        if (image != null)
            image.sprite = newGu.getGuSprite();
        Debug.Log("Item initialized: " + newGu.name + ", Sprite: " + newGu.getGuSprite().name);
        RefreshCount();
    }

    public void RefreshCount()
    {
        countText.text = count.ToString();
        bool textActive = count > 1;
        countText.gameObject.SetActive(textActive);
    }


    //Drag and Drog functions
    public void OnBeginDrag(PointerEventData eventData)
    {
        parentAfterDrag = transform.parent;
        transform.SetParent(transform.root);
        transform.SetAsLastSibling();
        if (image != null)
        {
            image.raycastTarget = false;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {       
        transform.SetParent(parentAfterDrag);
        if (image != null)
        {
            image.raycastTarget = true;
        }
    }
}
