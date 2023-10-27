using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadScript : MonoBehaviour
{
    [SerializeField]
    private float moveTimer;

    [SerializeField]
    private int moveDirection;
    //1-up 2-right 3-down 4-left

    [SerializeField]
    private int lastMove;

    [SerializeField]
    private int oppositeMove;

    void Start()
    {
        moveDirection = 2;
        oppositeMove = 4;
        lastMove = 2;
        moveTimer = 0f;
        transform.position = Vector3.zero;
    }

    void Update()
    {
        DetectDirection();

        moveTimer += Time.deltaTime;

        if(moveTimer >= 1f)
        {
            moveTimer = 0f;
            if(moveDirection != oppositeMove)
            {
                switch (moveDirection)
                {
                    case 1:
                        transform.position = new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z);
                        oppositeMove = 3;
                        lastMove = 1;
                        break;
                    case 2:
                        transform.position = new Vector3(transform.position.x + 1f, transform.position.y, transform.position.z);
                        oppositeMove = 4;
                        lastMove = 2;
                        break;
                    case 3:
                        transform.position = new Vector3(transform.position.x, transform.position.y - 1f, transform.position.z);
                        oppositeMove = 1;
                        lastMove = 3;
                        break;
                    case 4:
                        transform.position = new Vector3(transform.position.x - 1f, transform.position.y, transform.position.z);
                        oppositeMove = 2;
                        lastMove = 4;
                        break;
                    default:
                        Debug.Log("?????");
                        break;
                }
            }
            else
            {
                switch (lastMove)
                {
                    case 1:
                        transform.position = new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z);
                        oppositeMove = 3;
                        break;
                    case 2:
                        transform.position = new Vector3(transform.position.x + 1f, transform.position.y, transform.position.z);
                        oppositeMove = 4;
                        break;
                    case 3:
                        transform.position = new Vector3(transform.position.x, transform.position.y - 1f, transform.position.z);
                        oppositeMove = 1;
                        break;
                    case 4:
                        transform.position = new Vector3(transform.position.x - 1f, transform.position.y, transform.position.z);
                        oppositeMove = 2;
                        break;
                    default:
                        Debug.Log("?????");
                        break;
                }
            }
        }
    }

    private void DetectDirection()
    {
        if (Input.GetKeyDown("up"))
        {
            moveDirection = 1;
        }
        if (Input.GetKeyDown("right"))
        {
            moveDirection = 2;
        }
        if (Input.GetKeyDown("down"))
        {
            moveDirection = 3;
        }
        if (Input.GetKeyDown("left"))
        {
            moveDirection = 4;
        }
    }
}
