using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;

public static class SceneTransition
{
    // add more scenes here AND in the build settings
    private static readonly List<string> _candidateSceneNames = new List<string>(){
        "Dareios_Scene_0",
        "Abe_Scene_0",
        "pixlhero_Scene_0",
        "RubenNunez_Scene_0",
        "SanGiga_Scene_0"
    };

    private static List<string> unplayedScenes = new List<string>(_candidateSceneNames);

    //TODO decide what exactly the scene ordering should be and change this accordingly
    public static void GoToRandomNextScene(){

        if(unplayedScenes.Count == 0){
            Application.OpenURL("https://github.com/melonmouse/BOXin-aBOXin-aBOXin-aBOXin-aBOXin-aBOXin-aBOXin");
            unplayedScenes = new List<string>(_candidateSceneNames);
            SceneManager.LoadScene("StartingScene");
            return;
        }

        // For now: play every scene once
        string currentSceneName = SceneManager.GetActiveScene().name;
        int chosenSceneIndex = Random.Range(0, unplayedScenes.Count);
        SceneManager.LoadScene(unplayedScenes[chosenSceneIndex], LoadSceneMode.Single);
        unplayedScenes.RemoveAt(chosenSceneIndex);
    }
}
