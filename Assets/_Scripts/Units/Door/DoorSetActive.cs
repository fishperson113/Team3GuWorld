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

public class DoorSetActive : MonoBehaviour, IDoor {

    private bool isOpen = false;
    public float moveSpeed=1f;
    public float openYPosition;
    private Vector3 closedPosition;

    private void Awake()
    {
        closedPosition = transform.position;
    }
    public void OpenDoor() {
        isOpen = true;
        Vector3 targetPosition = new Vector3(closedPosition.x, openYPosition, closedPosition.z);
        StartCoroutine(MoveDoor(targetPosition));
    }

    public void CloseDoor() {
        if(isOpen)
        {
            isOpen = false;
            StopAllCoroutines();
            StartCoroutine(MoveDoor(closedPosition));
        }    
    }

    public void ToggleDoor() {
        isOpen = !isOpen;
        if (isOpen) {
            OpenDoor();
        } else {
            CloseDoor();
        }
    }
    private IEnumerator MoveDoor(Vector3 targetPosition)
    {
        while (Vector3.Distance(transform.position, targetPosition) > 0.01f)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
            yield return null;
        }
    }
}
