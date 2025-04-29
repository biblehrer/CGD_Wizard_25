using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * Time.deltaTime * 5;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(collision.gameObject);   
        Destroy(gameObject);              
    }
}
