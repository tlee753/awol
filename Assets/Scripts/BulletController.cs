using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float speed;

    private Rigidbody2D rb;
    private Vector2 moveVelocity;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        Vector3 playerPos = GameObject.FindGameObjectWithTag("Player").transform.position;
        Vector2 moveDir = new Vector2(rb.position.x - playerPos.x, rb.position.y - playerPos.y);
        moveVelocity = moveDir.normalized * speed;
    }

    private void Update()
    {
        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
        Destroy(gameObject, 10f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
