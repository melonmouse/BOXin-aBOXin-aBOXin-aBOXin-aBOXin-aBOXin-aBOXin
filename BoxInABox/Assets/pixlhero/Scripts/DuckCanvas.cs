using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DuckCanvas : MonoBehaviour
{
    [SerializeField]
    private Transform modelRoot;

    [SerializeField]
    private BoxItemMapping itemMapping;

    // Update is called once per frame
    void Update()
    {
        var toCamera = Camera.main.transform.position - transform.position;
        var toCameraOnPlane = Vector3.ProjectOnPlane(toCamera, transform.parent.up);
        transform.LookAt(transform.position - toCameraOnPlane, transform.parent.up);
    }

    public void SetItem(BoxItemState.Item itemType)
    {
        gameObject.SetActive(true);

        foreach(Transform child in modelRoot)
        {
            Destroy(child.gameObject);
        }

        var itemPrefab = itemMapping.GetItemPrefab(itemType);
        var itemInstance = Instantiate(itemPrefab, modelRoot);
        itemInstance.transform.localPosition = Vector3.zero;
        itemInstance.transform.localRotation = Quaternion.identity;

        transform.DOShakeScale(0.3f, 0.7f, 15, 90);
    }
}
