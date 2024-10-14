using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponRotation : MonoBehaviour
{
    public Camera mainCamera;

    public Vector3 direction;

    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        if (Application.isFocused)
        {
            direction = mainCamera.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            CharacterWeaponRotation();
        }
    }

    void CharacterWeaponRotation()
    {
        direction.Normalize();
        float rotation_z = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotation_z);

        Vector2 scale = transform.localScale;
        if (direction.x < 0)
        {
            scale.y = -1;
        }
        else if (direction.x > 0)
        {
            scale.y = 1;
        }
        transform.localScale = scale;
    }
}
