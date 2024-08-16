using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    public System.Action<bool> onPlateTriggered; // Sự kiện để thông báo khi plate bị nhấn hoặc thả

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Gọi sự kiện khi plate bị nhấn
        onPlateTriggered?.Invoke(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // Gọi sự kiện khi plate bị thả ra
        onPlateTriggered?.Invoke(false);
    }
}
