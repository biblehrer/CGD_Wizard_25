using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {           
        if (collision.gameObject.tag == "Projectile")
        {
            Destroy(gameObject);  
        }          
    }
}
