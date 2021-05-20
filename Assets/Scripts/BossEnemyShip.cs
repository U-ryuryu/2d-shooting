using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemyShip : MonoBehaviour
{
    public BossEnemyBullet bulletPrefab;
    public Transform firePoint;

    void Start()
    {
        ShotN(16, 3);
    }

    void Shot(float angle, float speed)
    {
        BossEnemyBullet bullet = Instantiate(bulletPrefab, firePoint.position, transform.rotation);
        bullet.Setting(angle, speed);
    }

    void ShotN(int count, float speed)
    {
        int bulletCount = count;
        for (int i=0; i< bulletCount; i++)
        {
            float angle = i * (2 * Mathf.PI / bulletCount);
            Shot(angle, speed);
        }
    }
}
