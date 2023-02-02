using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //왼쪽 화살표를 눌렀을 때
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.Translate(-1, 0, 0);  //왼쪽으로 1 이동
        }

        //오른쪽 화살표 눌렀을 때
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.Translate(1, 0, 0);  //오른쪽으로 1 이동
        }

        //위쪽 화살표를 눌렀을 때
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            transform.Translate(0, 1, 0);  //위쪽으로 1 이동
        }

        //아래쪽 화살표를 눌렀을 때
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            transform.Translate(0, -1, 0);  //아래쪽으로 1 이동
        }
    }
}
