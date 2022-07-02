using UnityEngine;

public class ItemIdentifier : MonoBehaviour {
    public BoxItemState.Item item;

    public void SetAsHeldItem() {
        BoxItemState.Instance.HeldItem = item;
    }
}