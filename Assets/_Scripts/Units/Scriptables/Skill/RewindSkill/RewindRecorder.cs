using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class RewindRecorder : MonoBehaviour
{
    [HideInInspector] public static bool isRecorded;
    [HideInInspector] public static Stack<RewindData> recordedData;
    [HideInInspector] public float currentTime;
    [HideInInspector] public Vector3 cloneScale;
    public float maxTime;
    public delegate void rewindActions();
    public static event rewindActions startRewind, endRewind;
    private PlayerInput input;
    public Transform[] allParent;
    
    private void OnDisable()
    {
        input.Disable();
    }
    private void Start()
    {
        input = KeyboardManager.Instance.input;
        input.Enable();
        recordedData = new Stack<RewindData>();
        input.normal.Rewind.performed += RewindPerform;
        isRecorded = false;
    }
    
    private void RewindPerform(InputAction.CallbackContext e)
    {
        if (Time.timeScale == 1)
        {
            if (isRecorded == false)
            {
                StartRewind();
            }
            else if (isRecorded == true)
            {
                EndRewind();
            }
        }
    }
    private void StartRewind()
    {
        StartCoroutine("record", record());
        isRecorded = true;
        startRewind?.Invoke();
    }
    private void EndRewind()
    {
        StopCoroutine("record");
        isRecorded = false;
        endRewind?.Invoke();
    }
    private void Update()
    {
        if (isRecorded && Time.timeScale != 0)
        {
            RewindData newData = new RewindData();
            newData.position = transform.position;
            newData.scale = transform.localScale;
            newData.rotation = transform.rotation;
            recordedData.Push(newData);
        }
    }
    IEnumerator record()
    {
        yield return new WaitForSeconds(maxTime);
        EndRewind();
    }
}