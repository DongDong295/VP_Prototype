using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class RussianUlt02: Ability
{
    public GameObject bombPrefab;
    public GameObject character;

    public override void Use()
    {
        StartCoroutine(Strike());
    }

    void AirstrikeSpawn()
    {
        GameObject bomb = Instantiate(bombPrefab, new Vector3(character.transform.position.x - 10, character.transform.position.y, 0), Quaternion.identity);
        bomb.GetComponent<Airstrike>().damage = damage;
        Destroy(bomb, 5);
    }

    IEnumerator Strike()
    {
        for (int i = 0; i < 2; i++)
        {
            AirstrikeSpawn();
            yield return new WaitForSeconds(0.5f);
        }
           
    }
}
