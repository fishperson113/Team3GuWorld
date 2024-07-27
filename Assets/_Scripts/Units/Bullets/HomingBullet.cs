using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingBullet : Bullet
{
    [SerializeField] private float rotateSpeed = 200f;
    [SerializeField] private float maxDistance = 10f;
    private GameObject target;
    protected override void OnEnable()
    {
        base.OnEnable();
        target = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(HomingRoutine());
    }
    private IEnumerator HomingRoutine()
    {
        while (gameObject.activeSelf && target != null)
        {
            Vector2 direction = (Vector2)target.transform.position - rb.position;
            float distance = direction.magnitude;
            direction.Normalize();

            float rotateAmount = Vector3.Cross(direction, transform.up).z;
            rb.angularVelocity = -rotateAmount * rotateSpeed;

            rb.velocity = direction * speed;

            if (distance > maxDistance)
            {
                break;
            }
            yield return null;
        }
    }
}
