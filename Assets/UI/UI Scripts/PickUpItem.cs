using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    [SerializeField] private InventoryManager inventoryManager;
  //  [SerializeField] private Item item;
    [SerializeField] private Gu gu;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            //    inventoryManager.AddItem(item);
            bool result = inventoryManager.AddItem(gu);
            if (result == true)
            {
                Debug.Log("Add item!");
            }
            else
                Debug.Log("Not added!");
            
            Destroy(gameObject);
        }    
    }
}
