using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class InventoryUI : Singleton<InventoryUI>
{
    [SerializeField] private List<InventorySlot> inventorySlots;
    [SerializeField] private GameObject inventorySlotPrefab;
    [SerializeField] private Transform slotParent;
    [SerializeField] private GameObject grid;
    private void Start()
    {
        grid.SetActive(false);
    }
    public void AddItem(GameObject item)
    {
        GuController guController = item.GetComponent<GuController>();
        GuConfig guData=guController.gu.GetGuData();
        Debug.Log("Adding item: " + guData.icon.name);
        foreach (var slot in inventorySlots)
        {
            if (slot.transform.childCount == 0)
            {
                slot.AddItem(guData);
                return;
            }
        }
        CreateNewSlot(guData);
    }
    public void SetActiveInventoryGrid(Empty empty)
    {
        grid.SetActive(!grid.activeSelf);
    }
    private void CreateNewSlot(GuConfig guData)
    {
        GameObject newSlot = Instantiate(inventorySlotPrefab, slotParent);
        InventorySlot inventorySlot = newSlot.GetComponent<InventorySlot>();
        // Thêm slot mới vào danh sách
        inventorySlots.Add(inventorySlot);
        // Thêm vật phẩm vào slot mới
        inventorySlot.AddItem(guData);
    }
}