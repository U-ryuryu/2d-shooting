using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    public GameObject EnemyPrefab;
    public GameObject BossEnemyPrefab;

    void Start()
    {
        InvokeRepeating("Spawn", 2f, 0.5f);
        Invoke("BossSpawn", 4f);
    }

    void Spawn()
    {
        Vector3 spawnPosition = new Vector3(
            Random.Range(-2.8f, 2.8f),
            transform.position.y, 
            transform.position.z
            );
        Instantiate(
            EnemyPrefab, 
            spawnPosition, 
            transform.rotation
            );
    }

    void BossSpawn()
    {
        Instantiate(
            BossEnemyPrefab, 
            transform.position, 
            transform.rotation
            );
            CancelInvoke();
    }
}
