using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    Rigidbody2D checkPoint;
    public Player player;

    private void Start()
    {
        checkPoint = GetComponent<Rigidbody2D>();   
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            player.spawnPoint = new Vector2(checkPoint.transform.position.x, checkPoint.transform.position.y + 10);
        }
    }
}
