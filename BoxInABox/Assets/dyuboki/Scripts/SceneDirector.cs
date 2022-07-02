using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class SceneDirector : MonoBehaviour
{

    FadeLayer fadeLayer;
    DialogueRunner dialogueRunner;

    private void Awake(){
        fadeLayer = FindObjectOfType<FadeLayer>();
        dialogueRunner = FindObjectOfType<DialogueRunner>();

        dialogueRunner.AddCommandHandler<float>("fadeIn",FadeIn);
        dialogueRunner.AddCommandHandler<float>("fadeOut",FadeOut);
    }


    private Coroutine FadeIn(float time = 0.1f){
        return StartCoroutine(fadeLayer.ChangeAlphaOverTime(0,time));
    }

    private Coroutine FadeOut(float time = 0.1f){
        return StartCoroutine(fadeLayer.ChangeAlphaOverTime(1,time));
    }


}
