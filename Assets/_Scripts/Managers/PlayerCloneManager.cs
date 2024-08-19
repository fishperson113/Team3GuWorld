using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCloneManager : Singleton<PlayerCloneManager>
{
    public GameObject playerClonePrefab;
    [HideInInspector] public bool canCreateClone;
    [HideInInspector] public RewindableObject objRewind; 
    private void Start()
    {
        canCreateClone = true;
        RewindRecorder.endRewind += createClone;
    }
    private void OnDisable()
    { 
       RewindRecorder.endRewind -= createClone;
    }
    public void ReceiveObjRewindData(RewindableObject obj)
    {
        objRewind = obj;
        Debug.Log(obj.name);
    } 
    private void createClone()
    {
        if (canCreateClone)
        {
            GameObject cloned = Instantiate(playerClonePrefab);
            cloned.GetComponent<PlayerClone>().Rewind(RewindRecorder.recordedData,objRewind);
            RewindRecorder.recordedData.Clear();
        }
    }
}