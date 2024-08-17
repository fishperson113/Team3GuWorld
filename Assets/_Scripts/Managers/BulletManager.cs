using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : Singleton<BulletManager>
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private int poolSize;

    private Queue<GameObject> bulletPool;
    private List<GameObject> activeBullets;
    protected override void Awake()
    {
        base.Awake();
        bulletPool = new Queue<GameObject>();
        activeBullets = new List<GameObject>(); 

        for (int i = 0; i < poolSize; i++)
        {
            GameObject bullet = Instantiate(bulletPrefab); 
            bullet.SetActive(false); 
            bulletPool.Enqueue(bullet); 
        }
    }

    public GameObject GetBullet()
    {
        if (bulletPool.Count > 0)
        {
            GameObject bullet = bulletPool.Dequeue(); 
            bullet.SetActive(true);
            activeBullets.Add(bullet);
            return bullet;
        }
        else
        {
            GameObject newBullet = Instantiate(bulletPrefab);
            newBullet.SetActive(false);
            return newBullet;
        }
    }
    public void ReturnBullet(GameObject bullet)
    {
        bullet.SetActive(false);
        activeBullets.Remove(bullet);
        bulletPool.Enqueue(bullet);
    }
    public bool IsAnyBulletOnScreen()
    {
        foreach (GameObject bullet in activeBullets)
        {
            if (bullet.activeInHierarchy)
            {
                return true; // Có ít nhất một viên đạn đang hoạt động trên màn hình
            }
        }
        return false;
    }
}
