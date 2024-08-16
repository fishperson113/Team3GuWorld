/* 
    ------------------- Code Monkey -------------------

    Thank you for downloading this package
    I hope you find it useful in your projects
    If you have any questions let me know
    Cheers!

               unitycodemonkey.com
    --------------------------------------------------
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTriggerPressurePlate_Done : MonoBehaviour {

    [SerializeField] private GameObject doorA;  // Cửa cần quản lý
    [SerializeField] private List<PressurePlate> pressurePlates; // Danh sách các pressure plates

    private IDoor door;
    private int activePlates = 0; // Biến đếm số plates đang bị nhấn

    private void Awake()
    {
        door = doorA.GetComponent<IDoor>();

        // Đăng ký sự kiện cho tất cả các pressure plates
        foreach (PressurePlate plate in pressurePlates)
        {
            plate.onPlateTriggered += HandlePlateTriggered;
        }
    }

    private void HandlePlateTriggered(bool isActive)
    {
        if (isActive)
        {
            activePlates++;
        }
        else
        {
            activePlates--;
        }

        // Kiểm tra xem tất cả các plates đã bị nhấn chưa
        if (activePlates == pressurePlates.Count)
        {
            door.OpenDoor();
        }
        else
        {
            door.CloseDoor();
        }
    }
}
