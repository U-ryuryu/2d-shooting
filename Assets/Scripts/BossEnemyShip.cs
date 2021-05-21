using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemyShip : MonoBehaviour
{
    public BossEnemyBullet bulletPrefab;
    public Transform firePoint;
    public GameObject explosion;
    GameController gameController;
    GameObject player;

    int Hp = 10;

    void Start()
    {
        player = GameObject.Find("PlayerShip");
        StartCoroutine(CPU());
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
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
            yield return WaveNShotMCurve(4, 16);
            yield return new WaitForSeconds(1f);
            yield return WaveNPlayerAimShot(4, 6);
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

    IEnumerator WaveNShotMCurve(int n, int m)
    {
        for (int w = 0; w< n; w++)
        {
            yield return new WaitForSeconds(0.3f);
            yield return ShotNCurve(m, 2);
        }
    }

    IEnumerator WaveNPlayerAimShot(int n, int m)
    {
        for (int w = 0; w< n; w++)
        {
            yield return new WaitForSeconds(1f);
            PlayerAimShot(m, 2);
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

    IEnumerator ShotNCurve(int count, float speed)
    {
        int bulletCount = count;
        for (int i=0; i< bulletCount; i++)
        {
            float angle = i * (2 * Mathf.PI / bulletCount);
            Shot(angle - Mathf.PI / 2, speed);
            Shot(-angle - Mathf.PI / 2, speed);
            yield return new WaitForSeconds(0.1f);
        }
    }

    void PlayerAimShot(int count, float speed)
    {
        if (player != null)
        {
            Vector3 diffPosition = player.transform.position - transform.position;
            float angleP = Mathf.Atan2(diffPosition.y, diffPosition.x);

            int bulletCount = count;
            for (int i=0; i< bulletCount; i++)
            {
                float angle = (i - bulletCount/2) * ((Mathf.PI / 2f) / bulletCount);

                Shot(angleP + angle, speed);
            }
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") == true)
        {
            Instantiate(explosion, collision.transform.position, transform.rotation);
            Destroy(collision.gameObject);

            gameController.GameOver();
        }
        else if (collision.CompareTag("Bullet") == true)
        {
            Hp --;

            Destroy(collision.gameObject);

            if (Hp <= 0)
            {
                Destroy(gameObject);
                Instantiate(explosion, transform.position, transform.rotation);
            }
        }

    }

}
