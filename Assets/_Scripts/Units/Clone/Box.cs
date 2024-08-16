using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Box : RewindableObject
{
    private Rigidbody2D rb;
    protected override void Awake()
    {
        base.Awake();
        rb= GetComponent<Rigidbody2D>();
        rb.isKinematic= true;
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
        rb.velocity = Vector2.zero;
        rb.angularVelocity = 0f;
        base.StartRewinding();
    }
    protected override IEnumerator Record()
    {
        yield return base.Record();
    }
    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        rb.isKinematic = false;
        base.OnCollisionEnter2D(collision);
    }
}
