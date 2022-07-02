using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inputs : MonoBehaviour
{
    static public bool Up()
    {
        return Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W);
    }

    static public bool Down()
    {
        return Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S);
    }

    static public bool Left()
    {
        return Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A);
    }

    static public bool Right()
    {
        return Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D);
    }

    static public Vector2 Direction()
    {
        Vector2 result = new Vector2(Right() ? 1 : 0, Up() ? 1 : 0) - 
                         new Vector2(Left() ? 1 : 0, Down() ? 1 : 0);
        return result.normalized;
    }

    static public bool Action()
    {
        return Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.E) ||
            Input.GetKey(KeyCode.Return);
    }
}
