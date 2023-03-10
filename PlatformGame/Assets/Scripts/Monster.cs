using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    Rigidbody2D rigid;
    public Player player;
    SpriteRenderer spriteRenderer;
    Vector3 pos; //������ġ
    public float delta = 5.0f; // ��(��)�� �̵������� (x)�ִ밪
    float speed = 2.0f; // �̵��ӵ�

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = rigid.GetComponent<SpriteRenderer>();
        pos = transform.position;
    }


    void Update()
    {
        Vector3 v = pos;
        if (rigid.transform.position.x < pos.x - delta)
        {
            speed *= -1;
            //rigid.transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
            spriteRenderer.flipX = false;
        }
        if (rigid.transform.position.x > pos.x + delta)
        {
            speed *= -1;
            //rigid.transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
            spriteRenderer.flipX = true;
        }
        rigid.transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            player.curHealth -= 20;
        }
    }
}
