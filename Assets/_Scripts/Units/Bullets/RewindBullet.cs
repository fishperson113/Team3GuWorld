using System.Collections;
using UnityEngine;

public class RewindBullet :RewindableObject
{

    private Rigidbody2D rb;
    [SerializeField] protected float speed;
    public Vector2 direction;

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
        else
        {
            Invoke(nameof(Deactivate), 3f);
        }    
    }
    protected void OnDisable()
    {
        CancelInvoke();
        rb.velocity = Vector2.zero;
    }

    public void Fire()
    {
        rb.velocity = direction.normalized * speed;  
    }
    public void Deactivate()
    {
        BulletManager.Instance.ReturnBullet(gameObject);
        rb.isKinematic = false;
    }
    protected override void StartRewinding()
    {
        if(gameObject.activeInHierarchy)
        {
            base.StartRewinding();
        }    
    }
    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 collisionNormal = collision.GetContact(0).normal;
        ReflectDirection(collisionNormal);
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
    public void ReflectDirection(Vector2 inNormal)
    {
        direction = Vector2.Reflect(direction, inNormal).normalized;
        rb.velocity = direction * speed;
    }
}