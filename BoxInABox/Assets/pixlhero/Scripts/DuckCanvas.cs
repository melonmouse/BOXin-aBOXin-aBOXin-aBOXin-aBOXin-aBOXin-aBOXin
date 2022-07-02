using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckCanvas : MonoBehaviour
{
    [SerializeField]
    private Transform modelRoot;

    private BoxItemMapping _itemMapping;

    // Start is called before the first frame update
    void Awake()
    {
        _itemMapping = FindObjectOfType<BoxItemMapping>();
    }

    // Update is called once per frame
    void Update()
    {
        var toCamera = Camera.main.transform.position - transform.position;
        var toCameraOnPlane = Vector3.ProjectOnPlane(toCamera, transform.parent.up);
        transform.LookAt(transform.position - toCameraOnPlane, transform.parent.up);
    }

    public void SetItem(BoxItemState.Item itemType)
    {
        foreach(Transform child in modelRoot)
        {
            Destroy(child.gameObject);
        }

        var itemPrefab = _itemMapping.GetHeldItemPrefab();
    }
}
