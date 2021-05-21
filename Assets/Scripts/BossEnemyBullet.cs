using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemyBullet : MonoBehaviour
{
    float dx;
    float dy;
    public void Setting(float angle, float speed)
    {
        dx = Mathf.Cos(angle) * speed;
        dy = Mathf.Sin(angle) * speed;
    }

    void Update()
    {
        transform.position += new Vector3(dx, dy, 0) * Time.deltaTime;

        if (transform.position.x < -3 || transform.position.x > 3 ||
            transform.position.y < -3 || transform.position.y > 3)
        {
            Destroy(gameObject);
        }
    }

}
