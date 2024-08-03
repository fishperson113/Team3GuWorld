using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class InventoryItem : SaiMonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [Header("UI")]
    public Image image;
    public TextMeshProUGUI countText;

    [HideInInspector] private Transform parentBeforeDrag;
    [HideInInspector] private GuConfig GuItem;
    public Transform GetParent() { return parentBeforeDrag; }

    public GuConfig GetGuItem() { return GuItem; }
    public void InitialiseGu(GuConfig newGu)
    {
        GuItem = newGu;
        if (image != null)
            image.sprite = newGu.GetGuSprite();
        Debug.Log("Item initialized: " + newGu.name + ", Sprite: " + newGu.GetGuSprite().name);
    }
    public void SetParent(Transform parent)
    {
        parentBeforeDrag = parent;
    }    

    //Drag and Drog functions
    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadImage();
    }
    protected virtual void LoadImage()
    {
        if (this.image != null) return;
        this.image = GetComponent<Image>();
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        parentBeforeDrag = transform.parent;
        transform.SetParent(InventoryUI.Instance.transform);
        image.raycastTarget = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.SetParent(parentBeforeDrag);
        image.raycastTarget = true;
    }
}
