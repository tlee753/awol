using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public FloatingJoystick leftJoystick;

    public static int score;
    public float speed;
    public int health;
    public int maxHealth;
    public Material defaultMat;
    
    private Rigidbody2D rb;
    private SpriteRenderer rend;
    private Vector2 moveVelocity;
    
    private void Awake()
    {
        health = 150;
    }

    private void Start()
    {
        maxHealth = 150;

        rb = GetComponent<Rigidbody2D>();
        rend = GetComponent<SpriteRenderer>();
        leftJoystick = GameObject.Find("LeftJoystick").GetComponent<FloatingJoystick>();
    }

    private void Update()
    {
        // Vector2 moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        Vector2 touchInput = leftJoystick.Direction;

        moveVelocity = touchInput.normalized * speed;

        if (health < 1)
        {
            rend.color = new Color32(255, 255, 255, 255);
        }
        else if (health < maxHealth)
        {
            byte alpha = (byte) ((float)health / maxHealth * 100 + 155);
            rend.color = new Color32(123, 175, 212, alpha);
            health += 1;
        }
    }

    private void FixedUpdate() {
        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Rogue")
        {
            health -= 5;
        }
    }
}
