using UnityEngine;

public class ShootProjectile 
{
    public static void Shoot(Vector2 direction, Transform firePoint)
    {
        GameObject bullet = BulletManager.Instance.GetBullet();
        bullet.transform.position = firePoint.position;
        bullet.transform.rotation = firePoint.rotation;
        bullet.SetActive(true);
        bullet.GetComponent<Bullet>().Move(direction);
    }
}
