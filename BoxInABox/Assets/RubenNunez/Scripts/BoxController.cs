using System;
using UnityEngine;

public class BoxController : MonoBehaviour
{
    [SerializeField]
    private float speed = 0.05f;

    [SerializeField]
    private GameObject _closed;
    
    [SerializeField]
    private GameObject _trigger;

    [SerializeField]
    private Animator _boxAnimator;
    
    [SerializeField]
    private Rigidbody _rigidbody;
    
    private bool _isBoxOpen;

    private void OnTriggerEnter(Collider other)
    {
        try
        {
            if (other.gameObject.tag == "Mini")
            {
                Debug.Log("Destroy Bananas");
                Destroy(other.gameObject);    
            }
        }
        catch (Exception) { Debug.Log("Was already destroyed"); }
    }
    


    private void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            var deltaDir = new Vector3(speed * -1f, 0, 0);
            var newLocalPos = transform.localPosition + deltaDir;
            newLocalPos = Vector3.ClampMagnitude(newLocalPos, 15);
            var newPos = transform.parent.TransformPoint(newLocalPos);
            _rigidbody.MovePosition(newPos);
        }       
        
        if (Input.GetKey(KeyCode.D))
        {
            var deltaDir = new Vector3(speed, 0, 0);
            var newLocalPos = transform.localPosition + deltaDir;
            newLocalPos = Vector3.ClampMagnitude(newLocalPos, 15);
            var newPos = transform.parent.TransformPoint(newLocalPos);
            _rigidbody.MovePosition(newPos);
        } 

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            _boxAnimator.Play(_isBoxOpen ? "box-close-anim" : "box-open-anim");
            _isBoxOpen = !_isBoxOpen;
            _closed.SetActive(!_isBoxOpen);
        }
    }
}
