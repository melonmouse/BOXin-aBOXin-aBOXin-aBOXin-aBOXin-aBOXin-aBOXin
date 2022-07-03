using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MotorcycleController : MonoBehaviour
{

    //TODO: add motorcycle SFX to Rider / Audio Source
    //TODO: add BG Music to BGMusicPlayer / Audio Source

    //TODO: make motorcycle wheels rotate

    float xInput;
    public float xSteerSpeed;
    public float xLimit;

    public float zSpeed;

    public GameObject road;

    // SFX variables
    float nextTimeToPlayMotorcycleSFX;
    AudioSource audioSource;


    CapturedObjectManager capturedObjectManager;


    private void Awake()
    {
        capturedObjectManager = FindObjectOfType<CapturedObjectManager>();
        audioSource = GetComponent<AudioSource>();
    }

    // Start is called before the first frame update
    void Start()
    {
        nextTimeToPlayMotorcycleSFX = Time.time + Random.Range(0.5f, 4f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //only allow steering on the road
        if (transform.position.z < (road.transform.localScale.z / 2))
        {
            // steer motorcycle
            xInput = Input.GetAxis("Horizontal");
            transform.Translate(new Vector3(xInput * xSteerSpeed * Time.deltaTime, 0, 0));
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, -xLimit, xLimit), transform.position.y, transform.position.z);
        }


        // move motorcycle forward
        transform.Translate(new Vector3(0, 0, zSpeed * Time.deltaTime));

        //change to next scene once the motorcycle is a a certain distance inside the box
        if (transform.position.y < -50)
        {

            SceneTransition.GoToRandomNextScene();
        }

        // Play motorcycle SFX at random times
        if (Time.time > nextTimeToPlayMotorcycleSFX)
        {
            audioSource.Play();
            nextTimeToPlayMotorcycleSFX = Time.time + Random.Range(0.5f, 4f);
        }


    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnTriggerEnter");

        if (!other.CompareTag("Road"))
        {// TODO: change GetComponentInParent to GetComponent OR GetComponentInChildren in case I change where the collider is in the prefabs use
            // below I will activate on the current held object on the top right corner
            if (other.GetComponentInChildren<ItemIdentifier>().item == BoxItemState.Item.Banana)
            {
                capturedObjectManager.ActivateItemNumbered(0);
            }
            else if (other.GetComponentInChildren<ItemIdentifier>().item == BoxItemState.Item.ButterflyCatchingNet)
            {
                capturedObjectManager.ActivateItemNumbered(1);
            }
            else if (other.GetComponentInChildren<ItemIdentifier>().item == BoxItemState.Item.Mallet)
            {
                capturedObjectManager.ActivateItemNumbered(2);
            }
            else if (other.GetComponentInChildren<ItemIdentifier>().item == BoxItemState.Item.Motorcycle)
            {
                capturedObjectManager.ActivateItemNumbered(3);
            }

            //capturedObjectManager.ActivateItemNumbered(i);

            other.transform.GetComponentInChildren<ItemIdentifier>().SetAsHeldItem(); // here this is the item that is kept, for the next scene, if I call this method again, it will replace the previously held item, which is exactly what I need

            Debug.Log("other.transform.GetComponentInParent<ItemIdentifier>().SetAsHeldItem() is " + other.transform.GetComponentInChildren<ItemIdentifier>().item);
            //destroy object
            GameObject.Destroy(other.gameObject);
        }

        /*
        // depending on the tag of collided object, actiavate the right item on display and to pass on to the next level
        for (int i = 0; i < 10; i++)
        {
            if (other.CompareTag(i.ToString()))
            {
                capturedObjectManager.ActivateItemNumbered(i);
                other.transform.GetComponent<ItemIdentifier>().SetAsHeldItem(); // here this is the item that is kept, for the next scene, if I call this method again, it will replace the previously held item, which is exactly what I need
                // destroy object
                GameObject.Destroy(other.gameObject);

                break;
            }
        }
        */

    }
}
