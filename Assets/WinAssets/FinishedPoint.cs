using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishedPoint : MonoBehaviour
{
    public delegate void winAnnouncement();
    public static event winAnnouncement endGame;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            endGame?.Invoke();
            SaveSystem.DeleteSave();
        }
    }    
}
