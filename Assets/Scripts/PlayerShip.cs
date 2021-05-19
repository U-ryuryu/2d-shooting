using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShip : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;

    AudioSource audioSource;
    public AudioClip shotSE;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
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
        transform.position += new Vector3(x,y,0)*Time.deltaTime*4f;
    }
}
