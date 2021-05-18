using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundScroll : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        transform.Translate(0,-0.01f,0);
        if (transform.position.y < -4.74f)
        {
            transform.position = new Vector3(0,4.74f,0);
        }
    }
}
