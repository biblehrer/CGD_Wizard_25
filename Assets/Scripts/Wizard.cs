using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Wizard : MonoBehaviour
{
    public GameObject fireballPrefab;
    private SpriteRenderer sR;
    private Animator animator;
    private float castingCooldown = 0;
    private Vector3 lastDirection = Vector3.right;



    void Start()
    {
        sR = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        Movement();
        Casting();
    }

    private void Movement()
    {
        Vector3 movement = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
        {
            movement = movement + new Vector3(0, 1, 0);
        }

        if (Input.GetKey(KeyCode.S))
        {
            movement += Vector3.down;
        }

        if (Input.GetKey(KeyCode.A))
        {
            movement += Vector3.left;
        }

        if (Input.GetKey(KeyCode.D))
        {
            movement += Vector3.right;
        }

        // Option 1
        if (Input.GetKey(KeyCode.W) ^ Input.GetKey(KeyCode.S))
        {
            if (Input.GetKey(KeyCode.A) ^ Input.GetKey(KeyCode.D))
            {
                movement *= 0.7f;
            }
        }

        // Option 2 easy Solution
        movement.Normalize();

        // Option 3 bei Pseudo Controller
        if (movement.magnitude > 1)
        {
            movement.Normalize();
        }

        // Set the Animatior Values
        if (movement.magnitude > 0)
        {
            lastDirection = movement;
            animator.SetBool("walking", true);
        }
        else
        {
            animator.SetBool("walking", false);
        }

        // Flip the Player
        if (movement.x > 0)
        {
            sR.flipX = false;
        }
        if (movement.x < 0)
        {
            sR.flipX = true;
        }

        // Actually move the Player
        transform.position += movement * Time.deltaTime * 3;
    }

    private void Casting()
    {
        animator.SetBool("attacking", false);
        castingCooldown -= Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Space) && castingCooldown <= 0)
        {
            animator.SetBool("attacking", true);            
            castingCooldown = 1;
        }
    }

    public void CreateFireball()
    {
        float x = 1;
        if (sR.flipX)
        {
            x = -1;
        }
        Vector3 position = transform.position + new Vector3(x, 0.8f, 0);
        GameObject obj = Instantiate(fireballPrefab, position, Quaternion.identity);
        obj.GetComponent<Fireball>().direction = lastDirection;
    }


}
