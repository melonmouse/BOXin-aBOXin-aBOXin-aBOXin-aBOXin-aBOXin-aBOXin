using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Wiggle : MonoBehaviour
{
    public Vector3 targetRot;
    public float rotDuration;
    void Start()
    {
        transform.DOLocalRotate(targetRot, rotDuration)
                 .SetLoops(-1, LoopType.Yoyo);
    }
}
