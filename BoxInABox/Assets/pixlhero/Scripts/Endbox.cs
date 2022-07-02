using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Endbox : MonoBehaviour
{
    [SerializeField]
    private Animator animator;

    private PixlheroPlayer player;

    [SerializeField]
    private float openDistance;

    [SerializeField]
    private Transform canvas;

    private bool _playerIsClose;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PixlheroPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdatePlayerCloseness();
        UpdateModelOpen();
        UpdateCanvas();
    }

    private void UpdateCanvas(){
        var toCamera = Camera.main.transform.position - canvas.position;
        var toCameraOnPlane = Vector3.ProjectOnPlane(toCamera, canvas.parent.up);
        canvas.LookAt(canvas.position - toCameraOnPlane, canvas.parent.up);
    }

    private void UpdateModelOpen(){
        if(BoxItemState.Instance.HeldItem == BoxItemState.Item.BaseItem){
            animator.SetBool("Open", false);
            return;
        }

        animator.SetBool("Open", _playerIsClose);
    }

    private void UpdatePlayerCloseness(){
        var distanceToPlayer = (transform.position - player.transform.position).magnitude;
        if(_playerIsClose && distanceToPlayer > openDistance)
        {
            PlayerGotFar();
        }else if(!_playerIsClose && distanceToPlayer + 1 < openDistance)
        {
            PlayerGotClose();
        }
    }

    private void PlayerGotClose(){
        _playerIsClose = true;

        if(BoxItemState.Instance.HeldItem == BoxItemState.Item.BaseItem){
            canvas.gameObject.SetActive(true);
            canvas.DOShakeScale(0.3f, 0.7f, 15, 90);
        }
    }

    private void PlayerGotFar(){
        _playerIsClose = false;

        canvas.gameObject.SetActive(false);
    }
}
