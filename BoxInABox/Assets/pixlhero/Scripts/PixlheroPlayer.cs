using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PixlheroInput))]
[RequireComponent(typeof(Orienter))]
public class PixlheroPlayer : MonoBehaviour
{
    [SerializeField]
    private float speed = 5f;


    private PixlheroInput _input;

    private Orienter _orienter;

    private void Awake() {
        _orienter = GetComponent<Orienter>();
        _input = GetComponent<PixlheroInput>();
    }

    private void Update() {
        Move();
        _orienter.Orient();
    }

    private void Move(){
        var inputDir = _input.GetMoveDirection() * Time.deltaTime * speed;
        var moveDir = Camera.main.transform.TransformDirection(new Vector3(inputDir.x,  inputDir.y, 0f));
        transform.Translate(moveDir, Space.World);
    }
}
