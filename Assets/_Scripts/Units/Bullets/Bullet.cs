using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] protected float speed = 10f;
    [SerializeField] protected float lifetime = 2f;
    protected Rigidbody2D rb;

    protected void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
    }
    protected virtual void OnEnable()
    {
        Invoke("Deactivate", lifetime);
    }

    protected void OnDisable()
    {
        CancelInvoke();
        rb.velocity = Vector2.zero;
    }

    public void Move(Vector2 direction)
    {
        rb.velocity = direction * speed;
    }

    protected void Deactivate()
    {
        gameObject.SetActive(false);
    }

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        Deactivate();
    }
}
