using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    private Animator animator;
    private SpriteRenderer sR;

    void Start()
    {        
        animator = GetComponent<Animator>();
        sR = GetComponent<SpriteRenderer>();
        Destroy(gameObject,5);
        int r = Random.Range(0, 3);
        animator.SetInteger("type", r);
        sR.flipX = true;
        transform.localScale = new Vector3(-1,1,1);
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position += Vector3.left * Time.deltaTime * 5f;
        transform.Translate(Vector3.left * Time.deltaTime * 2);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {         
        Destroy(gameObject);           
    }

}
