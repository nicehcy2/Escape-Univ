using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingTrap : MonoBehaviour
{   
    public Player player;
    public GameObject fallingTrap;
    Rigidbody2D rigid;

    float x, y;

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        x = transform.position.x;
        y = transform.position.y;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Player"))
        {
            rigid.isKinematic = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            player.curHealth -= 20;
            fallingTrap.SetActive(false);
            Init();
        }

        if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Trap")
        {
            fallingTrap.SetActive(false);
            Init();
        }
    }

    private void Init()
    {
        rigid.velocity = new Vector2(0, 0);
        fallingTrap.transform.position = new Vector2(x, y);
        fallingTrap.SetActive(true);
        rigid.isKinematic = true;
    }
}
