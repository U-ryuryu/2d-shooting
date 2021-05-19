using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShip : MonoBehaviour
{
    public GameObject explosion;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position -= new Vector3(0, Time.deltaTime, 0);
    }

    // isTriggerにチェックをつけた場合こちらが実行される。
    private void OnTriggerEnter2D(Collider2D collision)
    {
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
