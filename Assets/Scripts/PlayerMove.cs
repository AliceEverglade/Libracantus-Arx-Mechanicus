using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float speed;
    Vector2 mousePos;
    Transform playerTrans;
    Vector2 objPos;
    Vector2 move;
    Vector2 dir;
    float angle;

    public Direction AttackDir;
    public enum Direction
    {
        North,
        NorthEast,
        East,
        SouthEast,
        South,
        SouthWest,
        West,
        NorthWest
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        dir = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        move = dir.normalized;
        float X =  move.x * Time.fixedDeltaTime;

        transform.Translate(0, X * speed, 0);

        float Y =  move.y * Time.fixedDeltaTime;

        transform.Translate((Y * speed), 0, 0);
        Debug.Log(X);
    }
    private void Update()
    {
        mousePos = Input.mousePosition;
        mousePos.x = mousePos.x - objPos.x;
        mousePos.y = mousePos.y - objPos.y;
    }

    private void setBalls()
    {
       if (dir.x < 0 && dir.y >= 0.1)
        {
            //AttackDir == Direction.North;
        }
    }
}

