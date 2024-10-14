using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Molly : MonoBehaviour
{
    public float damage;
    public float damageInterval = 0.2f;

    private List<Enemy> enemiesInRange = new List<Enemy>();
    private bool isDealingDamage = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Enemy enemy = other.GetComponent<Enemy>();
            if (enemy != null && !enemiesInRange.Contains(enemy))
            {
                enemiesInRange.Add(enemy);
            }
            if (!isDealingDamage)
            {
                StartCoroutine(DealDamageOverTime());
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Enemy enemy = other.GetComponent<Enemy>();
            if (enemy != null && enemiesInRange.Contains(enemy))
            {
                enemiesInRange.Remove(enemy);
            }
        }
    }

    IEnumerator DealDamageOverTime()
    {
        isDealingDamage = true;
        while (enemiesInRange.Count > 0)
        {
            foreach (Enemy enemy in enemiesInRange)
            {
                if (enemy != null)
                {
                    enemy.TakeDamage(damage);
                }
            }

            yield return new WaitForSeconds(damageInterval);
        }

        isDealingDamage = false;
    }
}
