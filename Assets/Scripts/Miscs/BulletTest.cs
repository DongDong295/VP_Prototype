using UnityEngine;

public class BulletTest : MonoBehaviour
{
    public float speed = 20f;
    public float lifetime = 5f; 
    public float damage;
    public Rigidbody2D rb; 

    void Start()
    {
        rb.velocity = transform.right * speed;
        Destroy(gameObject, lifetime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<Enemy>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
