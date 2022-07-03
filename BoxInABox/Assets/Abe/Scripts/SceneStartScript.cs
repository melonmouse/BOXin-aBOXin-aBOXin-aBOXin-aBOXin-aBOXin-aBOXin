using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneStartScript : MonoBehaviour
{
    public BoxItemMapping boxItemMapping;
    public GameObject heldPrefab;
    public Transform hero;
    void Awake()
    {
        if (BoxItemState.Instance.HeldItem == BoxItemState.Item.BaseItem)
        {
            Debug.Log("WARNING: got BaseItem, OVERWRITING HELD ITEM");
            BoxItemState.Instance.HeldItem = BoxItemState.Item.ButterflyCatchingNet;
            // TODO set orientation
        }
        heldPrefab = boxItemMapping.GetHeldItemPrefab();
        GameObject child = Instantiate(heldPrefab, hero);
        child.transform.localScale = 0.09f * Vector3.one;
        child.transform.localPosition = Vector3.zero;
    }
}
