using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class RewindableObject:MonoBehaviour
{
    protected Stack<RewindData> rewindData = new Stack<RewindData>(); // stack dữ liệu rewind của object

    [SerializeField] protected RewindableObjEventChannel RewindDataEventChannel; //SO để gửi dữ liệu rewind của object cho clone
    protected virtual void Awake()
    {
        RewindRecorder.endRewind += StartRewinding;
    }

    protected virtual void OnDestroy()
    {
        RewindRecorder.endRewind -= StartRewinding;
    }

    protected virtual void StartRecording()
    {
        StartCoroutine("Record", Record());
    }

    protected virtual void StartRewinding()
    {
        StopCoroutine("Record");
        RewindDataEventChannel.Invoke(this);
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
    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && RewindRecorder.isRecorded)
        {
            StartRecording();
        }
    }
    public Stack<RewindData> GetRewindData()
    {
        return rewindData;
    }
}