using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShip : MonoBehaviour
{
    public Transform firePoint;
    public GameObject explosion;
    public GameObject bulletPrefab;

    GameController gameController;
    float offset;

    // Start is called before the first frame update
    void Start()
    {
        offset = Random.Range(0, 2f * Mathf.PI);
        InvokeRepeating("Shot", 2f, 1f);
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
    }

    void Shot()
    {
        Instantiate(bulletPrefab, firePoint.position, transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position -= new Vector3(
            Mathf.Cos(Time.frameCount * 0.05f + offset) * 0.01f,
            Time.deltaTime, 
            0
        );

        if (transform.position.y < -3)
        {
            Destroy(gameObject);
        }
    }

    // isTriggerにチェックをつけた場合こちらが実行される。
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") == true)
        {
            Instantiate(explosion, collision.transform.position, transform.rotation);
            gameController.GameOver();
        }
        else if (collision.CompareTag("Bullet") == true)
        {
            gameController.AddScore();
        }
        else if (collision.CompareTag("EnemyBullet") == true)
        {
            return;
        }
        else if (collision.CompareTag("BossEnemy") == true)
        {
            return;
        }
        
        Instantiate(explosion, transform.position, transform.rotation);
        Destroy(gameObject);
        Destroy(collision.gameObject);
    }
    /* isTriggerにチェックをつけてない場合こちらが実行される。
    private void OnCollisionEnter2D(Collision2D collision)
    {
    }
    */
}
