using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PixlheroItemPickuper : MonoBehaviour
{
    public event Action<PixlheroItemPickup> OnItemPickedUp;

    private void OnTriggerEnter(Collider other) {
        var item = other.GetComponent<PixlheroItemPickup>();
        if (item != null) {
            OnItemPickedUp?.Invoke(item);
            item.RemoveAfterPickup();
        }
    }
}
