using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckersCarController : MonoBehaviour
{
    public GameObject car;

    private Vector3 moveDirection;
    private float speed = 8.0f;

    // Start is called before the first frame update
    void Start()
    {
        if (transform.position.x < 0)
        {
            moveDirection = Vector3.right;
        } else
        {
            moveDirection = Vector3.left;
        }

        speed = Random.Range(8.0f, 8.4f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += moveDirection * speed * Time.deltaTime;

        if (transform.position.x < -15)
        {
            Destroy(this.gameObject);
        } else if (transform.position.x > 15)
        {
            Destroy(this.gameObject);
        }
    }

    public void setSpeed(float itemSpeed)
    {
        speed = itemSpeed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "duckersCar")
        {
            if(collision.transform.position.x < transform.position.x)
            {
                if (moveDirection == Vector3.right)
                {
                    speed += 0.5f;
                }
                else
                {
                    speed -= 0.5f;
                }
            } else if (collision.transform.position.x > transform.position.x)
            {
                if (moveDirection == Vector3.right)
                {
                    speed -= 0.5f;
                }
                else
                {
                    speed += 0.5f;
                }
            }
        }
    }
}
