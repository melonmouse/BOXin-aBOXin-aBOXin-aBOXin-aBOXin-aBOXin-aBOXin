using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartSceneItemCanvas : MonoBehaviour
{
    private StartingSceneController _controller;

    private void Awake() {
        _controller = FindObjectOfType<StartingSceneController>();
    }

    // Start is called before the first frame update
    void Start()
    {
        var button = GetComponentInChildren<Button>();
        button.onClick.AddListener(OnButtonClicked);
    }

    private void OnButtonClicked(){
        _controller.ClickedOnItem(gameObject);
    }
}
