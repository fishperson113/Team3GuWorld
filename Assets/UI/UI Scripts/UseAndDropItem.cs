using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseAndDropItem : MonoBehaviour
{
    [SerializeField] private InventoryManager inventoryManager;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            UsingItem();
        }
        
        if(Input.GetKeyDown(KeyCode.Q))
        {
            DropingItem();
        }
    }

    void UsingItem()
    {
        bool isUsed = inventoryManager.UseSelectedItem();
        if (isUsed == true)
        {
            Debug.Log("Using Item!");
        }
        else
        {
            Debug.Log("Not using Item!");
        }
    }

    void DropingItem()
    {
        bool isDropped = inventoryManager.UseSelectedItem();
        if (isDropped == true)
        {
            Debug.Log("Dropping Item!");
        }    
        else
        {
            Debug.Log("No item to drop!");
        }
    }
}
