using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipSlot : InventorySlot
{
    private GuConfig guConfig;
    [SerializeField] private GuEventChannel guEventChannel;

    private void Update()
    {
        CheckEquip();
    }
    public void CheckEquip()
    {
        InventoryItem inventoryItem = this.GetComponentInChildren<InventoryItem>();
        guConfig = inventoryItem.GuItem;
        if(guConfig != null)
        {
            var Gu = GuFactory.CreateGu(guConfig);
            guEventChannel.Invoke(Gu);
        }    
    }    
}
