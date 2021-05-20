using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShip : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public GameObject explosion;
    GameController gameController;

    AudioSource audioSource;
    public AudioClip shotSE;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
    }
    void Update()
    {
        Shot();
        Move();
    }
    void Shot()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bulletPrefab, firePoint.position, transform.rotation);
            audioSource.PlayOneShot(shotSE);
        }
    }
    void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        Vector3 nextPosition = transform.position + new Vector3(x,y,0)*Time.deltaTime * 4f;
        nextPosition = new Vector3(
            Mathf.Clamp(nextPosition.x, -2.9f, 2.9f),
            Mathf.Clamp(nextPosition.y, -1.9f, 1.9f),
            nextPosition.z
        );
        transform.position = nextPosition;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("EnemyBullet") == true)
        {
            Instantiate(explosion, collision.transform.position, transform.rotation);
            Destroy(gameObject);
            Destroy(collision.gameObject);
            gameController.GameOver();
        }
    }
}
