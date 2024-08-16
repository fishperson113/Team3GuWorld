using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    [HideInInspector] public bool check;
    private int objectCount = 0;
    public delegate void buttonActions();
    public static event buttonActions OpenDoor, CloseDoor;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Kiểm tra nếu có một vật thể đè lên nút
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Box")||collision.gameObject.CompareTag("Clone"))
        {
            objectCount++;
            OpenDoor?.Invoke();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // Kiểm tra nếu vật thể rời khỏi nút
        if ((collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Box"))||collision.gameObject.CompareTag("Clone") && objectCount > 0)
        {
            objectCount--;
            if (objectCount == 0)
            {
                CloseDoor?.Invoke();
            }
        }
    }
}
