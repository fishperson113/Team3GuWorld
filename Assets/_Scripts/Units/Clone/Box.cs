using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Box : RewindableObject
{
    private BoxCollider2D col;
    protected override void Awake()
    {
        base.Awake();
        col = GetComponent<BoxCollider2D>();
    }
    protected override void OnDestroy()
    {
        base.OnDestroy();
    }
    protected override void StartRecording()
    {
        base.StartRecording();
    }
    protected override void StartRewinding()
    {
        base.StartRewinding();
        col.isTrigger = true;
    }
    protected override IEnumerator Record()
    {
        yield return base.Record();
    }
    protected override IEnumerator LoadState()
    {
        yield return base.LoadState();
        col.isTrigger = false;
    }
}
