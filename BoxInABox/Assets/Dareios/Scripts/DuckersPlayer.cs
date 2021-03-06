using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DuckersPlayer : MonoBehaviour
{
    public GameObject player;
    public GameObject heldItem;
    public GameObject collector;

    private float speed = 3.6f;

    [SerializeField]
    private Animator animator;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            transform.SetPositionAndRotation(transform.position, Quaternion.LookRotation(Vector3.forward));
            transform.position += Vector3.forward * speed * Time.deltaTime;

            animator.SetFloat("speed", (Vector3.forward * speed * Time.deltaTime).magnitude);

            if(transform.position.z > 7.5)
            {
                transform.position += Vector3.back * 2 * speed * Time.deltaTime;
            }
        }
        if(Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            transform.SetPositionAndRotation(transform.position, Quaternion.LookRotation(Vector3.back));
            transform.position += Vector3.back * speed * Time.deltaTime;

            animator.SetFloat("speed", (Vector3.back * speed * Time.deltaTime).magnitude);

            if (transform.position.z < -11)
            {
                transform.position += Vector3.forward * 2 * speed * Time.deltaTime;
            }
        }
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            transform.SetPositionAndRotation(transform.position, Quaternion.LookRotation(Vector3.left));
            transform.position += Vector3.left * speed * Time.deltaTime;

            animator.SetFloat("speed", (Vector3.left * speed * Time.deltaTime).magnitude);

            if (transform.position.x < -9)
            {
                transform.position += Vector3.right * 2 * speed * Time.deltaTime;
            }
        }
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            transform.SetPositionAndRotation(transform.position, Quaternion.LookRotation(Vector3.right));
            transform.position += Vector3.right * speed * Time.deltaTime;

            animator.SetFloat("speed", (Vector3.right * speed * Time.deltaTime).magnitude);

            if (transform.position.x > 9)
            {
                transform.position += Vector3.left * 2 * speed * Time.deltaTime;
            }
        }

        if(Input.anyKey == false)
        {
            animator.SetFloat("speed", 0);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "duckersCar")
        {
            transform.position = new Vector3(0, 0, -10);
        }

        if (collision.gameObject.tag == "itemToCollect")
        {
            //set collected item to game
            collision.transform.GetComponent<ItemIdentifier>().SetAsHeldItem();

            //display collected item
            if (BoxItemState.Instance.HeldItem == BoxItemState.Item.Banana)
            {
                collector.GetComponent<Collectormanager>().ActivateCollected(0);
            }
            else if (BoxItemState.Instance.HeldItem == BoxItemState.Item.ButterflyCatchingNet)
            {
                collector.GetComponent<Collectormanager>().ActivateCollected(1);
            }
            else if (BoxItemState.Instance.HeldItem == BoxItemState.Item.Mallet)
            {
                collector.GetComponent<Collectormanager>().ActivateCollected(2);
            }
            else if (BoxItemState.Instance.HeldItem == BoxItemState.Item.Motorcycle)
            {
                collector.GetComponent<Collectormanager>().ActivateCollected(3);
            }
            else if (BoxItemState.Instance.HeldItem == BoxItemState.Item.HourGlass)
            {
                collector.GetComponent<Collectormanager>().ActivateCollected(4);
            }

            collision.gameObject.SetActive(false);
        }

        if (collision.gameObject.name == "portalBox")
        {
            SceneTransition.GoToRandomNextScene();
        }
    }

    public void StepLeft()
    {
        // do nothing
    }

    public void StepRight()
    {
        // do nothing
    }

    public void SetSpeed (int newSpeed)
    {
        this.speed = newSpeed;
    }
}
