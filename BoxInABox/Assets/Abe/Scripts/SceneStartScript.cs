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
        heldPrefab = boxItemMapping.GetHeldItemPrefab();
        GameObject child = Instantiate(heldPrefab, Vector3.zero,
            Quaternion.identity, hero);
        child.transform.localScale = 0.09f * Vector3.one;
        child.transform.localPosition = Vector3.zero;
    }
}
