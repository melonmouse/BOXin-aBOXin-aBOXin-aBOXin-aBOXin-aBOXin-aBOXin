using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class PixlheroItemPickup : MonoBehaviour
{
    public BoxItemState.Item itemType;

    public void RemoveAfterPickup(){
        Destroy(gameObject);
    }
}
