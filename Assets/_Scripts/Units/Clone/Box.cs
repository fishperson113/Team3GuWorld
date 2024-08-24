using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Box : RewindableObject
{
    protected override void Awake()
    {
        base.Awake();
        rb.isKinematic = true;
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
    }
    protected override IEnumerator Record()
    {
        yield return base.Record();
    }
    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        base.OnCollisionEnter2D(collision);
    }
}
