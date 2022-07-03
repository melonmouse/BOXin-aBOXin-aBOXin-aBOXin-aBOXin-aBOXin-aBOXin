using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectormanager : MonoBehaviour
{
    public GameObject collector;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < collector.transform.childCount; i++)
        {
            collector.transform.GetChild(i).gameObject.SetActive(false);
        }
    }

    public void ActivateCollected(int index)
    {
        for (int i = 0; i < collector.transform.childCount; i++)
        {
            collector.transform.GetChild(i).gameObject.SetActive(false);
        }
        collector.transform.GetChild(index).gameObject.SetActive(true);
    }
}
