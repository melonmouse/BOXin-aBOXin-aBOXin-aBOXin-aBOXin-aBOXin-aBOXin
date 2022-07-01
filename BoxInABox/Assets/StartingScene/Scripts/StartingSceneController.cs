using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartingSceneController : MonoBehaviour
{
    [SerializeField]
    private Button startButton;

    // Start is called before the first frame update
    void Awake()
    {
        startButton.onClick.AddListener(OnStartPressed);
    }

    private void OnStartPressed(){
        SceneTransition.GoToRandomNextScene();
    }
}
