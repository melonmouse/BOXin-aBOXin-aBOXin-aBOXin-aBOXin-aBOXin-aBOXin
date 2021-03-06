using System;
using DG.Tweening;
using RubenNunez.Scripts;
using UnityEngine;

public class BoxController : MonoBehaviour
{
    [SerializeField]
    private BoxCatcherSceneController _boxCatcherSceneController;
    
    [SerializeField]
    private float speed = 0.05f;

    [SerializeField]
    private GameObject _closed;

    [SerializeField]
    private AudioSource _audioSource;
    
    [SerializeField]
    private AudioClip _audioOpen;
    
    [SerializeField]
    private AudioClip _audioClose;
    
    [SerializeField]
    private GameObject _warningPopUp;

    [SerializeField]
    private Animator _boxAnimator;
    
    [SerializeField]
    private Rigidbody _rigidbody;
    
    private bool _isBoxOpen;

    private void Start()
    {
        _isBoxOpen = false;
        _closed.SetActive(true);
    }


    private void OnTriggerEnter(Collider other)
    {
        if(!_isBoxOpen) return;
        
        try
        {
            if (other.gameObject.tag == "Mini")
            {
                // check if Global Item is other.GameObject
                if (other.gameObject.GetComponent<ItemIdentifier>().item
                    == _boxCatcherSceneController.InputItem ||
                    other.gameObject.GetComponent<ItemIdentifier>().item
                    == BoxItemState.Item.BaseItem)
                {
                    // ShowWarning PopUp and Destroy Item
                    ShowWarning();
                    Destroy(other.gameObject); 
                    return;
                }

                // here is the exit condition
                other.gameObject.GetComponent<ItemIdentifier>().SetAsHeldItem();
                
                // end the scene
                Debug.Log("Destroy Bananas");
                Destroy(other.gameObject);
                
               _boxCatcherSceneController.EndSceneAndGotoNext();
            }
        }
        catch (Exception) { Debug.Log("Was already destroyed"); }
    }

    private void ShowWarning()
    {
        var warningCanvasGroup =_warningPopUp.GetComponentInChildren<CanvasGroup>();
        var sequence = DOTween.Sequence();
        sequence.Insert(0, _warningPopUp.transform.DOShakeScale(0.5f));
        sequence.Insert(0, warningCanvasGroup.DOFade(1f, 0.3f));
        sequence.Insert(2, warningCanvasGroup.DOFade(0f, 0.5f));
    }
    
    private void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            var deltaDir = new Vector3(speed * -1f, 0, 0);
            var newLocalPos = transform.localPosition + deltaDir;
            newLocalPos = Vector3.ClampMagnitude(newLocalPos, 10);
            var newPos = transform.parent.TransformPoint(newLocalPos);
            _rigidbody.MovePosition(newPos);
        }       
        
        if (Input.GetKey(KeyCode.D))
        {
            var deltaDir = new Vector3(speed, 0, 0);
            var newLocalPos = transform.localPosition + deltaDir;
            newLocalPos = Vector3.ClampMagnitude(newLocalPos, 10);
            var newPos = transform.parent.TransformPoint(newLocalPos);
            _rigidbody.MovePosition(newPos);
        } 

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            _boxAnimator.Play(_isBoxOpen ? "box-close-anim" : "box-open-anim");
            _audioSource.clip = _isBoxOpen ? _audioClose : _audioOpen;
            _audioSource.Play();
            
            _isBoxOpen = !_isBoxOpen;
            _closed.SetActive(!_isBoxOpen);
            
        }
    }
}
