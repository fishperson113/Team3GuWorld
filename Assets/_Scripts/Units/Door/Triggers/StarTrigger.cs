using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarTrigger : MonoBehaviour
{
    public System.Action onStarTriggeredShot;
    
    private bool isShot = false;
    public void ResetTrigger()
    {
        isShot = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isShot&& collision.CompareTag("Bullet"))
        {
            Debug.Log("Shot");
            isShot = true;
            SetActive(false);
            onStarTriggeredShot?.Invoke(); 
        }
    }
    public void SetActive(bool state)
    {
        gameObject.SetActive(state);
    }    
}
