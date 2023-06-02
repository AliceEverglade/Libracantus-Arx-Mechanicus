using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private bool isFacingRight = false;
    Vector2 mousePos;
    Transform playerTrans;
    Vector2 objPos;
    Vector2 move;
    float angle;

    Rigidbody2D rb;
    PlayerAnimation animator;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<PlayerAnimation>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        /*float X =  move.x * Time.fixedDeltaTime;

        transform.Translate(X * speed, 0, 0);

        float Y =  move.y * Time.fixedDeltaTime;

        transform.Translate(0, (Y * speed), 0);
        Debug.Log(X);*/
        if(move.x != 0 && !animator.isAttacking || move.y != 0 && !animator.isAttacking)
        {
                rb.velocity = move * speed;
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }
    private void Update()
    {
        move = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
        mousePos = Input.mousePosition;
        mousePos.x = mousePos.x - objPos.x;
        mousePos.y = mousePos.y - objPos.y;

        CheckDir();
    }

    private void CheckDir()
    {
        if (!isFacingRight && rb.velocity.x > 0.1f || isFacingRight && rb.velocity.x < -0.1f) 
        {
            flip();
        }
    }

    private void flip()
    {
        isFacingRight = !isFacingRight;
        transform.Rotate(0, 180, 0);
    }
}

