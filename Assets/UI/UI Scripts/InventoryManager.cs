using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] private InventorySlot[] inventorySlots;
    [SerializeField] private GameObject inventoryItemPrefab;
    [SerializeField] private InventorySlot equipSlot;
    private int maxStackedItems = 4;

    int selectedSlot = -1;
    bool UseEquipSlot = false;

    private void Start()
    {
        ChangeSelectedSlot(0);
        ChangeToEquipSlot(UseEquipSlot);
    }

    private void Update()
    {
        if(Input.inputString != null)
        {
            bool isNumber = int.TryParse(Input.inputString, out int number);
            if(isNumber && number > 0 && number < 8)
            {
                ChangeSelectedSlot(number - 1);
                UseEquipSlot = false;
                ChangeToEquipSlot(UseEquipSlot);
            }
            if(Input.GetKeyDown(KeyCode.R))
            {
                inventorySlots[selectedSlot].DeSelected();
                UseEquipSlot = true;
                ChangeToEquipSlot(UseEquipSlot);
            }    
        }
    }

    void ChangeToEquipSlot(bool equipedSlot)
    {
        if (equipedSlot == false)
        {
            equipSlot.DeSelected();
        }
        else
        {
            equipSlot.Select();
        }    
    }    

    void ChangeSelectedSlot(int newValue)
    {
        if(selectedSlot >= 0)
        {
            inventorySlots[selectedSlot].DeSelected();
        }
        inventorySlots[newValue].Select();
        selectedSlot = newValue;
    }

    public bool AddItem(Gu item)
    {

        // Check if any slot has the same item with count lower than max
        for (int i = 0; i < inventorySlots.Length; i++)
        {
            InventorySlot slot = inventorySlots[i];
            InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
            if (itemInSlot != null && 
                itemInSlot.item == item &&
                itemInSlot.count < maxStackedItems) //&& itemInSlot.item.stackable == true
            {

                itemInSlot.count++;
                itemInSlot.RefreshCount();
                return true;
            }
        }
        

        // Find any empty slot
        for (int i = 0; i < inventorySlots.Length; i++)
        {
            InventorySlot slot = inventorySlots[i];
            InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
            if(itemInSlot == null)
            {
                SpawnNewItem(item, slot);
                return true;
            }    
        }
        return false;
    }

    void SpawnNewItem(Gu item, InventorySlot slot)
    {
        GameObject newItemGo = Instantiate(inventoryItemPrefab, slot.transform);
        InventoryItem inventoryItem = newItemGo.GetComponent<InventoryItem>();
        inventoryItem.InitialiseGu(item);
    }   
    
/*    public Gu UseSelectedItem()
    {
        InventorySlot slot = inventorySlots[selectedSlot];
        InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
        if(itemInSlot != null)
        {
            Gu item = itemInSlot.item;
            itemInSlot.count--;
            if(itemInSlot.count <= 0)
                Destroy(itemInSlot.gameObject);
            else
                itemInSlot.RefreshCount();
            return item;
        }

        return null;
    }*/

    public bool UseSelectedItem()
    {
        InventoryItem itemInSlot = equipSlot.GetComponentInChildren<InventoryItem>();
        if(itemInSlot != null && UseEquipSlot == true)
        {  
            itemInSlot.count--;
            if (itemInSlot.count <= 0)
            {
                Destroy(itemInSlot.gameObject);
                Debug.Log("Destroy an object");
            }
            else
            {
                itemInSlot.RefreshCount();
            }

            return true;
        }    


        return false;
    }    
}
