using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class SceneDirector : MonoBehaviour
{

    FadeLayer fadeLayer;
    DialogueRunner dialogueRunner;

    public BoxItemMapping boxItemMapping;

    public GameObject character;
    GameObject playerModel;

    private void Awake(){
        fadeLayer = FindObjectOfType<FadeLayer>();
        //character = boxItemMapping.GetHeldItemPrefab();
        //character.GetComponent<ItemIdentifier>().item == banana;

       // newOne.GetComponent<ItemIdentifier>().SetAsHeldItem();

        dialogueRunner = FindObjectOfType<DialogueRunner>();

        dialogueRunner.AddCommandHandler<float>("fadeIn",FadeIn);
        dialogueRunner.AddCommandHandler<float>("fadeOut",FadeOut);


    }

    private void Start(){
        //Instantiate(boxItemMapping.GetHeldItemPrefab(),character.transform);

        playerModel = Instantiate(boxItemMapping.GetHeldItemPrefab(),character.transform);
        Debug.Log("runs");
    }


    private Coroutine FadeIn(float time = 0.1f){
        return StartCoroutine(fadeLayer.ChangeAlphaOverTime(0,time));
    }

    private Coroutine FadeOut(float time = 0.1f){
        return StartCoroutine(fadeLayer.ChangeAlphaOverTime(1,time));
    }


    [YarnCommand("changeLevel")]
    public static void ChangeLevel(){
        SceneTransition.GoToRandomNextScene();
    }


}
