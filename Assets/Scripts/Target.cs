using UnityEngine;

public class Target : MonoBehaviour
{
    public GameObject targetPefab;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Projectile")
        {
            CreateTarget();
            Destroy(gameObject);
            Destroy(collision.gameObject);            
        }
    }

    void CreateTarget()
    {
        float x = Random.Range(8f,-8);
        float y = Random.value*9 -4.5f;
        Vector3 postion = new Vector3(x,y,0);
        Instantiate(targetPefab, postion, Quaternion.identity);
    }
    
}
