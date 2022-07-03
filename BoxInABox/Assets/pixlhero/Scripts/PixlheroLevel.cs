using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxItemMapping))]
public class PixlheroLevel : MonoBehaviour
{
    private BoxItemMapping _levelMapping;

    [SerializeField]
    private BoxItemState.Item fallbackLevel;

    // Start is called before the first frame update
    void Awake()
    {
        _levelMapping = GetComponent<BoxItemMapping>();

        if(BoxItemState.Instance.HeldItem == BoxItemState.Item.BaseItem){
            BoxItemState.Instance.HeldItem = fallbackLevel;
        }

        var levelPrefab = _levelMapping.GetHeldItemPrefab();
        Instantiate(levelPrefab, transform);
    }
}
