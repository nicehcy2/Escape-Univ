using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public float maxSpeed;
    public float jumpPower;
    public float maxHealth;
    public float curHealth;
    public Vector2 spawnPoint;
    public bool isLive;

    Rigidbody2D rigid;
    SpriteRenderer spriter;
    Animator anim;

    public bool isJumping = false;

    // Start is called before the first frame update
    public void Awake()
    {
        jumpPower = 10f;
        maxSpeed = 3f;
        maxHealth = 20f;
        curHealth = maxHealth;
        isLive = true;
        spawnPoint = new Vector2(-1f, -1.4f);
        rigid = GetComponent<Rigidbody2D>();
        spriter = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (isLive)
        {
            if (Input.GetButton("Jump") && !isJumping)
            {
                rigid.velocity = Vector2.zero;
                // rigid.AddForce(new Vector2(0, jumpPower));
                rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
                isJumping = true;
            }
            else if (Input.GetButtonUp("Jump") && rigid.velocity.y > 0)
            {
                rigid.velocity = rigid.velocity * 0.5f;
            }

            if (Input.GetButtonUp("Horizontal"))
            {
                rigid.velocity = new Vector2(rigid.velocity.normalized.x * 0.5f, rigid.velocity.y);
            }

            if (Input.GetButtonDown("Horizontal"))
                spriter.flipX = Input.GetAxisRaw("Horizontal") == -1;

            if (curHealth <= 0)
            {
                Dead();
            }

            if (Mathf.Abs(rigid.velocity.x) < 0.3)
            {
                anim.SetBool("isWalking", false);
            }
            else
            {
                anim.SetBool("isWalking", true);
            }
        }
    }
    void FixedUpdate()
    {
        if (isLive)
        {
            // Move By Key Control
            float hor = Input.GetAxis("Horizontal");

            rigid.AddForce(Vector2.right * hor, ForceMode2D.Impulse);

            if (rigid.velocity.x > maxSpeed) // Right Speed;
                rigid.velocity = new Vector2(maxSpeed, rigid.velocity.y);
            else if (rigid.velocity.x < maxSpeed * (-1)) // Left Speed;
                rigid.velocity = new Vector2(maxSpeed * (-1), rigid.velocity.y);
        }

        // Landing Platform
        if (rigid.velocity.y < 0)
        {
            Debug.DrawRay(rigid.position, Vector3.down, new Color(0, 1, 0));

            RaycastHit2D rayHit = Physics2D.Raycast(rigid.position, Vector3.down, 1, LayerMask.GetMask("Platform"));

            if (rayHit.collider != null)
            {
                if (rayHit.distance <= 0.8f)
                {
                    isJumping = false;
                }
            }
        }
    }


    private void Dead()
    {
        isLive = false;
        transform.position = spawnPoint;
        Init();
    }

    private void Init()
    {
        curHealth = maxHealth;
        isLive = true;
        isJumping = false;
    }

}
