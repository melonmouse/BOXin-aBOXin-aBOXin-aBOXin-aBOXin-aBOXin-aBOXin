using UnityEngine;

public class BoxController : MonoBehaviour
{
    [SerializeField]
    private float speed = 0.05f;

    [SerializeField]
    private GameObject _closed;
    
    [SerializeField]
    private Animator _boxAnimator;
    
    [SerializeField]
    private Rigidbody _rigidbody;
    
    private bool _isBoxOpen;

    private Vector3 _movementAxis;
    
    private void Start()
    {
        _movementAxis = transform.right;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            var deltaDir = _movementAxis * (speed * -1f);
            _rigidbody.MovePosition(transform.position + deltaDir);
        }       
        
        if (Input.GetKey(KeyCode.D))
        {
            var deltaDir = _movementAxis * speed;
            _rigidbody.MovePosition(transform.position + deltaDir);
        } 

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            _boxAnimator.Play(_isBoxOpen ? "box-close-anim" : "box-open-anim");
            _isBoxOpen = !_isBoxOpen;
            _closed.SetActive(!_isBoxOpen);
        }
    }
}
