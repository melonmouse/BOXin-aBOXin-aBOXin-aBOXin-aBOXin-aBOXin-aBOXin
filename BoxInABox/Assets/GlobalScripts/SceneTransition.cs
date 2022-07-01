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

    //TODO decide what exactly the scene ordering should be and change this accordingly
    public static void GoToRandomNextScene(){
        var currentSceneName = SceneManager.GetActiveScene().name;
        var nextListCandidates = _candidateSceneNames.Where(scene => scene != currentSceneName).ToList();
        var chosenScene = nextListCandidates[Random.Range(0, nextListCandidates.Count)];
        SceneManager.LoadScene(chosenScene, LoadSceneMode.Single);
    }
}
