using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PixlheroInput))]
[RequireComponent(typeof(Orienter))]
[RequireComponent(typeof(PixlheroItemPickuper))]
public class PixlheroPlayer : MonoBehaviour
{
    [SerializeField]
    private float speed = 5f;

    [SerializeField]
    private PixlheroFollowCamera followCamera;

    [SerializeField]
    private Transform model;

    private PixlheroInput _input;

    private Orienter _orienter;

    private PixlheroItemPickuper _itemPickuper;

    [SerializeField]
    private Animator animator;

    [SerializeField]
    private DuckCanvas duckCanvas;

    private void Awake() {
        _orienter = GetComponent<Orienter>();
        _input = GetComponent<PixlheroInput>();
        _itemPickuper = GetComponent<PixlheroItemPickuper>();

        _itemPickuper.OnItemPickedUp += OnItemPickedUp;
        _itemPickuper.EndboxTouched += OnEndboxTouched;
    }

    private void Update() {
        Move();
        _orienter.Orient();
        followCamera.UpdateCamera();
    }

    private void Move(){
        var check = transform.up;

        var inputDir = _input.GetMoveDirection() * Time.deltaTime * speed;
        var moveDir = followCamera.transform.TransformDirection(new Vector3(inputDir.x,  inputDir.y, 0f));
        transform.Translate(moveDir, Space.World);
        model.transform.LookAt(transform.position + moveDir, transform.up);
        var rotateToUp = Quaternion.FromToRotation(model.up, transform.up);
        model.rotation = rotateToUp * model.rotation;

        animator.SetFloat("speed", inputDir.magnitude);
    }

    private void OnItemPickedUp(PixlheroItemPickup item){
        BoxItemState.Instance.HeldItem = item.itemType;
        duckCanvas.SetItem(item.itemType);
    }

    private void OnEndboxTouched(Endbox endbox){
        if(BoxItemState.Instance.HeldItem == BoxItemState.Item.BaseItem){
            return;
        }
        
        SceneTransition.GoToRandomNextScene();
    }
}
