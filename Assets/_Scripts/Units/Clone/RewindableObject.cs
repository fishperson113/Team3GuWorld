using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class RewindableObject:MonoBehaviour
{
    protected Stack<RewindData> rewindData = new Stack<RewindData>(); // stack dữ liệu rewind của object

    [SerializeField] protected RewindableObjEventChannel RewindDataEventChannel; //SO để gửi dữ liệu rewind của object cho clone

    protected Rigidbody2D rb;

    protected Coroutine activeCoroutine;
    protected virtual void Awake()
    {
        RewindRecorder.endRewind += StartRewinding;
        rb = GetComponent<Rigidbody2D>();
    }

    protected virtual void OnDestroy()
    {
        RewindRecorder.endRewind -= StartRewinding;
    }

    protected virtual void StartRecording()
    {
        activeCoroutine = StartCoroutine("Record", Record());
    }

    protected virtual void StartRewinding()
    {
        if (activeCoroutine == null) return;
        
        StopCoroutine(activeCoroutine);
        activeCoroutine = null;
        if (rewindData.Count > 0)
        {
            rb.velocity = Vector2.zero;
            rb.angularVelocity = 0;
            rb.isKinematic = true;
            Debug.Log("RewindDataEventChannel");
            RewindDataEventChannel.Invoke(this);
        } 
    }

    protected virtual IEnumerator Record()
    {
        rb.isKinematic = false;
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
        if (collision.gameObject.CompareTag("Player") && RewindRecorder.isRecorded&& activeCoroutine == null)
        {
            StartRecording();
        }
    }
    public Stack<RewindData> GetRewindData()
    {
        return rewindData;
    }
}