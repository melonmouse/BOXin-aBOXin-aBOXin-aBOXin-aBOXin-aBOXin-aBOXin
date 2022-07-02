using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PixlheroItemPickuper : MonoBehaviour
{
    public event Action<PixlheroItemPickup> OnItemPickedUp;

    public event Action<Endbox> EndboxTouched;

    private void OnTriggerEnter(Collider other) {
        var item = other.GetComponent<PixlheroItemPickup>();
        if (item != null) {
            OnItemPickedUp?.Invoke(item);
            item.RemoveAfterPickup();
        }
        var endbox = other.GetComponent<Endbox>();
        if (endbox != null) {
            EndboxTouched?.Invoke(endbox);
        }
    }
}
