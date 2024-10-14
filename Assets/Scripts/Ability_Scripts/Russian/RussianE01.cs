using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class RussianE01 : Ability
{
    [SerializeField] GameObject mollyPrefabs;    
    [SerializeField] GameObject mollyPrefabsExplode;  

    public float arcHeight = 2f;                       
    public float moveSpeed = 5f;                       
    public float explodeDelay = 0.5f;                 

    public override void Use()
    {
        Vector3 targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        targetPos.z = 0;

        GameObject mollyInstance = Instantiate(mollyPrefabs, transform.position, Quaternion.identity);
        StartCoroutine(MoveMollyInArc(mollyInstance, targetPos));
    }

    IEnumerator MoveMollyInArc(GameObject molly, Vector3 targetPos)
    {
        Vector3 startPos = molly.transform.position;
        float time = 0;

        while (time < 1f)
        {
            time += Time.deltaTime * moveSpeed;
            Vector3 currentPos = Vector3.Lerp(startPos, targetPos, time);
            float arc = arcHeight * Mathf.Sin(Mathf.PI * time);
            currentPos.y += arc;
            molly.transform.position = currentPos;
            yield return null;
        }

        yield return new WaitForSeconds(explodeDelay);
        var mollyExplode = Instantiate(mollyPrefabsExplode, targetPos, Quaternion.identity);
        mollyExplode.transform.DOScale(2.5f, 0.5f);
        mollyExplode.GetComponent<Molly>().damage = damage;
        Destroy(molly);
        Destroy(mollyExplode, 3);
    }
}
