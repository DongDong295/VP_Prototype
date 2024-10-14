using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RussianQ01 : Ability
{
    [SerializeField] RussianAttack attack;
    [SerializeField] Character character;

    [SerializeField] GameObject bottlePrefab;
    [SerializeField] float tiltAngle = 30f;
    [SerializeField] float tiltDuration = 1f;

    public override void Use()
    {
        attack.StartCoroutine(attack.IncreaseAttackTemp(5, 5));
        character.StartCoroutine(character.IncreaseSpeedTemp(5, 5));
        StartCoroutine(DrinkBottle());
    }

    private IEnumerator DrinkBottle()
    {
        Quaternion originalRotation = bottlePrefab.transform.rotation;
        Quaternion targetRotation = originalRotation * Quaternion.Euler(0, 0, -tiltAngle);
        float elapsedTime = 0;
        while (elapsedTime < tiltDuration)
        {
            bottlePrefab.transform.rotation = Quaternion.Slerp(originalRotation, targetRotation, elapsedTime / tiltDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        bottlePrefab.transform.rotation = targetRotation;
        yield return new WaitForSeconds(0.3f);
        elapsedTime = 0;
        while (elapsedTime < tiltDuration)
        {
            bottlePrefab.transform.rotation = Quaternion.Slerp(targetRotation, originalRotation, elapsedTime / tiltDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        bottlePrefab.transform.rotation = originalRotation;
    }
}
