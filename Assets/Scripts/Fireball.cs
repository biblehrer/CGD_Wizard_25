using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    void Start()
    {
        Destroy(gameObject,5);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * Time.deltaTime * 5f;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {         
        Destroy(gameObject);             
    }
}
