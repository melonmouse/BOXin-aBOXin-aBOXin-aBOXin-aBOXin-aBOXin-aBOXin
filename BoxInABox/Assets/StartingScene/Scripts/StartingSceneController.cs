using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;
using DG.Tweening;

public class StartingSceneController : MonoBehaviour
{
    [SerializeField]
    private Button startButton;

    [SerializeField]
    private Transform endingCamPos;

    [SerializeField]
    private CinemachineVirtualCamera boxCamera;

    [SerializeField]
    private CinemachineVirtualCamera mainCam;

    [SerializeField]
    private Animator boxAnimator;

    [SerializeField]
    private CanvasGroup fadeCanvas;

    [SerializeField]
    private Button backFromCredits;

    [SerializeField]
    private Transform circleObjects;

    [SerializeField]
    private float circleObjectsSpeed;

    private bool _isEnding;

    // Start is called before the first frame update
    void Awake()
    {
        startButton.onClick.AddListener(OnStartPressed);
        backFromCredits.onClick.AddListener(BackFromCredits);
    }

    private void Start()
    {
        fadeCanvas.alpha = 1;
        fadeCanvas.DOFade(0, 0.5f);
    }

    private void Update() {
        circleObjects.rotation = Quaternion.AngleAxis(Time.deltaTime * circleObjectsSpeed, Vector3.forward) * circleObjects.rotation;
    }

    private void OnStartPressed()
    {
        if (_isEnding || boxCamera.gameObject.activeSelf)
            return;

        boxCamera.gameObject.SetActive(true);
    }

    private void BackFromCredits(){
        if (_isEnding)
            return;

        boxCamera.gameObject.SetActive(false);
    }

    public void ClickedOnItem(GameObject item)
    {
        if (_isEnding)
            return;
        
        var itemIdentifier = item.GetComponentInChildren<ItemIdentifier>();
        BoxItemState.Instance.HeldItem = itemIdentifier.item;

        mainCam.transform.DOJump(endingCamPos.position, 1, 1, 2f);
        mainCam.transform.DORotateQuaternion(endingCamPos.rotation, 1.9f);

        boxAnimator.SetBool("Open", true);

        var itempos = item.transform.position;
        item.transform.SetParent(null, true);
        item.transform.position = itempos;
        item.transform.DOJump(endingCamPos.parent.position + new Vector3(0, 0.2f, 0f), 1, 1, 0.5f);
        item.transform.DOScale(0.005f, 0.5f);

        fadeCanvas.DOFade(1, 0.5f).SetDelay(1.5f).OnComplete(
            () =>
            {
                SceneTransition.GoToRandomNextScene();
            }
        );
    }
}
