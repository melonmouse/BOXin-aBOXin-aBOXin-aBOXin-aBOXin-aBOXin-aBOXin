using UnityEngine;

public class BoxMovement : MonoBehaviour
{
    [SerializeField]
    private float speed = 0.05f;

    [SerializeField]
    private Animator _boxAnimator;


    private bool _isBoxOpen;

    private void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * speed, Space.Self);
        }       
        
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * speed, Space.Self);
        } 

        if (Input.GetKeyDown(KeyCode.Space))
        {
            _boxAnimator.Play(_isBoxOpen ? "box-close-anim" : "box-open-anim");
            _isBoxOpen = !_isBoxOpen;
        }
    }
}
