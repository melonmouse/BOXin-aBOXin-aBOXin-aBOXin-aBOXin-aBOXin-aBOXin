using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class PixlheroItemPickup : MonoBehaviour
{
    public BoxItemState.Item itemType;

    [SerializeField]
    private Transform modelParent;

    [SerializeField]
    private float rotateSpeed;

    public void RemoveAfterPickup(){
        Destroy(gameObject);
    }

    private void Update() {
        modelParent.localRotation = Quaternion.Euler(0, rotateSpeed * Time.deltaTime, 0) * modelParent.localRotation;
    }
}
