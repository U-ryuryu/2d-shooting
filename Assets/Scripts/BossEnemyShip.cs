using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemyShip : MonoBehaviour
{
    public BossEnemyBullet bulletPrefab;
    public Transform firePoint;

    void Start()
    {
        StartCoroutine(CPU());
    }

    void Shot(float angle, float speed)
    {
        BossEnemyBullet bullet = Instantiate(bulletPrefab, firePoint.position, transform.rotation);
        bullet.Setting(angle, speed);
    }
    IEnumerator CPU()
    {
        while (transform.position.y > 1.4f)
        {

            transform.position -= new Vector3(0, 1, 0) * Time.deltaTime;
            yield return null;


        }

        while (true)
        {
            yield return WaveNShotM(4, 8);
            yield return new WaitForSeconds(1f);
            yield return WaveNShotM(2, 6);
            yield return new WaitForSeconds(1f);
            yield return WaveNShotM(3, 16);
            yield return new WaitForSeconds(1f);
        }
    }

    IEnumerator WaveNShotM(int n, int m)
    {
        for (int w = 0; w< n; w++)
        {
            yield return new WaitForSeconds(0.3f);
            ShotN(m, 2);
        }
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
