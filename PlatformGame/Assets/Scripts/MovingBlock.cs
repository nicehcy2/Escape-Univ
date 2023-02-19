using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBlock : MonoBehaviour
{
    Rigidbody2D rigid;
    Vector3 pos; //������ġ
    float delta = 4.0f; // ��(��)�� �̵������� (x)�ִ밪
    float speed = 0.7f; // �̵��ӵ�

    void Start()
    {   
        rigid = GetComponent<Rigidbody2D>();
        pos = transform.position;
    }


    void Update()
    { 
        Vector3 v = pos;
        v.x += delta * Mathf.Sin(Time.time * speed);
        transform.position = v;
    }
}
