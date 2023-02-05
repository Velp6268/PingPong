using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;


public class Pad : MonoBehaviour
{

    [SerializeField]
    float speed;

    float height;
    string inpt;
    public bool isRightPad;

    public void Init(bool isRight)
    {
        isRightPad = isRight;
        Vector2 pos = Vector2.zero;

        // Обрабатываем изменение позиции ракетки. Для левой и правой ракетки - отдельно.
        if (isRight)
        {
            pos = new Vector2(GameManager.bottomRight.x, 0);
            pos -= Vector2.right * transform.localScale.x;
            inpt = "PadRight";
        }
        else
        {
            pos = new Vector2(GameManager.bottomLeft.x, 0);
            pos += Vector2.right * transform.localScale.x;
            inpt = "PadLeft";
        }

        transform.position = pos;
        transform.name = inpt;
    }


    void Start()
    {
        height = transform.localScale.y;
    }

    // Update is called once per frame
    void Update()
    {
        float move = UnityEngine.Input.GetAxis(inpt) * Time.deltaTime * speed;

        if (transform.position.y < GameManager.bottomLeft.y + height / 2 && move < 0)
        {
            move = 0;
        }

        if (transform.position.y > GameManager.bottomRight.y - height / 2 && move > 0)
        {
            move = 0;
        }

        transform.Translate(move * Vector2.up);

    }
}
