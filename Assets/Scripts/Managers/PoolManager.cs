using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    public static PoolManager Instance;

    [SerializeField]
    private GameObject bulletPrefab;

    [SerializeField]
    private int poolSize = 32;

    [SerializeField]
    private Transform bulletPoolParent;

    private List<GameObject> bulletPool = new List<GameObject>();

    private void Awake()
    {
        Instance = this;

        for(int i = 0; i < poolSize; i++)
        {
            GameObject bullet = Instantiate(bulletPrefab, bulletPoolParent);
            bullet.name = $"Bullet_{i}";

            bullet.SetActive(false);

            bulletPool.Add(bullet);
        }
    }
    
    public GameObject GetBullet()
    {
        foreach(GameObject bullet in bulletPool)
        {
            if(!bullet.activeInHierarchy)
            {
                return bullet;
            }
        }

        return null;
    }
}
