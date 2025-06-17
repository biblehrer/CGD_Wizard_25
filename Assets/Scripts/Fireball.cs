using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    private Animator animator;
    private SpriteRenderer sR;
    public Vector3 direction;

    void Start()
    {
        Destroy(gameObject, 5);
        //SetAnimation();
        AdjustRotation2(direction);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += direction * Time.deltaTime * 5f;
        //transform.Translate(direction * Time.deltaTime * 2);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }

    void SetAnimation()
    {
        animator = GetComponent<Animator>();
        sR = GetComponent<SpriteRenderer>();
        int r = Random.Range(0, 3);
        animator.SetInteger("type", r);
        sR.flipX = true;
        transform.localScale = new Vector3(-1, 1, 1);
    }
    
    public void AdjustRotation(Vector3 direction)
    {
        float angle = Vector3.Angle(direction, Vector3.left);        
        if (direction.y > 0)
        {
            angle = angle * -1;
        }
        transform.localRotation = Quaternion.Euler(0,0,angle);
    }

    public void AdjustRotation3(Vector3 direction)
    {
        // TODO finish Code
        float angle = 0;        
        if (direction.y != 0)
        {
            if (direction.y > 0)
            {
                angle = 270;
            }
            else
            {
                angle = 90;
            }
            angle = angle * -1;
        }
        transform.localRotation = Quaternion.Euler(0,0,angle);
    }

    public void AdjustRotation2(Vector3 direction)
    {
        transform.right = direction*-1;       
    }


}
