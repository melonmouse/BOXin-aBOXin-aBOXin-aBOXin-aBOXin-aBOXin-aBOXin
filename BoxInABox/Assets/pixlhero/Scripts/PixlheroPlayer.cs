using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PixlheroInput))]
public class PixlheroPlayer : MonoBehaviour
{
    [SerializeField]
    private float speed = 5f;

    private PixlheroInput input;

    private void Awake() {
        input = GetComponent<PixlheroInput>();
    }

    private void Update() {
        Move();
    }

    private void Move(){
        var moveDir = input.GetMoveDirection() * Time.deltaTime * speed;
        transform.Translate(new Vector3(moveDir.x, 0, moveDir.y), Space.Self);
    }
}
