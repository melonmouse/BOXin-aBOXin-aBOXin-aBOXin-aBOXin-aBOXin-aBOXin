using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PixlheroInput : MonoBehaviour
{
    [SerializeField]
    private float lerpSmoothFactor;

    private Vector2 _previousDir;

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
        if(moveDirection.magnitude <= 0.01){
            return Vector2.zero;
        }

        if(Vector2.Angle(moveDirection, _previousDir) > 175f){
            _previousDir = Quaternion.AngleAxis(10f, Vector3.forward) * _previousDir;
        }

        var newDir = Vector3.Lerp(_previousDir, moveDirection, lerpSmoothFactor * Time.deltaTime).normalized;
        _previousDir = newDir;
        return newDir;
    }
}
