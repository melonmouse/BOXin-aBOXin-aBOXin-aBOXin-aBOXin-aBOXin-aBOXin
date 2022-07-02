using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PixlheroInput : MonoBehaviour
{
    public Vector2 GetMoveDirection(){
        Vector2 moveDirection = Vector2.zero;
        if(Input.GetKey(KeyCode.W)){
            moveDirection.y += 1;
        }
        if(Input.GetKey(KeyCode.S)){
            moveDirection.y -= 1;
        }
        if(Input.GetKey(KeyCode.A)){
            moveDirection.x -= 1;
        }
        if(Input.GetKey(KeyCode.D)){
            moveDirection.x += 1;
        }
        return moveDirection;
    }
}
