using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxAnim : MonoBehaviour
{
    public List<GameObject> lids;
    public List<float> openAngles;
    public List<float> closedAngles;

    public float open;

    void Start()
    {
        SetOpen(this.open);
    }

    public void SetOpen(float open)
    {
        this.open = open;
        for (int i = 0; i < lids.Count; i++)
        {
            float alpha = Mathf.Clamp(open, 0, 1);
            if (i % 2 == 0)
            {
                alpha =  Mathf.Clamp(open+0.3f, 0, 1);
            }
            float angle = openAngles[i] * alpha + closedAngles[i] * (1 - alpha);
            lids[i].transform.localEulerAngles =
                (i % 2 == 0 ? Vector3.up : Vector3.right) * angle;
        }
    }
}
