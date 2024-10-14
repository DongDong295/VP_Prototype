using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Airstrike : MonoBehaviour
{
    public float damage;
    public float speed = 20;

    private void Update()
    {
        gameObject.transform.Translate(Vector3.right * Time.deltaTime * speed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<Enemy>().TakeDamage(damage);
        }
    }
}
