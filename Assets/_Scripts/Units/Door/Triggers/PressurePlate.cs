﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    public System.Action<bool> onPlateTriggered; // Sự kiện để thông báo khi plate bị nhấn hoặc thả

    private bool isPressed = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isPressed) // Kiểm tra xem plate đã bị nhấn chưa
        {
            isPressed = true;
            onPlateTriggered?.Invoke(true); // Gọi sự kiện khi plate bị nhấn
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (isPressed) // Kiểm tra xem plate đang bị nhấn
        {
            isPressed = false;
            onPlateTriggered?.Invoke(false); // Gọi sự kiện khi plate bị thả ra
        }
    }
}
