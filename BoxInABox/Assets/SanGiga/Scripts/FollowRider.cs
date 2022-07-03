using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowRider : MonoBehaviour
{

    public GameObject rider;

    float riderCameraOffsetZ;

    public float rotationSpeed;

    public GameObject road;

    // Start is called before the first frame update
    void Start()
    {
        riderCameraOffsetZ = rider.transform.position.z - transform.position.z;
        Debug.Log("road.transform.localScale.z is " + road.transform.localScale.z);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // keep this a third person view camera
        transform.position = new Vector3(transform.position.x, transform.position.y, rider.transform.position.z - riderCameraOffsetZ);

        // once player reaches end of the road make the camera top down
        if ((transform.position.z > road.transform.localScale.z/2 -10) && (transform.rotation.eulerAngles.x < 60))
        {
            Debug.Log("Inside Condition for camera rotation");
            transform.Rotate(rotationSpeed * Time.deltaTime, 0, 0);
        }
        
    }


}
