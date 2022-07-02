using UnityEngine;
using UnityEngine.Assertions;
using System.Collections.Generic;

public class BoxItemState : MonoBehaviour {
    [System.Serializable]
    public class ItemAndGameObject {
        public Item item;
        public GameObject prefab;
    }

    [SerializeField]
    public List<ItemAndGameObject> ItemPrefabs;
    // The item that is contained in the box to be transfered into the next minigame
    public Item HeldItem{ get; set; }
    public GameObject GetHeldItemPrefab() {
        foreach (ItemAndGameObject itemAndGameObject in ItemPrefabs) {
            Assert.AreEqual(itemAndGameObject.item,
                itemAndGameObject.prefab.GetComponent<ItemIdentifier>().item,
                "");
            if (itemAndGameObject.item == HeldItem) {
                GameObject result = itemAndGameObject.prefab;
                return result;
            }
        }
        throw new System.Exception("No prefab found for item " + HeldItem);
    }

    private BoxItemState() {}  
    private static BoxItemState _instance = null;  
    public static BoxItemState Instance {  
        get {  
            if (_instance == null) {  
                _instance = new BoxItemState();  
            }  
            return _instance;  
        }  
    }

    public enum Item {
        // add items
        BaseItem,
    }
}