using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public Vector2 inputVec;
    public float maxSpeed;
    public float jumpPower;

    Rigidbody2D rigid;

    bool isJumping = false;

    // Start is called before the first frame update
    public void Awake()
    {
        jumpPower = 10f;
        maxSpeed = 3f;
        rigid = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump") && !isJumping)
        {
            rigid.velocity = Vector2.zero;
            // rigid.AddForce(new Vector2(0, jumpPower));
            rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            isJumping = false;
        }
        else if (Input.GetButtonUp("Jump") && rigid.velocity.y > 0)
        {
            rigid.velocity = rigid.velocity * 0.5f;
        }

        if (Input.GetButtonUp("Horizontal"))
        {
            rigid.velocity = new Vector2(rigid.velocity.normalized.x * 0.5f, rigid.velocity.y);
        }
    }

    /*
    void OnMove(InputValue value)
    {   
        inputVec = value.Get<Vector2>();
    }*/

    // Update is called once per frame
    void FixedUpdate()
    {   
        // Move By Key Control
        float hor = Input.GetAxis("Horizontal");

        rigid.AddForce(Vector2.right * hor, ForceMode2D.Impulse);

        if (rigid.velocity.x > maxSpeed) // Right Speed;
            rigid.velocity = new Vector2(maxSpeed, rigid.velocity.y);
        else if (rigid.velocity.x < maxSpeed * (-1)) // Left Speed;
            rigid.velocity = new Vector2(maxSpeed * (-1), rigid.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {   
        if (collision.contacts[0].normal.y > 0.7f)
        {
            isJumping = false;
        }
    }
}
