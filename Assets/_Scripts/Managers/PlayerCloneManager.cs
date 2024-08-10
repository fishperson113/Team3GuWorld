using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCloneManager : Singleton<PlayerCloneManager>
{
    public GameObject playerClonePrefab;
    [HideInInspector] public bool canCreateClone;
    private void Start()
    {
        canCreateClone = true;
        RewindRecorder.endRewind += createClone;
    }
    private void OnDisable()
    { 
       RewindRecorder.endRewind -= createClone;
    }
    private void createClone()
    {
        if (canCreateClone)
        {
            GameObject cloned = Instantiate(playerClonePrefab);
            cloned.GetComponent<PlayerClone>().rewind(RewindRecorder.recordedData);
            RewindRecorder.recordedData.Clear();
        }
    }
}