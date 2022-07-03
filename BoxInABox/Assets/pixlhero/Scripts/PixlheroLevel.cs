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

        Camera.main.backgroundColor = GetLevelColor(BoxItemState.Instance.HeldItem);

        var levelPrefab = _levelMapping.GetHeldItemPrefab();
        Instantiate(levelPrefab, transform);
    }

    private Color GetLevelColor(BoxItemState.Item item){
        return item switch
        {
            BoxItemState.Item.Banana => new Color(0.85f, 0.84f, 0.68f),
            BoxItemState.Item.BaseItem => Color.white,
            BoxItemState.Item.Motorcycle => new Color(0.52f, 0.54f, 0.62f),
            BoxItemState.Item.Mallet => new Color(0.64f, 0.54f, 0.48f),
            BoxItemState.Item.ButterflyCatchingNet => new Color(0.48f, 0.66f, 0.70f),
            BoxItemState.Item.HourGlass => new Color(0.74f, 0.70f, 0.54f),
            _ => Color.white,
        };
    }
}
