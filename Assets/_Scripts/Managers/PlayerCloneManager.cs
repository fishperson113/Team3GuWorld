using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCloneManager : Singleton<PlayerCloneManager>
{
    public GameObject playerClonePrefab;
    private RewindRecorder rewindRecorder;
    [HideInInspector] public bool canCreateClone;

    protected override void Awake()
    {
        base.Awake();
        rewindRecorder = GameObject.FindGameObjectWithTag("Player").GetComponent<RewindRecorder>();
    }
    private void Start()
    {
        canCreateClone = true;
        if (rewindRecorder != null)
        {
            rewindRecorder.endRewind += createClone;
        }
    }
    private void OnDisable()
    {
        if (rewindRecorder != null)
            rewindRecorder.endRewind -= createClone;
    }
    private void createClone()
    {
        if (canCreateClone)
        {
            GameObject cloned = Instantiate(playerClonePrefab);
            cloned.GetComponent<PlayerClone>().rewind(rewindRecorder.recordedData);
            rewindRecorder.recordedData.Clear();
        }
    }
}