using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] CharacterStats characterStats;

    protected string characterName {  get; private set; }
    protected float speed { get; private set; }

    public static float ultPoint;
    [SerializeField] Rigidbody2D rb;

    private Vector2 movement;

    private void Awake()
    {
        InitializeCharacter();
    }

    public virtual void Start()
    {
        
    }

    public virtual void Update()
    {
        MovementInput();
    }

    public virtual void FixedUpdate()
    {
        CharacterMovement();
    }

    void InitializeCharacter()
    {
        characterName = characterStats.characterName;
        speed = characterStats.speed;
    }

    void MovementInput()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    void CharacterMovement()
    {
        rb.MovePosition(rb.position + movement.normalized * speed * Time.fixedDeltaTime);
    }

    public static void IncreaseUlt(float amount)
    {
        if(ultPoint < 100)
            ultPoint += amount * 0.5f;
        if(ultPoint > 100)
        {
            ultPoint = 100; 
        }
    }

    public IEnumerator IncreaseSpeedTemp(float amount, float time)
    {
        var base_speed = speed;
        speed += amount;
        yield return new WaitForSeconds(time);
        speed = base_speed;
    }
}
