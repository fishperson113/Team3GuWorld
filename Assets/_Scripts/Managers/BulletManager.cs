using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : Singleton<BulletManager>
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private int poolSize = 20;

    private List<GameObject> bulletPool;

    protected override void Awake()
    {
        base.Awake();
        bulletPool = new List<GameObject>();  // Initialize bulletPool

        for (int i = 0; i < poolSize; i++)
        {
            GameObject bullet = Instantiate(bulletPrefab);
            bullet.SetActive(false);
            bulletPool.Add(bullet);
        }
    }

    public GameObject GetBullet()
    {
        foreach (GameObject bullet in bulletPool)
        {
            if (!bullet.activeInHierarchy)
            {
                bullet.SetActive(true);
                return bullet;
            }
        }

        // If all bullets are in use, create a new one
        GameObject newBullet = Instantiate(bulletPrefab);
        newBullet.SetActive(false);  // Ensure new bullet is initially inactive
        bulletPool.Add(newBullet);
        return newBullet;
    }

    public List<GameObject> GetActiveBullets()
    {
        List<GameObject> activeBullets = new List<GameObject>();

        foreach (GameObject bullet in bulletPool)
        {
            if (bullet.activeInHierarchy)
            {
                activeBullets.Add(bullet);
            }
        }

        return activeBullets;
    }
}
