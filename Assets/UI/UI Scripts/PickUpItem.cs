using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    [SerializeField] private InventoryManager inventoryManager;
    [SerializeField] private GuEventChannel guChannel;
    [SerializeField] private GuConfig gu;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            IGu guInstance = GuFactory.CreateGu(gu);
            guChannel.Invoke(guInstance);
            Destroy(gameObject);
        }    
    }
}
