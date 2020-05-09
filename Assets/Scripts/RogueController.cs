using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RogueController : MonoBehaviour
{
    public float speed;
    public int health;
    public int maxHealth;
    
    private Rigidbody2D rb;
    private SpriteRenderer rend;
    private Vector2 moveVelocity;

    private void Start()
    {
        health = 100;
        maxHealth = 100;
        rb = GetComponent<Rigidbody2D>();
        rend = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        Vector3 playerPos = GameObject.FindGameObjectWithTag("Player").transform.position;
        Vector2 moveInput = new Vector2(playerPos.x - rb.position.x, playerPos.y - rb.position.y);
        moveVelocity = moveInput.normalized * speed;

        if (health < 1)
        {
            Destroy(gameObject);
            GameController.currentRogues -= 1;
            PlayerController.score += 50;
        }
        else if (health < maxHealth)
        {
            byte alpha = (byte)((float)health / maxHealth * 205 + 50);
            rend.color = new Color32(255, 0, 0, alpha);
        }
    }
    
    private void FixedUpdate() {
        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Destroy(collision.gameObject);
            health -= 50;
            PlayerController.score += 10;
        }
    }
}