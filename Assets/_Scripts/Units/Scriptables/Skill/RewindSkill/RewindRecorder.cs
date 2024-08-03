using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class RewindRecorder : MonoBehaviour
{
    [HideInInspector] public bool isRecorded;
    [HideInInspector] public Stack<RewindData> recordedData;
    [HideInInspector] public float startTime;
    [HideInInspector] public Vector3 cloneScale;
    public float maxTime;
    public delegate void rewindActions();
    public rewindActions startRewind, endRewind;
    private PlayerInput input;
    public Transform[] allParent;
    private void OnEnable()
    { 
        input.Enable();
    }
    private void OnDisable()
    {
        input.Disable();
    }
    private void Awake()
    {
        input = KeyboardManager.Instance.input;
        recordedData = new Stack<RewindData>();
        startRewind += StartRewind;
        endRewind += EndRewind;
        input.normal.Rewind.performed += RewindPerform;
        isRecorded = false;
    }
    private void RewindPerform(InputAction.CallbackContext e)
    {
        if (Time.timeScale == 1)
        {
            if (isRecorded == false)
            {
                startRewind();
            }
            else if (isRecorded == true)
            {
                endRewind();
            }
        }
    }
    private void StartRewind()
    {
        StartCoroutine("record", record());
        isRecorded = true;
    }
    private void EndRewind()
    {
        StopCoroutine("record");
        isRecorded = false;
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
        endRewind();
    }
}