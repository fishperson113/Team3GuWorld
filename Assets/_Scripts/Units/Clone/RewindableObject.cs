using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class RewindableObject:MonoBehaviour
{
    protected Stack<RewindData> rewindData = new Stack<RewindData>();

    protected virtual void Awake()
    {
        RewindRecorder.startRewind += StartRecording;
        RewindRecorder.endRewind += StartRewinding;
    }

    protected virtual void OnDestroy()
    {
        RewindRecorder.startRewind -= StartRecording;
        RewindRecorder.endRewind -= StartRewinding;
    }

    protected virtual void StartRecording()
    {
        StartCoroutine("Record", Record());
    }

    protected virtual void StartRewinding()
    {
        StopCoroutine("Record");
        StartCoroutine(LoadState());
    }

    protected virtual IEnumerator Record()
    {
        while (RewindRecorder.isRecorded)
        {
            RewindData data = new RewindData
            {
                position = transform.position,
                rotation = transform.rotation,
                scale = transform.localScale
            };
            rewindData.Push(data);
            yield return null;
        }
    }

    protected virtual IEnumerator LoadState()
    {
        while (rewindData.Count > 0)
        {
            RewindData data = rewindData.Pop();
            transform.position = data.position;
            transform.rotation = data.rotation;
            transform.localScale = data.scale;
            yield return null;
        }
    }
}