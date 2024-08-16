﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [HideInInspector] public List<Button> buttons; //List các button ảnh hưởng đến việc mở cửa
    public Vector3 openPosition; 
    private Vector3 closedPosition; 
    public float moveSpeed = 2f; 
    
    private void Start()
    {
        closedPosition = transform.position; // Lưu vị trí ban đầu của cửa
        Button.OpenDoor += Open; // Gọi hàm Open khi có sự kiện OpenDoor
        Button.CloseDoor += Close; // Gọi hàm Close khi có sự kiện CloseDoor
    }

    private void Open()
    {
        StartCoroutine(MoveDoor(openPosition));   
    }
    private void Close()
    {
        StopAllCoroutines();
        StartCoroutine(MoveDoor(closedPosition));
    }    

    private IEnumerator MoveDoor(Vector3 targetPosition)
    {
        while (Vector3.Distance(transform.position, targetPosition) !=0)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
            yield return null;
        }
    }
}