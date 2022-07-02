using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PixlheroFollowCamera : MonoBehaviour
{
    [SerializeField]
    private Transform player;

    [SerializeField]
    private float height;

    [SerializeField]
    private float distance;

    // Update is called once per frame
    public void UpdateCamera()
    {
        var centerOnHeightPlane = player.transform.position + player.transform.up * height;
        var heightPlane = new Plane(player.transform.up, centerOnHeightPlane);
        transform.position = heightPlane.ClosestPointOnPlane(transform.position);
        var radialVector = (transform.position - centerOnHeightPlane).normalized;
        transform.position = centerOnHeightPlane + radialVector * distance;

        transform.LookAt(player, player.up);
    }
}
