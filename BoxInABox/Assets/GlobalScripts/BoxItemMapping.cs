using UnityEngine;
using UnityEngine.Assertions;
using System.Collections.Generic;

public class BoxItemMapping : MonoBehaviour {
    [System.Serializable]
    public class ItemAndGameObject {
        public BoxItemState.Item item;
        public GameObject prefab;
    }

    [SerializeField]
    public List<ItemAndGameObject> ItemPrefabs;
    // The item that is contained in the box to be transfered into the next minigame
    public GameObject GetHeldItemPrefab() {
        foreach (ItemAndGameObject itemAndGameObject in ItemPrefabs) {
            Assert.AreEqual(itemAndGameObject.item,
                itemAndGameObject.prefab.GetComponent<ItemIdentifier>().item,
                "");
            if (itemAndGameObject.item == BoxItemState.Instance.HeldItem) {
                GameObject result = itemAndGameObject.prefab;
                return result;
            }
        }
        throw new System.Exception("No prefab found for item " +
            BoxItemState.Instance.HeldItem);
    }

    public GameObject GetItemPrefab(BoxItemState.Item item){
        foreach (ItemAndGameObject itemAndGameObject in ItemPrefabs) {
            Assert.AreEqual(itemAndGameObject.item,
                itemAndGameObject.prefab.GetComponent<ItemIdentifier>().item,
                "");
            if (itemAndGameObject.item == item) {
                GameObject result = itemAndGameObject.prefab;
                return result;
            }
        }
        throw new System.Exception("No prefab found for item " +
            item);
    }
}
