using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarTrigger : MonoBehaviour
{
    public System.Action onStarTriggeredShot;
    
    private bool isShot = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isShot&& collision.CompareTag("Bullet") && RewindRecorder.isRecorded) // Kiểm tra xem star đã bị bắn chưa
        {
            isShot = true;
            onStarTriggeredShot?.Invoke(); // Gọi sự kiện khi star bắn
            gameObject.SetActive(false);
        }
    }
}
