using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    public GameObject enemyPrefab;
    void Start()
    {
        InvokeRepeating("Spawn", 2f, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Spawn()
    {
        Vector3 spawnPosition = new Vector3(
            Random.Range(-2.8f, 2.8f),
            transform.position.y, 
            transform.position.z
            );
        Instantiate(
            enemyPrefab, 
            spawnPosition, 
            transform.rotation
            );
    }

}
