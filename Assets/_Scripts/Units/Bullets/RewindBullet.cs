using System.Collections;
using UnityEngine;

public class RewindBullet :RewindableObject
{

    private Rigidbody2D rb;
    [SerializeField] protected float speed;
    protected override void Awake()
    {
        base.Awake();
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;    
    }
    protected void OnEnable()
    {
        if (RewindRecorder.isRecorded)
        {
            StartRecording();
            Debug.Log("recorded");
        }
    }

    protected void OnDisable()
    {
        CancelInvoke();
        rb.velocity = Vector2.zero;
    }

    public void Fire(Vector2 direction)
    {
        rb.velocity = direction.normalized * speed;  
    }
    protected void Deactivate()
    {
        BulletManager.Instance.ReturnBullet(gameObject);
    }
    protected override void StartRewinding()
    {
        base.StartRewinding();
    }
    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        Deactivate();
    }
    protected void OnBecameInvisible()
    {
        Deactivate();
    }
    protected override void StartRecording()
    {
        base.StartRecording();
    }
    protected override void OnDestroy()
    {
        base.OnDestroy();
    }
    protected override IEnumerator Record()
    {
        yield return base.Record();
    } 
}