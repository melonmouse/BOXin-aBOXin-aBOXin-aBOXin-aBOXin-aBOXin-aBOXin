using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using DG.Tweening;

public class PixlheroCutscene : MonoBehaviour
{
    [SerializeField]
    private CinemachineVirtualCamera gameplayCamera;

    private CinemachineVirtualCamera _endCamera;

    private Endbox _endbox;

    [SerializeField]
    private Transform duckCanvasItemRoot;

    [SerializeField]
    private CanvasGroup fadeOutCanvasGroup;

    private void Start() {
        _endCamera = FindObjectOfType<Endbox>().GetComponentInChildren<CinemachineVirtualCamera>(true);
        _endbox = FindObjectOfType<Endbox>();
    }

    public void PlayEnd(){
        _endbox.transform.DOMove(_endbox.transform.position + _endbox.transform.up * 1.5f, 1f)
        .SetEase(Ease.InQuad);

        var duckCanvasPosition = duckCanvasItemRoot.position;
        duckCanvasItemRoot.SetParent(null, true);
        duckCanvasItemRoot.position = duckCanvasPosition;

        duckCanvasItemRoot.DOScale(0.5f, 1f);
        duckCanvasItemRoot.DOMove(_endbox.transform.position + _endbox.transform.up * 2f, 1f);
        duckCanvasItemRoot.DOLookAt(_endbox.transform.forward, 1f);

        //Camera.main.GetComponent
        _endCamera.gameObject.SetActive(true);
        _endCamera.transform.DOLocalMoveY(2f, 3f).SetEase(Ease.InQuad);

        var sequence = DOTween.Sequence();
        sequence.Insert(2.5f, fadeOutCanvasGroup.DOFade(1f, 0.5f));
    }
}