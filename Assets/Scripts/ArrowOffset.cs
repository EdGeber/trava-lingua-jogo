using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowOffset : MonoBehaviour
{
    public Quaternion rotation;
    void Update()
    {
        Vector2 pos = GameObject.Find("Player").transform.position;
        TL.Direction dir = GameObject.Find("Player").GetComponent<Player>().facingDirection;
        
        if (Input.GetButtonDown("Fire1"))
        {
            /*
            if (dir == TL.Direction.Up)
            {
                transform.position = new Vector2(0f + pos.x, 0.13f + pos.y);
            } else if (dir == TL.Direction.Down)
            {
                transform.position = new Vector2(0f + pos.x, -0.2f + pos.y);
            } else if (dir == TL.Direction.Left)
            {
                transform.position = new Vector2(-0.1f + pos.x, -0.05f + pos.y);
            } else if (dir == TL.Direction.Right)
            {
                transform.position = new Vector2(0.1f + pos.x, -0.05f + pos.y);
            }
            */
            Debug.Log(transform.position);
        }

        if (dir == TL.Direction.Up)
        {
            transform.position = new Vector2(0f + pos.x, 0.15f + pos.y);
            rotation = new Quaternion(0f, 0f, 180f, 0f);
        }
        else if (dir == TL.Direction.Down)
        {
            transform.position = new Vector2(0f + pos.x, -0.2f + pos.y);
            rotation = new Quaternion(0f, 0f, 0f, 0f);
        }
        else if (dir == TL.Direction.Left)
        {
            transform.position = new Vector2(-0.1f + pos.x, -0.05f + pos.y);
            rotation = new Quaternion(0f, 0f, -90f, 0f);
        }
        else if (dir == TL.Direction.Right)
        {
            transform.position = new Vector2(0.1f + pos.x, -0.05f + pos.y);
            rotation = new Quaternion(0f, 0f, 90f, 0f);
        }
        //transform.rotation = rotation;
    }

    public Vector2 GetPos()
    {
        return transform.position;
    }
}
